using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.Mono;
using HarmonyLib;

namespace AlwaysShowTimeMod
{
	[BepInPlugin("JuanBerta.Obenseuer.AlwaysShowTime", "Always Show Time", "1.0.0")]
	public class AlwaysShowTimePlugin : BaseUnityPlugin
	{
		internal static ConfigEntry<bool> AlwaysShowTime;

		private void Awake()
		{
			AlwaysShowTime = Config.Bind("General", "AlwaysShowTime", true, "Always show the current in-game time on the HUD, even when the character has no watch or clock item equipped.");
			Harmony.CreateAndPatchAll(typeof(ShowTime_Update_Patch));
			Logger.LogInfo("Always Show Time loaded.");
		}

		// The vanilla ShowTime.Update() hides the HUD clock (canvasGroup.alpha = 0) whenever
		// the player has no watch / clock / connected item. We re-show the clock right after.
		[HarmonyPatch(typeof(ShowTime), "Update")]
		internal static class ShowTime_Update_Patch
		{
			internal static void Postfix(ShowTime __instance)
			{
				if (!AlwaysShowTime.Value || __instance == null)
				{
					return;
				}
				__instance.DisplayTime();
				__instance.UpdateTime();
			}
		}
	}
}
