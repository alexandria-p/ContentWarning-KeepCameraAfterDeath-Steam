using HarmonyLib;
using MyceliumNetworking;
using System.Collections.Generic;
using UnityEngine;

namespace KeepCameraAfterDeath.Patches;

[HarmonyPatch(typeof(PersistentObjectsHolder))]
public class PersistentObjectsHolderPatch
{
    // called by PhotonGameLobbyHandler.ReturnToSurface
    // only the host runs ReturnToSurface & thus runs this function

    private static List<VideoCamera>? _existingCamerasUnderground;

    [HarmonyPatch(nameof(PersistentObjectsHolder.FindPersistantObjects))]
    [HarmonyPrefix]
    private static void FindPersistantObjects_Prefix(PersistentObjectsHolder __instance)
    {
        _existingCamerasUnderground = FindVideoCamerasInSet(__instance.m_PersistentObjects);
    }

    [HarmonyPatch(nameof(PersistentObjectsHolder.FindPersistantObjects))]
    [HarmonyPostfix]
    private static void FindPersistantObjects_Postfix(PersistentObjectsHolder __instance)
    {
        if (!MyceliumNetwork.IsHost) return;

        var numObjects = __instance.m_PersistentObjects.Count;

        for (int i = numObjects - 1; i >= 0; i--)
        {
            PersistentObjectInfo item = __instance.m_PersistentObjects[i];
            var objectInstanceData = item.InstanceData;
            var objectGuid = objectInstanceData.m_guid;

            // Then if it is a dropped camera, intercept it!
            if (CameraHandler.TryGetCamera(objectGuid, out var videoCamera))
            {
                // if it was already underground, skip
                if (_existingCamerasUnderground != null && _existingCamerasUnderground.Contains(videoCamera))
                {
                    continue;
                }

                KeepCameraAfterDeath.Instance.SetPreservedCameraInstanceDataForHost(objectInstanceData);

                // We don't want to leave a clone of the camera underground when we are gonna make a new one on the surface.
                // so we want to remove this camera from persistent objects.
                if (__instance.m_PersistentObjectDic.ContainsKey(item.Pickup))
                {
                    __instance.m_PersistentObjectDic.Remove(item.Pickup);
                }

                __instance.m_PersistentObjects.Remove(item);
            }
        }
    }

    private static List<VideoCamera> FindVideoCamerasInSet(List<PersistentObjectInfo> persistantObjects)
    {
        var list = new List<VideoCamera>();

        foreach (var item in persistantObjects)
        {
            var objectInstanceData = item.InstanceData;
            var objectGuid = objectInstanceData.m_guid;

            if (CameraHandler.TryGetCamera(objectGuid, out var videoCamera))
            {
                list.Add(videoCamera);
            }
        }

        return list;
    }
}
