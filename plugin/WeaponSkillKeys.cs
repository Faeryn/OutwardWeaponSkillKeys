using System;
using BepInEx;
using BepInEx.Logging;
using SideLoader;

namespace WeaponSkillKeys {
	[BepInDependency(SL.GUID, BepInDependency.DependencyFlags.HardDependency)]
	[BepInPlugin(GUID, NAME, VERSION)]
	public class WeaponSkillKeys : BaseUnityPlugin {
		public const string GUID = "faeryn.weaponskillkeys";
		public const string NAME = "WeaponSkillKeys";
		public const string VERSION = "1.0.0";
		internal static ManualLogSource Log;

		public static string KEY_MAINHAND_SKILL = "Main Weapon Skill";
		public static string KEY_OFFHAND_SKILL = "Off-hand Skill";

		private WeaponSkillManager weaponSkillManager;

		internal void Awake() {
			Log = this.Logger;
			Log.LogMessage($"Starting {NAME} {VERSION}");
			InitializeKeybindings();
			weaponSkillManager = new WeaponSkillManager();
		}

		public void InitializeKeybindings() {
			CustomKeybindings.AddAction(KEY_MAINHAND_SKILL, KeybindingsCategory.CustomKeybindings, ControlType.Keyboard);
			CustomKeybindings.AddAction(KEY_OFFHAND_SKILL, KeybindingsCategory.CustomKeybindings, ControlType.Keyboard);
		}

		private void Update() {
			int playerID;
			if (CustomKeybindings.GetKeyDown(KEY_MAINHAND_SKILL, out playerID)) {
				weaponSkillManager.UseMainHandSkill(GetLocalCharacter(playerID));
			} else if (CustomKeybindings.GetKeyDown(KEY_OFFHAND_SKILL, out playerID)) {
				weaponSkillManager.UseOffHandSkill(GetLocalCharacter(playerID));
			} 
		}

		private Character GetLocalCharacter(int playerID) {
			return SplitScreenManager.Instance.LocalPlayers[playerID].AssignedCharacter;
		}
	}
}