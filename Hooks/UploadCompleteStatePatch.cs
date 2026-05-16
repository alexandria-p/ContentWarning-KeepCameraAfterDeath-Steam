using HarmonyLib;
using System.Linq;
using UnityEngine;

namespace KeepCameraAfterDeath.Patches;

// UploadCompleteUI.PlayVideo -> DisplayVideoEval -> Calls onPlayed.invoke -> Triggers UploadVideoStation.RPC_OnEvaluationComplete
// UploadVideoStation.RPC_OnEvaluationComplete -> calls UploadVideoStation.m_stateMachine -> UploadCompleteState.PlayVideo
// TLDR; This method is played on UploadStation.RPC_OnEvaluationComplete

// The original UploadCompleteState.PlayVideo method will:
// 1. Play the video via UploadCompleteUI.PlayVideo, and
// 2. Award moneys and views once the delegate "PlayVideo" is completed
[HarmonyPatch(typeof(UploadCompleteState))]
public class UploadCompleteStatePatch
{
    [HarmonyPatch(nameof(UploadCompleteState.PlayVideo))]
    [HarmonyPrefix]
    private static bool PlayVideo_Prefix(UploadCompleteState __instance, CameraRecording recording, int score, int views, int money, Comment[] comments)
    {
        // all the clients need to play the video, the host send out RPCs to them to set their ClientDoNotPlayTheseSpookTubeVideoWithRewards collection up
        if (KeepCameraAfterDeath.Instance.ClientDoNotPlayTheseSpookTubeVideoWithRewards.Count > 0)
            Debug.Log($"[{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION}] There are {KeepCameraAfterDeath.Instance.ClientDoNotPlayTheseSpookTubeVideoWithRewards.Count} videos that should not be rewarded by SpookTube.");

        if (KeepCameraAfterDeath.Instance.ClientDoNotPlayTheseSpookTubeVideoWithRewards.Any(_ => _.Equals(recording.videoHandle.id)))
        {
            Debug.Log($"[{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION}] This was recovered footage - host says 'do not award views or money' for video with ID #{recording.videoHandle.id}");
            __instance.m_ui.PlayVideo(recording, views, comments, delegate
            {
                // let the recording play, but don't bother doing anything once the recording is complete
                // (typically we would award views and money within this delegate)
            });
            return false; // skip original
        }

        Debug.Log($"[{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION}] Award views and money for video with ID #{recording.videoHandle.id}");
        return true; // run original
    }
}
