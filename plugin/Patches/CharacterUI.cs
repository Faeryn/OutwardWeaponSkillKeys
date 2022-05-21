using HarmonyLib;
using UnityEngine;
using WeaponSkillKeys.Extensions;
using WeaponSkillKeys.UI;

namespace WeaponSkillKeys.Patches {
	[HarmonyPatch(typeof(CharacterUI), "Awake")]
	public class CharacterUI_Awake {
		[HarmonyPostfix]
		static void Postfix(CharacterUI __instance) {
			GameObject hud = __instance.GetHUDCanvasGroup().gameObject;
			GameObject weaponSkillsObj = new GameObject("WeaponSkillDisplay");
			weaponSkillsObj.transform.SetParent(hud.transform, false);
			weaponSkillsObj.AddComponent<WeaponSkillDisplayGroup>();
		}
	}
}