using HarmonyLib;
using WeaponSkillKeys.Extensions;

namespace WeaponSkillKeys.Patches {
	[HarmonyPatch(typeof(Character), nameof(Character.WeaponChanged))]
	public class Character_WeaponChanged {
		[HarmonyPostfix]
		static void Postfix(Character __instance) {
			WeaponSkillDisplay wsd = __instance.CharacterUI.GetWeaponSkillDisplay();
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
			WeaponSkillDisplay wsd = __instance.CharacterUI.GetWeaponSkillDisplay();
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