using System;
using BepInEx;
using BepInEx.Configuration;
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
		public const string DISPLAY_NAME = "Weapon Skill Keys";
		public const string VERSION = "1.2.0";
		internal static ManualLogSource Log;

		public static string KEY_MAINHAND_SKILL = "Main Weapon Skill";
		public static string KEY_OFFHAND_SKILL = "Off-hand Skill";
		
		public static ConfigEntry<float> WeaponSkillKeysPosX;
		public static ConfigEntry<float> WeaponSkillKeysPosY;
		public static ConfigEntry<float> MainHandSkillPosX;
		public static ConfigEntry<float> MainHandSkillPosY;
		public static ConfigEntry<float> OffHandSkillPosX;
		public static ConfigEntry<float> OffHandSkillPosY;
		
		internal void Awake() {
			Log = this.Logger;
			Log.LogMessage($"Starting {NAME} {VERSION}");
			InitializeKeybindings();
			InitializeConfig();
			new Harmony(GUID).PatchAll();
		}

		private void BindPosSetting(string settingName, float defX, float defY, out ConfigEntry<float> configEntryX, out ConfigEntry<float> configEntryY) {
			configEntryX = Config.Bind(DISPLAY_NAME, $"{settingName} position X", defX, $"{settingName} horizontal position");
			configEntryX.SettingChanged += (sender, args) => {
				ApplyToWeaponSkillDisplays(wsd=>wsd.UpdatePosition());
			};
			configEntryY = Config.Bind(DISPLAY_NAME, $"{settingName} position Y", defY, $"{settingName} vertical position");
			configEntryY.SettingChanged += (sender, args) => {
				ApplyToWeaponSkillDisplays(wsd=>wsd.UpdatePosition());
			};
		}

		private void InitializeConfig() {
			BindPosSetting("Weapon skills display", 0, 480, out WeaponSkillKeysPosX, out WeaponSkillKeysPosY);
			BindPosSetting("Main Weapon skill display", 150, 0, out MainHandSkillPosX, out MainHandSkillPosY);
			BindPosSetting("Off-hand skill display", -150, 0, out OffHandSkillPosX, out OffHandSkillPosY);
		}
		
		public static void ApplyToWeaponSkillDisplays(Action<WeaponSkillDisplay> func) {
			foreach (Character character in CharacterManager.Instance.Characters.Values) {
				if (character != null || character.CharacterUI != null || character.CharacterUI.GetWeaponSkillDisplay() != null) {
					func(character.CharacterUI.GetWeaponSkillDisplay());
				}
			}
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