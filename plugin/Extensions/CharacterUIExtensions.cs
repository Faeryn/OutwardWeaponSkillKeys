using System.Reflection;
using HarmonyLib;
using UnityEngine;
using WeaponSkillKeys.UI;

namespace WeaponSkillKeys.Extensions {
	public static class CharacterUIExtensions {
		private static readonly FieldInfo characterUI_hudCanvasGroup = AccessTools.Field(typeof(CharacterUI), "m_hudCanvasGroup");

		public static CanvasGroup GetHUDCanvasGroup(this CharacterUI characterUI) {
			return (CanvasGroup) characterUI_hudCanvasGroup.GetValue(characterUI);
		}

		public static WeaponSkillDisplayGroup GetWeaponSkillDisplayGroup(this CharacterUI characterUI) {
			return characterUI.GetComponentInChildren<WeaponSkillDisplayGroup>();
		}
	}
}