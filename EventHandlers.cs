using MapGeneration.Distributors;
using MEC;
using System.Collections.Generic;
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
            yield return Timing.WaitForSeconds(5f); // at the start of the round not all lockers are initialized
            var lockers = Object.FindObjectsOfType<Locker>();
            foreach (var locker in lockers)
            {
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
