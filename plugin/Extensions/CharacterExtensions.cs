
using System.Collections.Generic;

namespace WeaponSkillKeys.Extensions {
	public static class CharacterExtensions {

		public static bool TryGetLearnedSkill(this Character character, int id, out Skill skill) {
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

		private static void UseWeaponSkill(Character character, Equipment equipment, Equipment otherEquipment, bool isSpecial = false) {
			if (!TryGetWeaponSkill(character, equipment, otherEquipment, out Skill skill)) {
				return;
			}
			
			if (equipment is Weapon && WeaponSkillKeys.HoldToReload.Value && skill.ItemID == 8200600 && isSpecial != ((Weapon)equipment).IsEmpty) { // Fire/Reload
				return;
			}
			
			WeaponSkillKeys.Log.LogDebug($"Using skill: {skill}");
			skill.TryQuickSlotUse();
		}
		
		private static bool TryGetWeaponSkill(Character character, Equipment equipment, Equipment otherEquipment, out Skill skill) {
			if (character == null || equipment == null || !equipment.TryGetSkillID(otherEquipment, out int id)) {
				skill = null;
				return false;
			}
			return TryGetLearnedSkill(character, id, out skill);
		}

		public static bool TryGetMainHandSkill(this Character character, out Skill skill) {
			return TryGetWeaponSkill(character, character.CurrentWeapon, character.LeftHandEquipment, out skill);
		}

		public static bool TryGetOffHandSkill(this Character character, out Skill skill) {
			return TryGetWeaponSkill(character, character.LeftHandEquipment, character.CurrentWeapon, out skill);
		}

		public static void UseMainHandSkill(this Character character) {
			UseWeaponSkill(character, character.CurrentWeapon, character.LeftHandEquipment);
		}

		public static void UseOffHandSkill(this Character character) {
			UseWeaponSkill(character, character.LeftHandEquipment, character.CurrentWeapon);
		}

		public static void UseSpecialOffHandSkill(this Character character) {
			UseWeaponSkill(character, character.LeftHandWeapon, character.CurrentWeapon, true);
		}
	}
}