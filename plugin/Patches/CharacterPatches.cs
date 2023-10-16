using HarmonyLib;
using WeaponSkillKeys.Extensions;

namespace WeaponSkillKeys.Patches {
	[HarmonyPatch(typeof(Character))]
	public class CharacterPatches {
		[HarmonyPatch(nameof(Character.WeaponChanged)), HarmonyPostfix]
		static void Character_WeaponChanged_Postfix(Character __instance) {
			if (__instance.CharacterUI == null) {
				return;
			}

			__instance.UpdateWeaponSkills();
		}
		
		[HarmonyPatch(nameof(Character.LeftHandChanged)), HarmonyPostfix]
		static void Character_LeftHandChanged_Postfix(Character __instance) {
			if (__instance.CharacterUI == null) {
				return;
			}

			__instance.UpdateWeaponSkills();
		}
	}

}