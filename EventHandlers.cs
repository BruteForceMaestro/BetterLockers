using InventorySystem.Items.Pickups;
using MapGeneration.Distributors;
using UnityEngine;

namespace BetterLockers
{
    internal class EventHandlers
    {
        private readonly Config cfg;
        public EventHandlers(Main plugin)
        {
            cfg = plugin.Config;
        }
        public void OnRoundStart()
        {
            var lockers = Object.FindObjectsOfType<Locker>();
            foreach (var locker in lockers)
            {
                bool toDestroy = cfg.DisableBaseGameItems.TryGetValue(locker.StructureType, out bool destroy) && destroy;
                bool toSpawn = cfg.LockerSpawns.TryGetValue(locker.StructureType, out var list);
                foreach (LockerChamber chamber in locker.Chambers)
                {
                    if (toDestroy)
                    {
                        foreach (ItemPickupBase pickup in chamber._content)
                        {
                            pickup.DestroySelf();
                        }
                    }
                    if (toSpawn)
                    {
                        foreach (Spawner spawner in list)
                        {
                            if (spawner.chance < Random.Range(1, 100))
                            {
                                continue;
                            }
                            chamber.SpawnItem(spawner.item, spawner.amount);
                            break;
                        }
                    }
                }
            }
        }
    }
}
