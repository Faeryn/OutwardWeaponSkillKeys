using System.Reflection;
using HarmonyLib;
using UnityEngine.UI;

namespace WeaponSkillKeys.Extensions {
	public static class ItemDisplayExtensions {
		private static readonly FieldInfo itemDisplay_lblQuantity = AccessTools.Field(typeof(ItemDisplay), "m_lblQuantity");

		public static void SetLblQuantity(this ItemDisplay characterUI, Text lblQuantity) {
			itemDisplay_lblQuantity.SetValue(characterUI, lblQuantity);
		}

	}
}