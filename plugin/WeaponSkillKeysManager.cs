using System;
using SideLoader;
using WeaponSkillKeys.Extensions;

namespace WeaponSkillKeys {
	public class WeaponSkillKeysManager {
		public static string KEY_MAINHAND_SKILL = "Main Weapon Skill";
		public static string KEY_OFFHAND_SKILL = "Off-hand Skill";
		public static float HOLD_TIME = 1.0f;
		
		public void InitializeKeybindings() {
			CustomKeybindings.AddAction(KEY_MAINHAND_SKILL, KeybindingsCategory.CustomKeybindings, ControlType.Both);
			CustomKeybindings.AddAction(KEY_OFFHAND_SKILL, KeybindingsCategory.CustomKeybindings, ControlType.Both);
		}
		
		public void Update() {
			int playerID;
			if (CustomKeybindings.GetKeyDown(KEY_MAINHAND_SKILL, out playerID)) {
				UseWeaponSkill(playerID, CharacterExtensions.UseMainHandSkill);
			} else if (CustomKeybindings.GetKeyDown(KEY_OFFHAND_SKILL, out playerID)) {
				UseWeaponSkill(playerID, CharacterExtensions.UseOffHandSkill);
			}

			if (WeaponSkillKeys.HoldToReload.Value && CustomKeybindings.GetKey(KEY_OFFHAND_SKILL, out playerID)) {
				foreach (RewiredInputs rewiredInputs in CustomKeybindings.PlayerInputManager.Values) {
					float holdTime = rewiredInputs.GetHeldTime(KEY_OFFHAND_SKILL);
					if (holdTime >= HOLD_TIME && holdTime <= HOLD_TIME+0.2f) {
						// TODO Make this a latch instead of a quick and dirty solution (this could theoretically not trigger if the player has less than 5 FPS)
						UseWeaponSkill(playerID, CharacterExtensions.UseSpecialOffHandSkill);
					}
				}
			}
		}

		private void UseWeaponSkill(int playerID, Action<Character> action) {
			Character character = GetLocalCharacter(playerID);
			if (character != null) {
				action(character);
			}
		}

		private Character GetLocalCharacter(int playerID) {
			return SplitScreenManager.Instance.LocalPlayers[playerID].AssignedCharacter;
		}
	}
}