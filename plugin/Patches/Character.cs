using HarmonyLib;
using WeaponSkillKeys.Extensions;
using WeaponSkillKeys.UI;

namespace WeaponSkillKeys.Patches {
	[HarmonyPatch(typeof(Character), nameof(Character.WeaponChanged))]
	public class Character_WeaponChanged {
		[HarmonyPostfix]
		static void Postfix(Character __instance) {
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
	}

	[HarmonyPatch(typeof(Character), nameof(Character.LeftHandChanged))]
	public class Character_LeftHandChanged {
		[HarmonyPostfix]
		static void Postfix(Character __instance) {
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