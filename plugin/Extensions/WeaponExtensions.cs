using System.Collections.Generic;

namespace WeaponSkillKeys.Extensions {
	public static class WeaponExtensions {
		
		private static readonly Dictionary<Weapon.WeaponType, HashSet<int>> AllWeaponSkills = new Dictionary<Weapon.WeaponType, HashSet<int>> {
			{Weapon.WeaponType.Sword_1H, new HashSet<int>{8100290}}, // Puncture
			{Weapon.WeaponType.Axe_1H, new HashSet<int>{8100380}}, // Talus Cleaver
			{Weapon.WeaponType.Mace_1H, new HashSet<int>{8100270}}, // Mace Infusion
			{Weapon.WeaponType.Dagger_OH, new HashSet<int>{8100072}}, // Dagger Slash
			{Weapon.WeaponType.Chakram_OH, new HashSet<int>{8100250}}, // Chakram Pierce
			{Weapon.WeaponType.Pistol_OH, new HashSet<int>{8200600}}, // Fire / Reload
			{Weapon.WeaponType.Halberd_2H, new HashSet<int>{8100320}}, // Moon Swipe
			{Weapon.WeaponType.Sword_2H, new HashSet<int>{8100362}}, // Pommel Counter
			{Weapon.WeaponType.Axe_2H, new HashSet<int>{8100300}}, // Execution
			{Weapon.WeaponType.Mace_2H, new HashSet<int>{8100310}}, // Juggernaut
			{Weapon.WeaponType.Spear_2H, new HashSet<int>{8100340}}, // Simeon's Gambit
			{Weapon.WeaponType.FistW_2H, new HashSet<int>{8201040}}, // Prismatic Flurry
			{Weapon.WeaponType.Shield, new HashSet<int>{8100190}}, // Shield Charge
			{Weapon.WeaponType.Bow, new HashSet<int>{8100100}} // Evasion Shot
		};
		
		private static readonly Dictionary<Weapon.WeaponType, int> SelectedWeaponSkills = new Dictionary<Weapon.WeaponType, int> {
			{Weapon.WeaponType.Sword_1H, 8100290}, // Puncture
			{Weapon.WeaponType.Axe_1H, 8100380}, // Talus Cleaver
			{Weapon.WeaponType.Mace_1H, 8100270}, // Mace Infusion
			{Weapon.WeaponType.Dagger_OH, 8100072}, // Dagger Slash
			{Weapon.WeaponType.Chakram_OH, 8100250}, // Chakram Pierce
			{Weapon.WeaponType.Pistol_OH, 8200600}, // Fire / Reload
			{Weapon.WeaponType.Halberd_2H, 8100320}, // Moon Swipe
			{Weapon.WeaponType.Sword_2H, 8100362}, // Pommel Counter
			{Weapon.WeaponType.Axe_2H, 8100300}, // Execution
			{Weapon.WeaponType.Mace_2H, 8100310}, // Juggernaut
			{Weapon.WeaponType.Spear_2H, 8100340}, // Simeon's Gambit
			{Weapon.WeaponType.FistW_2H, 8201040}, // Prismatic Flurry
			{Weapon.WeaponType.Shield,8100190}, // Shield Charge
			{Weapon.WeaponType.Bow, 8100100} // Evasion Shot
		};
		
		public static bool TryGetSkillID(this Weapon weapon, out int id) {
			Weapon.WeaponType weaponType = weapon.Type;
			if (!SelectedWeaponSkills.ContainsKey(weaponType)) {
				id = 0;
				WeaponSkillKeys.Log.LogDebug($"Weapon {weaponType} does not have a skill");
				return false;
			}
			id = SelectedWeaponSkills[weaponType];
			return true;
		}
	}
}