# BetterLockers
 Allows to spawn your own items inside lockers.
## Config
```
better_lockers:
  is_enabled: true
  # Stop basegame items from spawning in lockers. StructureTypes that are not in this list will default to false
  disable_base_game_items:
    StandardLocker: true
    ScpPedestal: true
  # Available types: StandardLocker, LargeGunLocker, ScpPedestal, SmallWallCabinet
  locker_spawns:
    StandardLocker:
    - item: GunCOM15
      chance: 10
      amount: 1
    - item: KeycardGuard
      chance: 20
      amount: 1
    LargeGunLocker:
    - item: MicroHID
      chance: 1
      amount: 1
```
