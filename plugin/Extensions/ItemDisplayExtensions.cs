using System.Reflection;
using HarmonyLib;
using UnityEngine.UI;

namespace WeaponSkillKeys.Extensions {
	public static class ItemDisplayExtensions {
		private static readonly FieldInfo itemDisplay_lblQuantity = AccessTools.Field(typeof(ItemDisplay), "m_lblQuantity");
		private static readonly FieldInfo itemDisplay_cooldownDisplay = AccessTools.Field(typeof(ItemDisplay), "m_cooldownDisplay");

		public static void SetLblQuantity(this ItemDisplay characterUI, Text lblQuantity) {
			itemDisplay_lblQuantity.SetValue(characterUI, lblQuantity);
		}

		public static SkillCooldownDisplay GetCooldownDisplay(this ItemDisplay characterUI) {
			return (SkillCooldownDisplay)itemDisplay_cooldownDisplay.GetValue(characterUI);
		}

	}
}