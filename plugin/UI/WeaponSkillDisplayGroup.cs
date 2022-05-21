using UnityEngine;

namespace WeaponSkillKeys.UI {
	public class WeaponSkillDisplayGroup : UIElement {
		private ItemDisplay mainHandSkillDisplay;
		private ItemDisplay offHandSkillDisplay;

		protected override void AwakeInit() {
			mainHandSkillDisplay = CreateWeaponSkillDisplay();
			offHandSkillDisplay = CreateWeaponSkillDisplay();
			UpdatePosition();
		}
		
		public void UpdatePosition() {
			transform.localPosition = new Vector3(WeaponSkillKeys.WeaponSkillKeysPosX.Value, -WeaponSkillKeys.WeaponSkillKeysPosY.Value, 0f);
			mainHandSkillDisplay.transform.localPosition = new Vector3(WeaponSkillKeys.MainHandSkillPosX.Value, -WeaponSkillKeys.MainHandSkillPosY.Value, 0f);
			offHandSkillDisplay.transform.localPosition = new Vector3(WeaponSkillKeys.OffHandSkillPosX.Value, -WeaponSkillKeys.OffHandSkillPosY.Value, 0f);
		}

		private ItemDisplay CreateWeaponSkillDisplay() {
			ItemDisplay itemDisplay = Instantiate(UIUtilities.ItemDisplayPrefab, transform);
			Transform displayTransform = itemDisplay.transform;
			displayTransform.ResetLocal();
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