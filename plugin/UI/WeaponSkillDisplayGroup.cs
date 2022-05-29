using UnityEngine;

namespace WeaponSkillKeys.UI {
	public class WeaponSkillDisplayGroup : UIElement {
		private WeaponSkillDisplay mainHandSkillDisplay;
		private WeaponSkillDisplay offHandSkillDisplay;

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

		private WeaponSkillDisplay CreateWeaponSkillDisplay() {
			ItemDisplay itemDisplay = Instantiate(UIUtilities.ItemDisplayPrefab, transform);
			Destroy(itemDisplay.gameObject.GetComponent<ItemDisplay>());
			WeaponSkillDisplay weaponSkillDisplay = itemDisplay.gameObject.AddComponent<WeaponSkillDisplay>();
			Transform displayTransform = itemDisplay.transform;
			displayTransform.ResetLocal();
			itemDisplay.Clear();
			itemDisplay.ShowCooldown = true;
			return weaponSkillDisplay;
		}

		public void UpdateVisibility() {
			mainHandSkillDisplay.UpdateVisibility();
			offHandSkillDisplay.UpdateVisibility();
		}

		public void SetMainHandSkill(Skill skill) {
			mainHandSkillDisplay.SetSkill(skill);
		}

		public void SetOffHandSkill(Skill skill) {
			offHandSkillDisplay.SetSkill(skill);
		}

		public void ClearMainHandSkill() {
			mainHandSkillDisplay.Clear();
		}

		public void ClearOffHandSkill() {
			offHandSkillDisplay.Clear();
		}
	}
}