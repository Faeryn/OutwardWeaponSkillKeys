using HarmonyLib;
using UnityEngine;
using WeaponSkillKeys.Extensions;

namespace WeaponSkillKeys.Patches {
	[HarmonyPatch(typeof(CharacterUI), "Awake")]
	public class CharacterUI_Awake {
		[HarmonyPostfix]
		static void Postfix(CharacterUI __instance) {
			GameObject hud = __instance.GetHUDCanvasGroup().gameObject;
			GameObject weaponSkillsObj = new GameObject("WeaponSkillDisplay");
			weaponSkillsObj.transform.SetParent(hud.transform, false);
			weaponSkillsObj.AddComponent<WeaponSkillDisplay>();
		}
	}
}