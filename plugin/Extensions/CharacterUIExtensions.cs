using WeaponSkillKeys.UI;

namespace WeaponSkillKeys.Extensions {
	public static class CharacterUIExtensions {
		public static WeaponSkillDisplayGroup GetWeaponSkillDisplayGroup(this CharacterUI characterUI) {
			return characterUI.GetComponentInChildren<WeaponSkillDisplayGroup>();
		}
	}
}