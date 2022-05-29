using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SideLoader;
using WeaponSkillKeys.Extensions;
using WeaponSkillKeys.UI;

namespace WeaponSkillKeys {
	[BepInDependency(SL.GUID, BepInDependency.DependencyFlags.HardDependency)]
	[BepInPlugin(GUID, NAME, VERSION)]
	public class WeaponSkillKeys : BaseUnityPlugin {
		public const string GUID = "faeryn.weaponskillkeys";
		public const string NAME = "WeaponSkillKeys";
		public const string DISPLAY_NAME = "Weapon Skill Keys";
		public const string VERSION = "1.3.1";
		internal static ManualLogSource Log;

		public static ConfigEntry<float> WeaponSkillKeysPosX;
		public static ConfigEntry<float> WeaponSkillKeysPosY;
		public static ConfigEntry<float> MainHandSkillPosX;
		public static ConfigEntry<float> MainHandSkillPosY;
		public static ConfigEntry<float> OffHandSkillPosX;
		public static ConfigEntry<float> OffHandSkillPosY;
		public static ConfigEntry<bool> HideEmpty;
		public static ConfigEntry<bool> HoldToReload;

		private WeaponSkillKeysManager keyManager = new WeaponSkillKeysManager();
		
		internal void Awake() {
			Log = this.Logger;
			Log.LogMessage($"Starting {NAME} {VERSION}");
			keyManager.InitializeKeybindings();
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
			HideEmpty = Config.Bind(DISPLAY_NAME, "Hide Empty", false, "Hides empty weapon skill displays (if there is no weapon in the slot or the skill is not known)");
			HideEmpty.SettingChanged += (sender, args) => {
				ApplyToWeaponSkillDisplays(wsd => wsd.UpdateVisibility());
			};
			HoldToReload = Config.Bind(DISPLAY_NAME, "Hold Fire/Reload button to reload", true, "Note: Only works with the weapon skill key. If you bind the Fire/Reload skill to a quickslot, it will work as in vanilla.");
			BindPosSetting("Weapon skills display", 0, 480, out WeaponSkillKeysPosX, out WeaponSkillKeysPosY);
			BindPosSetting("Main Weapon skill display", 150, 0, out MainHandSkillPosX, out MainHandSkillPosY);
			BindPosSetting("Off-hand skill display", -150, 0, out OffHandSkillPosX, out OffHandSkillPosY);
		}
		
		public static void ApplyToWeaponSkillDisplays(Action<WeaponSkillDisplayGroup> func) {
			foreach (Character character in CharacterManager.Instance.Characters.Values) {
				if (character != null || character.CharacterUI != null || character.CharacterUI.GetWeaponSkillDisplayGroup() != null) {
					func(character.CharacterUI.GetWeaponSkillDisplayGroup());
				}
			}
		}

		private void Update() {
			keyManager.Update();
		}

	}
}