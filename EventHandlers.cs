using InventorySystem.Items.Pickups;
using MapGeneration.Distributors;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BetterLockers
{
    internal class EventHandlers
    {
        public void OnRoundStart()
        {
            Timing.RunCoroutine(SpawnItems());
        }

        public IEnumerator<float> SpawnItems()
        {
            yield return Timing.WaitForSeconds(1f);
            var lockers = Object.FindObjectsOfType<Locker>();
            foreach (var locker in lockers)
            {
                if (Main.Instance.Config.DisableBaseGameItems.TryGetValue(locker.StructureType, out bool destroy) && destroy)
                {
                    foreach (ItemPickupBase pickup in locker.Chambers.SelectMany(x => x._content))
                    {
                        pickup.DestroySelf();
                    }
                }
                if (Main.Instance.Config.LockerSpawns.TryGetValue(locker.StructureType, out var list))
                {
                    foreach (LockerChamber chamber in locker.Chambers)
                    {
                        int chance = Random.Range(1, 100);
                        var found = list.Find(x => x.chance > chance);
                        if (found != null)
                        {
                            chamber.SpawnItem(found.item, found.amount);
                        }
                    }
                }
            }
        }
    }
}
