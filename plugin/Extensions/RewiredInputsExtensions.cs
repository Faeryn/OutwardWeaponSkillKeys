using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace WeaponSkillKeys.Extensions {
	public static class RewiredInputsExtensions {
		private static readonly FieldInfo rewiredInputs_previousLastActiveTime = AccessTools.Field(typeof(RewiredInputs), "m_previousLastActiveTime");

		public static float GetHeldTime(this RewiredInputs rewiredInputs, string actionName) {
			Dictionary<string, float> previousLastActiveTime = (Dictionary<string, float>) rewiredInputs_previousLastActiveTime.GetValue(rewiredInputs);
			
			if (!previousLastActiveTime.ContainsKey(actionName)) {
				previousLastActiveTime.Add(actionName, 0.0f);
			}
			
			return previousLastActiveTime[actionName];
		}
	}
}