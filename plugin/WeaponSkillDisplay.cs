using UnityEngine;

namespace WeaponSkillKeys {
	public class WeaponSkillDisplay : UIElement {
		private ItemDisplay mainHandSkillDisplay;
		private ItemDisplay offHandSkillDisplay;

		protected override void AwakeInit() {
			mainHandSkillDisplay = CreateWeaponSkillDisplay(new Vector3(150, -480, 0));
			offHandSkillDisplay = CreateWeaponSkillDisplay(new Vector3(-150, -480, 0));
		}

		private ItemDisplay CreateWeaponSkillDisplay(Vector3 position) {
			ItemDisplay itemDisplay = Instantiate(UIUtilities.ItemDisplayPrefab, transform);
			Transform displayTransform = itemDisplay.transform;
			displayTransform.ResetLocal();
			displayTransform.localPosition = position;
			itemDisplay.Clear();
			itemDisplay.ShowCooldown = true;
			return itemDisplay;
		}

		public void SetMainHandSkill(Skill skill) {
			mainHandSkillDisplay.SetReferencedItem(skill);
		}

		public void SetOffHandSkill(Skill skill) {
			offHandSkillDisplay.SetReferencedItem(skill);
		}

		public void ClearMainHandSkill() {
			mainHandSkillDisplay.Clear();
		}

		public void ClearOffHandSkill() {
			offHandSkillDisplay.Clear();
		}
	}
}