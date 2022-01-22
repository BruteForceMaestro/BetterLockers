using Exiled.API.Features;
using InventorySystem.Items.Pickups;
using MapGeneration.Distributors;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BetterLockers
{
    internal class EventHandlers
    {
        public void OnRoundStart()
        {
            var lockers = Object.FindObjectsOfType<Locker>();
            var field = typeof(LockerChamber).GetField("_content", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
            foreach (var locker in lockers)
            {
                bool toDestroy = Main.Instance.Config.DisableBaseGameItems.TryGetValue(locker.StructureType, out bool destroy) && destroy;
                foreach (LockerChamber chamber in locker.Chambers)
                {
                    if (toDestroy)
                    {
                        foreach (ItemPickupBase pickup in (HashSet<ItemPickupBase>)field.GetValue(chamber))
                        {
                            pickup.DestroySelf();
                            Log.Debug($"Pickup Destroyed: {Map.FindParentRoom(locker.gameObject)} | {pickup.Info.ItemId}", Main.Instance.Config.DebugMode);
                        }
                    }
                    if (Main.Instance.Config.LockerSpawns.TryGetValue(locker.StructureType, out var list))
                    {
                        foreach (Spawner spawner in list)
                        {
                            if (spawner.chance < Random.Range(1, 100))
                            {
                                continue;
                            }
                            chamber.SpawnItem(spawner.item, spawner.amount);
                            Log.Debug($"Pickup Spawned: {Map.FindParentRoom(locker.gameObject)} | {spawner.item}", Main.Instance.Config.DebugMode);
                            break;
                        }
                    }
                }
            }
        }
    }
}
