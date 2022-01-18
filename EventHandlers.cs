using Exiled.API.Features;
using MapGeneration.Distributors;
using MEC;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Exiled.API.Features.Items;

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
                    var locker_pickups = Map.Pickups.ToArray().Where(x => Vector3.Distance(x.Position, locker.transform.position) < 2);
                    foreach (Pickup pickup in locker_pickups)
                    {
                        pickup.Destroy();
                    }
                }
                if (Main.Instance.Config.LockerSpawns.TryGetValue(locker.StructureType, out var list))
                {
                    foreach (LockerChamber chamber in locker.Chambers)
                    {
                        foreach (var spawner in list) // deep nested loops, just the way i like it.
                        {
                            int chance = Random.Range(0, 101);
                            if (spawner.chance > chance)
                            {
                                chamber.SpawnItem(spawner.item, spawner.amount);
                                break;
                            }
                        }

                    }
                }
            }
        }
    }
}
