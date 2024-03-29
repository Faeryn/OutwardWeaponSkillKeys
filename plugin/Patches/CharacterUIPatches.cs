using HarmonyLib;
using UnityEngine;
using WeaponSkillKeys.UI;

namespace WeaponSkillKeys.Patches {
	[HarmonyPatch(typeof(CharacterUI))]
	public class CharacterUIPatches {
		[HarmonyPatch(nameof(CharacterUI.Awake)), HarmonyPostfix]
		static void CharacterUI_Awake_Postfix(CharacterUI __instance) {
			GameObject hud = __instance.m_hudCanvasGroup.gameObject;
			GameObject weaponSkillsObj = new GameObject("WeaponSkillDisplay");
			weaponSkillsObj.transform.SetParent(hud.transform, false);
			weaponSkillsObj.AddComponent<WeaponSkillDisplayGroup>();
		}
	}
}