using HarmonyLib;
using WeaponSkillKeys.Extensions;
using WeaponSkillKeys.UI;

namespace WeaponSkillKeys.Patches {
	[HarmonyPatch(typeof(Character))]
	public class CharacterPatches {
		[HarmonyPatch(nameof(Character.WeaponChanged)), HarmonyPostfix]
		static void Character_WeaponChanged_Postfix(Character __instance) {
			if (__instance.CharacterUI == null) {
				return;
			}

			WeaponSkillDisplayGroup wsd = __instance.CharacterUI.GetWeaponSkillDisplayGroup();
			if (wsd == null) {
				return;
			}

			if (__instance.TryGetMainHandSkill(out Skill skill)) {
				wsd.SetMainHandSkill(skill);
			} else {
				wsd.ClearMainHandSkill();
			}
		}
		
		[HarmonyPatch(nameof(Character.LeftHandChanged)), HarmonyPostfix]
		static void Character_LeftHandChanged_Postfix(Character __instance) {
			if (__instance.CharacterUI == null) {
				return;
			}

			WeaponSkillDisplayGroup wsd = __instance.CharacterUI.GetWeaponSkillDisplayGroup();
			if (wsd == null) {
				return;
			}

			if (__instance.TryGetOffHandSkill(out Skill skill)) {
				wsd.SetOffHandSkill(skill);
			} else {
				wsd.ClearOffHandSkill();
			}
		}
	}

}