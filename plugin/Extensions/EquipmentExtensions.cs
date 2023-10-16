using System.Collections.Generic;
using WeaponSkillKeys.Selector;

namespace WeaponSkillKeys.Extensions {
	public static class EquipmentExtensions {
		
		// More specific selectors must precede more generic ones
		
		private static readonly List<(ItemSelector, int)> EquipmentSkills = new List<(ItemSelector, int)>{
			////// Mod equipment //////
			// Knives Master
			(new WeaponTypeSelector(Weapon.WeaponType.Sword_1H).And(new TagNameSelector("Knife")), -23035), // Blink Strike
			
			////// Vanilla equipment //////
			(new WeaponTypeSelector(Weapon.WeaponType.Sword_1H), 8100290), // Puncture
			(new WeaponTypeSelector(Weapon.WeaponType.Axe_1H), 8100380), // Talus Cleaver
			(new WeaponTypeSelector(Weapon.WeaponType.Mace_1H), 8100270), // Mace Infusion
			(new WeaponTypeSelector(Weapon.WeaponType.Dagger_OH), 8100072), // Dagger Slash
			(new WeaponTypeSelector(Weapon.WeaponType.Chakram_OH), 8100250), // Chakram Pierce
			(new WeaponTypeSelector(Weapon.WeaponType.Pistol_OH), 8200600), // Fire / Reload
			(new WeaponTypeSelector(Weapon.WeaponType.Halberd_2H), 8100320), // Moon Swipe
			(new WeaponTypeSelector(Weapon.WeaponType.Sword_2H), 8100362), // Pommel Counter
			(new WeaponTypeSelector(Weapon.WeaponType.Axe_2H), 8100300), // Execution
			(new WeaponTypeSelector(Weapon.WeaponType.Mace_2H), 8100310), // Juggernaut
			(new WeaponTypeSelector(Weapon.WeaponType.Spear_2H), 8100340), // Simeon's Gambit
			(new WeaponTypeSelector(Weapon.WeaponType.FistW_2H), 8201040), // Prismatic Flurry
			(new WeaponTypeSelector(Weapon.WeaponType.Shield), 8100190), // Shield Charge
			(new WeaponTypeSelector(Weapon.WeaponType.Bow), 8100100), // Evasion Shot
			(new IKModeSelector(Equipment.IKMode.Lantern).Or(new IKModeSelector(Equipment.IKMode.Torch)), 8100090), // Flamethrower
			(new IKModeSelector(Equipment.IKMode.Lexicon), 8100220) // Rune: Shim 
		};
		
		private static readonly List<(ItemSelector, ItemSelector, int)> DualEquipmentSkills = new List<(ItemSelector, ItemSelector, int)> {
			////// Mod equipment //////
			// Knives Master
			(new WeaponTypeSelector(Weapon.WeaponType.Dagger_OH), new WeaponTypeSelector(Weapon.WeaponType.Sword_1H).And(new TagNameSelector("Knife")), -23041) // Dual Slash
		};

		public static bool TryGetSkillID(this Equipment equipment, out int id) {
			(ItemSelector, int) weaponSkill = EquipmentSkills.Find(tuple => tuple.Item1.isEligible(equipment));
			if (weaponSkill.Equals(default((ItemSelector, int)))){
				id = 0;
				WeaponSkillKeys.Log.LogDebug($"Equipment {equipment} does not have a skill");
				return false;
			}
			
			id = weaponSkill.Item2;
			return true;
		}

		public static bool TryGetSkillID(this Equipment equipment, Equipment otherEquipment, out int id) {
			if (!otherEquipment) {
				return TryGetSkillID(equipment, out id);
			}
			(ItemSelector, ItemSelector, int) weaponSkill = DualEquipmentSkills.Find(tuple => tuple.Item1.isEligible(equipment) && tuple.Item2.isEligible(otherEquipment));
			if (weaponSkill.Equals(default((ItemSelector, ItemSelector, int)))){
				return TryGetSkillID(equipment, out id);
			}
			
			id = weaponSkill.Item3;
			return true;
		}
	}
}