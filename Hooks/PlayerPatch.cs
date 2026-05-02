using HarmonyLib;
using MyceliumNetworking;

namespace KeepCameraAfterDeath.Patches;

[HarmonyPatch(typeof(Player))]
public class PlayerPatch
{
    [HarmonyPatch(nameof(Player.Update))]
    [HarmonyPostfix] // originally had this as prefix, but I dont think it matters that it is postfix. If i get complaints, I will try changing it back.
    private static void Update_Postfix(Player __instance)
    {
        if (KeepCameraAfterDeath.Instance.ClientPendingRewardForCameraReturn == null
            || !__instance.IsLocal
            || !__instance.data.playerSetUpAndReady
            || SurfaceNetworkHandler.RoomStats == null
            || TimeOfDayHandler.TimeOfDay != TimeOfDay.Evening)
        {
            return;
        }

        // When returning from spelunking, must wait until camera.main and players exist before running rewards 
        // (or SFX that plays when UI message is shown will fail and wreak havoc) 
        // so we run the code here on Player.Update()

        AddCashToRoom();
        AddMCToPlayers();
        KeepCameraAfterDeath.Instance.ClearPendingRewardForCameraReturn();
    }

    private static void AddCashToRoom()
    {
        var hostSpecifiedCashReward = KeepCameraAfterDeath.Instance.ClientPendingRewardForCameraReturn!.Value.cash;
        if (hostSpecifiedCashReward <= 0) return;

        UserInterface.ShowMoneyNotification("Cash Received", $"${(int)hostSpecifiedCashReward}", MoneyCellUI.MoneyCellType.Revenue);

        // We only want money to be added to the room once, so let the host do it
        if (MyceliumNetwork.IsHost)
        {
            SurfaceNetworkHandler.RoomStats.AddMoney((int)hostSpecifiedCashReward);
        }
    }

    private static void AddMCToPlayers()
    {
        var hostSpecifiedMCReward = KeepCameraAfterDeath.Instance.ClientPendingRewardForCameraReturn!.Value.mc;
        if (hostSpecifiedMCReward <= 0) return;
        // Client's handle adding their own MC reward, but the amount is set by the host
        MetaProgressionHandler.AddMetaCoins((int)hostSpecifiedMCReward);
    }
}
