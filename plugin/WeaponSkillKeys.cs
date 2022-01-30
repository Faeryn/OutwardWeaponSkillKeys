using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SideLoader;
using WeaponSkillKeys.Extensions;

namespace WeaponSkillKeys {
	[BepInDependency(SL.GUID, BepInDependency.DependencyFlags.HardDependency)]
	[BepInPlugin(GUID, NAME, VERSION)]
	public class WeaponSkillKeys : BaseUnityPlugin {
		public const string GUID = "faeryn.weaponskillkeys";
		public const string NAME = "WeaponSkillKeys";
		public const string VERSION = "1.1.0";
		internal static ManualLogSource Log;

		public static string KEY_MAINHAND_SKILL = "Main Weapon Skill";
		public static string KEY_OFFHAND_SKILL = "Off-hand Skill";
		
		internal void Awake() {
			Log = this.Logger;
			Log.LogMessage($"Starting {NAME} {VERSION}");
			InitializeKeybindings();
			new Harmony(GUID).PatchAll();
		}

		public void InitializeKeybindings() {
			CustomKeybindings.AddAction(KEY_MAINHAND_SKILL, KeybindingsCategory.CustomKeybindings, ControlType.Keyboard);
			CustomKeybindings.AddAction(KEY_OFFHAND_SKILL, KeybindingsCategory.CustomKeybindings, ControlType.Keyboard);
		}

		private void Update() {
			int playerID;
			if (CustomKeybindings.GetKeyDown(KEY_MAINHAND_SKILL, out playerID)) {
				UseWeaponSkill(playerID, CharacterExtensions.UseMainHandSkill);
			} else if (CustomKeybindings.GetKeyDown(KEY_OFFHAND_SKILL, out playerID)) {
				UseWeaponSkill(playerID, CharacterExtensions.UseOffHandSkill);
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