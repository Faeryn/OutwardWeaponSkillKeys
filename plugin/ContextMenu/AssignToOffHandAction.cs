using UnityEngine;

namespace WeaponSkillKeys.ContextMenu {
	public class AssignToOffHandAction : ContextMenuAction {
		public AssignToOffHandAction(int id) : base(id, "Assign to Off-hand") {
		}

		public override bool IsActive(GameObject pointerPress) {
			return true;
		}

		public override void ExecuteAction(ContextMenuOptions contextMenu) {
			ItemDisplayOptionPanel itemDisplayOptionPanel = contextMenu as ItemDisplayOptionPanel;
			if (itemDisplayOptionPanel != null) {
				ItemDisplay activatedItemDisplay = itemDisplayOptionPanel.m_activatedItemDisplay;
				if (activatedItemDisplay!= null && !activatedItemDisplay.IsEmpty) {
					///TryAssignToOffHand(activatedItemDisplay.CharacterUI.CraftingMenu, activatedItemDisplay.LastRefItemID);
				}
			}
		}
		
	}
}