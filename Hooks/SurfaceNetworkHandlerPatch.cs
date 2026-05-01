using HarmonyLib;
using MyceliumNetworking;
using System.Linq;
using UnityEngine;

namespace KeepCameraAfterDeath.Patches;

[HarmonyPatch(typeof(SurfaceNetworkHandler))]
public class SurfaceNetworkHandlerPatch
{
    // this method is run on every client
    [HarmonyPatch(nameof(SurfaceNetworkHandler.InitSurface))]
    [HarmonyPrefix]
    private static void InitSurface_Prefix(SurfaceNetworkHandler __instance)
    {
        // Clear data when entering new lobby
        if (SurfaceNetworkHandler.RoomStats == null)
        {
            KeepCameraAfterDeath.Instance.ClearData();
        }

        // When returning from spelunking,
        // Set if camera was brought home
        if (MyceliumNetwork.IsHost && TimeOfDayHandler.TimeOfDay == TimeOfDay.Evening)
        {
            // - uses host settings to set rewards
            if (KeepCameraAfterDeath.Instance.PlayerSettingEnableRewardForCameraReturn)
            {
                // Determine rewards for players (before we start spawning cameras and changing numbers)
                KeepCameraAfterDeath.Instance.Command_SetPendingRewardForAllPlayers();
            }

            if (KeepCameraAfterDeath.Instance.PreservedCameraInstanceDataCollectionForHost.Any())
            {
                Debug.Log($"[{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION}] Trying to restore backed-up camera footage");

                // Host spawns new cameras
                KeepCameraAfterDeath.Instance.SpawnCamerasAndRestoreFootage(__instance);
            }
            else
            {
                Debug.Log($"[{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION}] Could not find any camera footage to restore");
            }
        }
    }

    [HarmonyPatch(nameof(SurfaceNetworkHandler.NextDay))]
    [HarmonyPostfix]
    private static void NextDay_Postfix(SurfaceNetworkHandler __instance)
    {
        //Debug.Log($"[{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION}] Surface network handler patch NEXT DAY: reset data for day");

        // camera spawning doesnt happen till later in onSlept, so resetting the data here after NextDay is complete within OnSlept should be fine.
        KeepCameraAfterDeath.Instance.Command_ResetDataforDay();
    }
}
