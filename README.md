# BetterLockers
 Allows to spawn your own items inside lockers.
This plugin doesn't remove the items already spawned in the lockers.
As soon as i find a way, i will add a config option.
## Config
```
better_lockers:
  is_enabled: true
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
