using System.Collections.Generic;
using WeaponSkillKeys.Selector;

namespace WeaponSkillKeys.Extensions {
	public static class  EquipmentExtensions {
		
		private static readonly List<(ItemSelector, int)> WeaponSkills = new List<(ItemSelector, int)>{
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
			(new IKModeSelector(Equipment.IKMode.Lantern).Or(new IKModeSelector(Equipment.IKMode.Torch)), 8100090) // Flamethrower
		};

		public static bool TryGetSkillID(this Equipment equipment, out int id) {
			(ItemSelector, int) weaponSkill = WeaponSkills.Find(tuple => tuple.Item1.isEligible(equipment));
			if (weaponSkill.Equals(default((ItemSelector, int)))){
				id = 0;
				WeaponSkillKeys.Log.LogDebug($"Equipment {equipment} does not have a skill");
				return false;
			}
			
			id = weaponSkill.Item2;

			return true;
		}
	}
}