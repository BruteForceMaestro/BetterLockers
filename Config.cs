using Exiled.API.Interfaces;
using MapGeneration.Distributors;
using System.Collections.Generic;
using System.ComponentModel;

namespace BetterLockers
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Stop basegame items from spawning in lockers. StructureTypes that are not in this list will default to false")]
        public Dictionary<StructureType, bool> DisableBaseGameItems { get; set; } = new Dictionary<StructureType, bool>()
        {
            [StructureType.StandardLocker] = true,
            [StructureType.ScpPedestal] = true
        };
        
        [Description("Available types: StandardLocker, LargeGunLocker, ScpPedestal, SmallWallCabinet")]
        public Dictionary<StructureType, List<Spawner>> LockerSpawns { get; set; } = new()
        {
            [StructureType.StandardLocker] = new List<Spawner>
            {
                new Spawner
                {
                    item = ItemType.GunCOM15,
                    amount = 1,
                    chance = 10
                },
                new Spawner
                {
                    item = ItemType.KeycardGuard,
                    amount = 1,
                    chance = 20
                }
            },
            [StructureType.LargeGunLocker] = new List<Spawner>
            {
                new Spawner
                {
                    item = ItemType.MicroHID,
                    amount = 1,
                    chance = 1
                }
            }
        };

        [Description("Keep this off unless you want your console spammed.")]
        public bool DebugMode { get; set; } = false;
    }
}
