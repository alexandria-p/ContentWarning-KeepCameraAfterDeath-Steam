[quote]Recovers lost footage & copies it onto a new camera, if your crew died or left their camera underground. Includes configurable rewards to incentivize successful camera return![/quote]

[i] This mod now supports multiple cameras, with the release of v2.0.0![/i]

[h1]Keep Camera After Death - Mod for Content Warning[/h1]

Lost your camera underground? No worries!

In the event of:
[list]
    [*]total crew death, or
    [*]a major fumble where your cameraman left the camera behind before returning to the diving bell
[/list]

This mod respawns the camera at its regular spawn position on the surface when the crew returns in the evening. This means you can still export your footage and upload it to spooktube to watch together on the sofa.

As a bonus, you can optionally incentivise your players to stay alive and bring their camera home with rewards that are configurable in the game settings.

The host decides whether or not rewards should be distributed for returning with the camera. If they choose to enable rewards, they can configure the amount of Meta Coins (MC) and cash revenue the crew should receive.

[h1]Installation steps[/h1]

[h3]All crew members must have this mod installed, and follow these steps[/h3] 
[list]
    [*]Install the mod on the Steam Workshop
    [*]Ensure you have its dependencies also installed
    [*]If there is any trouble, try moving Content Loader and Mycelium higher up the mod loader than this mod.
[/list]

[h3]Changelog[/h3]

[i]v2.0.0[/i]
[list]
    [*]Allow recovery of multiple cameras in a single round
    [*]Add compatibility with ContentPOVs (a mod that was overriding the vanilla functionality of the PickupSpawner that I was piggy-backing for this mod)
[/list]

[i]v1.3.0[/i]
[list]
    [*]Initial release to Steam
[/list]

[h3]Contact Us[/h3] 

🚨 If you found this mod on any site except for [b]Thunderstore[/b] or [b]r2 Modman[b/] (or on the Steam Workshop under HumbleKraken), then I cannot guarantee the safety of the file you have downloaded! 🚨

Please report this back to me on my GitHub https://github.com/alexandria-p or my Twitter account https://twitter.com/HumbleKraken.

Feel free to tweet at me too if you enjoyed using this mod - especially if you attach the footage you were able to save!

If you would like to report any bugs, comment on the Workshop mod page or join the Content Warning modding discord and find me there.

[h1]Why do I need this mod[/h1]

Pssst - even if you don't use this mod, your video files are still saved if you lost your camera underground. Press `F3` to view your videoclips! This will work until you leave the game lobby and can be done in the vanilla (unmodded) game.

The KeepCameraAfterDeath mod just allows players to access that footage in-game on a new videocamera, so they can export it to CD and enjoy watching it together on the sofa.

[h1]How does it work?[/h1]

Here is a breakdown of what happens under the hood.

When a camera is left behind underground, or all crew members die and the camera is forcibly dropped from their inventory, as the diving bell returns to the surface it does a check for any items left behind that it wants to persist for the players to be able to find again in a later dive.

Cameras are one of the item types that are set to persist for future dives (within the same week).

This mod intercepts at this point. It picks up:
[list]
    [*]when a camera was left behind this run
    [*]and if that camera does not already exist in the list of persistent objects (so it must be newly dropped)
[/list]

Instead of letting the crew find that camera again in a future run, this mod will instead save the footage from that camera and load it onto a new camera that it spawns on the surface.

Any camera that this mod "saves" will no longer spawn underground on future runs, to prevent duplicate footage from existing (makes sense, right?)

[h1]Does this mod work if my crew has multiple cameras?[/h1]

Yes...with a caveat.

Remember how this mod searches for & preserves the footage from dropped cameras when a run ends?

It only preserves the footage of the *first* newly dropped camera it finds, to load onto the new camera it spawns on the surface.

If your crew drop multiple cameras underground in a single run, then all the remaining cameras will continue to persist in the underground world (as they do in the vanilla game) for your crew to find.

[h1]Known bugs[/h1]
[list]
    [*]If the player jumps off the edge of the world while underground & holding the camera, that camera does not get recovered by this mod.
[/list]

[h1]Future improvements[/h1]

My ideas mostly revolve around handling if a crew somehow has multiple cameras, and manages to leave more than one camera behind on their dive. 

Maybe in the future this mod will save all cameras dropped in a run underground, and spawn as many new cameras as it needs on the surface to copy that footage onto. 

Right now it is easiest for me to only save a single camera's worth of footage, because I am piggy-backing how the game spawns that new (single) camera on the porch at the start of a new day.

[h1]Can I copy this mod's code? Can I contribute to this project?[/h1]

[b]You cannot wholesale copy this mod with the intent of passing it off as your own.[/b]

Ideally, you should be able to raise an issue or pull request on this project, so that any new functionality can stay in a single mod & be toggleable by users in the game settings. If this gives you trouble, please see the "Contact Us" section of this README for details on how to get in touch.

If you'd like to fork the project to add or change functionality, please message me first at my GitHub or Twitter and make sure you link back to my GitHub repository in your mod description.

https://github.com/alexandria-p/ContentWarning-KeepCameraAfterDeath-Steam

I wholeheartedly encourage you to look at the mod files on my GitHub to learn more about how it was made 💝 I have learnt so much by reading the source code of other mods.

[h1]Dependencies[/h1]
(these will be installed automatically)
[list]
    [*][url=https://steamcommunity.com/workshop/filedetails/?id=3387698650]Content Loader by Computery[/url]
    [*][url=https://steamcommunity.com/workshop/filedetails/?id=3384690922]Mycelium Networking by Rugbug Redfern[/url]
    [*][url=https://steamcommunity.com/workshop/filedetails/?id=3418022458]Always_Play_Final_Day by HumbleKraken (me!)[/url]
[/list]

[h1]References[/h1]

Scaffolded using Hamunii's tutorials: https://www.youtube.com/watch?v=o0lVCSSKqTY

Uses the Xilo's Content Warning Templates: https://github.com/ContentWarningCommunity/Content-Warning-Mod-Templates

Notes about how to kick-off initialisation for mods in Steam taken from the LandfallGames mod template: https://github.com/landfallgames/ExampleCWPlugin/blob/main/ExampleCWPlugin.cs

This template uses MonoMod, and the MMHOOK_Assembly-CSharp.dll file generated by Hamunii-AutoHookGenPatcher-1.0.4.

[quote]Workshop ID: 3418022830[/quote]