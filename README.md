<p align="center"><img src="https://raw.githubusercontent.com/alexandria-p/ContentWarning-KeepCameraAfterDeath/main/logo.png" width="150"/></p><h1 align="center">Keep Camera After Death (Steam build)</h1>

[![GitHub Page](https://img.shields.io/badge/GitHub-Thunderstore%20Build-blue?logo=github&style=for-the-badge)](https://github.com/alexandria-p/ContentWarning-KeepCameraAfterDeath)

[![Thunderstore Page](https://img.shields.io/thunderstore/v/alexandria_p/Keep_Camera_After_Death?style=for-the-badge&logo=thunderstore)](https://thunderstore.io/c/content-warning/p/alexandria_p/Keep_Camera_After_Death/)
[![Thunderstore Downloads](https://img.shields.io/thunderstore/dt/alexandria_p/Keep_Camera_After_Death?style=for-the-badge&logo=thunderstore&logoColor=white)](https://thunderstore.io/c/content-warning/p/alexandria_p/Keep_Camera_After_Death)

[![GitHub Page](https://img.shields.io/badge/GitHub-Steam%20Build-blue?logo=github&style=for-the-badge)](https://github.com/alexandria-p/ContentWarning-KeepCameraAfterDeath-Steam)

[![Steam Downloads](https://img.shields.io/steam/downloads/3418022830?style=for-the-badge&logo=steam)](https://steamcommunity.com/sharedfiles/filedetails/?id=3418022830)
[![Steam Subscriptions](https://img.shields.io/steam/subscriptions/3418022830?style=for-the-badge&logo=steam)](https://steamcommunity.com/sharedfiles/filedetails/?id=3418022830)
[![Steam Views](https://img.shields.io/steam/views/3418022830?style=for-the-badge&logo=steam)](https://steamcommunity.com/sharedfiles/filedetails/?id=3418022830)
[![Steam Favorites](https://img.shields.io/steam/favorites/3418022830?style=for-the-badge&logo=steam)](https://steamcommunity.com/sharedfiles/filedetails/?id=3418022830)
[![Steam Updated](https://img.shields.io/steam/update-date/3418022830?style=for-the-badge&logo=steam)](https://steamcommunity.com/sharedfiles/filedetails/?id=3418022830)

## Description

Lost your camera underground? No worries!

In the event of:
- total crew death, or
- a major fumble where your cameraman left the camera behind before returning to the diving bell

This mod respawns the camera at its regular spawn position on the surface when the crew returns in the evening. This means you can still export your footage and upload it to spooktube to watch together on the sofa.

As a bonus, you can optionally incentivise your players to stay alive and bring their camera home with rewards that are configurable in the game settings.

The host decides whether or not rewards should be distributed for returning with the camera. If they choose to enable rewards, they can configure the amount of Meta Coins (MC) and cash revenue the crew should receive.

### Changelog

**v2.0.1**
-  Add the option to toggle rewards on/off for recovered footage when watching it on the SpookTube TV

**v2.0.0**
- Allow recovery of multiple cameras in a single round
- Add compatibility with ContentPOVs mod

**v1.3.0**
- Include MMHOOK_Assembly-CSharp.dll in project files, so package dependency on Hamunii-AutoHookGenPatcher-1.0.4 can be removed (in preparation to upload to Steam workshop)
- Pull out logic for the final day into its own tiny mod that is a new dependency: alexandria_p-Always_Play_Final_Day

**v1.2.0**
- Fixed breaking changes introduced by ContentWarningPlugin & BepInEx.BaseUnityPlugin 
- Add DontDestroyOnLoad to handle above point (simple explanation)
- Use the new vanilla CW Settings handler instead of a third-party library (previously ContentSettings 1.2.2)

**v1.1.0**
- Allow crew to view their camera footage on the final day if they lost their camera underground, even if the footage won't meet quota (turned **on** by default).
- *The base game will end the third day immediately, if it detects quota has not been met.*
- *This feature can be toggled on or off in the game menu, in case it interacts with other mods.*

### Contact Us

🚨 If you found this mod on any site except for *Thunderstore* or *r2 Modman* (or on the Steam Workshop under HumbleKraken), then I cannot guarantee the safety of the file you have downloaded! 🚨

Please report this back to me on my GitHub https://github.com/alexandria-p or my Twitter account https://twitter.com/HumbleKraken.

Feel free to tweet at me too if you enjoyed using this mod - especially if you attach the footage you were able to save!

If you would like to report any bugs, join the Content Warning modding discord and find me there.

# Installation steps

### All crew members must have this mod installed, and follow these steps

* Install the mod on the Steam Workshop
* Ensure you have its dependencies also installed
* If there is any trouble, try moving Content Loader and Mycelium higher up the mod loader than this mod.

# Why do I need this mod

Pssst - even if you don't use this mod, your video files are still saved if you lost your camera underground. Press `F3` to view your videoclips! This will work until you leave the game lobby and can be done in the vanilla (unmodded) game.

The KeepCameraAfterDeath mod just allows players to access that footage in-game on a new videocamera, so they can export it to CD and enjoy watching it together on the sofa.

# How does it work?

Here is a breakdown of what happens under the hood.

When a camera is left behind underground, or all crew members die and the camera is forcibly dropped from their inventory, as the diving bell returns to the surface it does a check for any items left behind that it wants to persist for the players to be able to find again in a later dive.

Cameras are one of the item types that are set to persist for future dives (within the same week).

This mod intercepts at this point. It picks up:
- when a camera was left behind this run
- and if that camera does not already exist in the list of persistent objects (so it must be newly dropped)

Instead of letting the crew find that camera again in a future run, this mod will instead save the footage from that camera and load it onto a new camera that it spawns on the surface.

Any camera that this mod "saves" will no longer spawn underground on future runs, to prevent duplicate footage from existing (makes sense, right?)

# Does this mod work if my crew has multiple cameras?

Yes! As of update 2.0.0.

Remember how this mod searches for & preserves the footage from dropped cameras when a run ends?

It preserves the footage of every newly dropped camera it finds, to load onto each new camera it spawns on the surface.

If your crew drop multiple cameras underground in a single run, then multiple new cameras will spawn on the surface to load the saved data onto.

# Known bugs

- If the player jumps off the edge of the world while underground & holding the camera, that camera does not get recovered by this mod.

# Future improvements

My ideas mostly revolve around handling if a crew somehow has multiple cameras, and manages to leave more than one camera behind on their dive. 

Maybe in the future this mod will save all cameras dropped in a run underground, and spawn as many new cameras as it needs on the surface to copy that footage onto. 

Right now it is easiest for me to only save a single camera's worth of footage, because I am piggy-backing how the game spawns that new (single) camera on the porch at the start of a new day.

# Can I copy this mod's code? Can I contribute to this project?

*You cannot wholesale copy this mod with the intent of passing it off as your own.*

Ideally, you should be able to raise an issue or pull request on this project, so that any new functionality can stay in a single mod & be toggleable by users in the game settings. If this gives you trouble, please see the "Contact Us" section of this README for details on how to get in touch.

If you'd like to fork the project to add or change functionality, please message me first at my GitHub or Twitter and make sure you link back to my GitHub repository in your mod description.

https://github.com/alexandria-p/ContentWarning-KeepCameraAfterDeath

I wholeheartedly encourage you to look at the mod files on my GitHub to learn more about how it was made 💝 I have learnt so much by reading the source code of other mods.

# Steam Workshop Dependencies 
- [RugbugRedfern] Mycelium Networking
- [HumbleKraken (me!)] Always Play Final Day
- [Computery] Content Loader (for installing BepinEx)

# References

Scaffolded using Hamunii's tutorials: https://www.youtube.com/watch?v=o0lVCSSKqTY

Uses the Xilo's Content Warning Templates: https://github.com/ContentWarningCommunity/Content-Warning-Mod-Templates

This template uses MonoMod, and the MMHOOK_Assembly-CSharp.dll file generated by Hamunii-AutoHookGenPatcher-1.0.4.

Notes about how to kick-off initialisation for mods in Steam taken from the LandfallGames mod template: https://github.com/landfallgames/ExampleCWPlugin/blob/main/ExampleCWPlugin.cs

This template uses MonoMod, and the MMHOOK_Assembly-CSharp.dll file generated by Hamunii-AutoHookGenPatcher-1.0.4.

[quote]Workshop ID: 3418022830[/quote]