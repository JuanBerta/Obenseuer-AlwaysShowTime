# Obenseuer-AlwaysShowTime

BepInEx 6 mod for **Obenseuer** that always shows the current in-game time on the HUD.

## Features

- The HUD clock stays visible at all times, even when the character has **no watch**, **no clock item** and no other time-telling equipment.
- Displays the current in-game time as `DayOfWeek HH:MM`.

## How it works

Vanilla `ShowTime.Update()` calls `HideTime()` (sets `canvasGroup.alpha = 0`) whenever:

- `WatchSlotController.ClockEquipped == false` and the item is not flagged `ignoreRequiredItem`, or
- the inventory does not contain an item with category `Clock` / `Clock Calendar`, or
- no connected (ammo > 0) clock item is present.

This mod Harmony-patches `ShowTime.Update()` (postfix) and re-calls `DisplayTime()` + `UpdateTime()` so the clock is always visible.

## Installation

1. Install [BepInEx 6](https://github.com/BepInEx/BepInEx) into the game folder.
2. Drop `Obenseuer-AlwaysShowTime.dll` into `BepInEx/plugins`.
3. Launch the game.

## Configuration

| Config | Section | Default | Description |
| --- | --- | --- | --- |
| `AlwaysShowTime` | General | `true` | Master toggle: force the HUD clock to be visible at all times. |

Config file: `BepInEx/config/JuanBerta.Obenseuer.AlwaysShowTime.cfg`

## Build

Requires .NET Framework 4.7.2 reference assemblies and MSBuild.

```
"C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" Obenseuer-AlwaysShowTime.csproj /p:Configuration=Release /p:Platform=x64
```

Output: `bin\Release\Obenseuer-AlwaysShowTime.dll`
