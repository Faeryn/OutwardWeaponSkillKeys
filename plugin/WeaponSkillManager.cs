
using System.Collections.Generic;

namespace WeaponSkillKeys {
	public class WeaponSkillManager {

		private readonly Dictionary<Weapon.WeaponType, int> weaponSkills = new Dictionary<Weapon.WeaponType, int>();

		public WeaponSkillManager() {
			InitializeWeaponSkills();
		}

		private void InitializeWeaponSkills() {
			weaponSkills[Weapon.WeaponType.Sword_1H] = 8100290; // Puncture
			weaponSkills[Weapon.WeaponType.Axe_1H] = 8100380; // Talus Cleaver
			weaponSkills[Weapon.WeaponType.Mace_1H] = 8100270; // Mace Infusion
			weaponSkills[Weapon.WeaponType.Dagger_OH] = 8100072; // Dagger Slash
			weaponSkills[Weapon.WeaponType.Chakram_OH] = 8100250; // Chakram Pierce
			weaponSkills[Weapon.WeaponType.Pistol_OH] = 8200600; //  Fire / Reload
			weaponSkills[Weapon.WeaponType.Halberd_2H] = 8100320; // Moon Swipe
			weaponSkills[Weapon.WeaponType.Sword_2H] = 8100362; // Pommel Counter
			weaponSkills[Weapon.WeaponType.Axe_2H] = 8100300; // Execution
			weaponSkills[Weapon.WeaponType.Mace_2H] = 8100310; // Juggernaut
			weaponSkills[Weapon.WeaponType.Spear_2H] = 8100340; // Simeon's Gambit
			weaponSkills[Weapon.WeaponType.FistW_2H] = 8201040; // Prismatic Flurry
			weaponSkills[Weapon.WeaponType.Shield] = 8100190; // Shield Charge
			weaponSkills[Weapon.WeaponType.Bow] = 8100100; // Evasion Shot
		}

		private bool TryGetLearnedSkill(Character character, int id, out Skill skill) {
			Item item = ((List<Item>)character.Inventory.SkillKnowledge.GetLearnedItems()).FindItemFromItemID(id);
			if (item == null) {
				skill = null;
				WeaponSkillKeys.Log.LogDebug($"Skill not learned: {id}");
				return false;
			}
			skill = item as Skill;
			if (skill == null) {
				WeaponSkillKeys.Log.LogError($"{id} is not a skill");
				return false;
			}
			return true;
		}

		private bool TryGetSkillIDByWeapon(Weapon weapon, out int id) {
			if (weapon == null) {
				id = 0;
				WeaponSkillKeys.Log.LogDebug("No weapon equipped");
				return false;
			}
			Weapon.WeaponType weaponType = weapon.Type;
			if (!weaponSkills.ContainsKey(weaponType)) {
				id = 0;
				WeaponSkillKeys.Log.LogDebug($"Weapon {weaponType} does not have a skill");
				return false;
			}
			id = weaponSkills[weaponType];
			return true;
		}

		private void UseWeaponSkill(Character character, Weapon weapon) {
			if (!TryGetSkillIDByWeapon(weapon, out int id)) {
				return;
			}
			if (!TryGetLearnedSkill(character, id, out Skill skill)) {
				return;
			}
			WeaponSkillKeys.Log.LogDebug($"Using skill: {skill}");
			skill.TryQuickSlotUse();
		}

		public void UseMainHandSkill(Character character) {
			UseWeaponSkill(character, character.CurrentWeapon);
		}

		public void UseOffHandSkill(Character character) {
			UseWeaponSkill(character, character.LeftHandWeapon);
		}
	}
}