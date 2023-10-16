using System.Collections.Generic;

namespace WeaponSkillKeys.Extensions {
	public static class RewiredInputsExtensions {
		public static float GetHeldTime(this RewiredInputs rewiredInputs, string actionName) {
			Dictionary<string, float> previousLastActiveTime = rewiredInputs.m_previousLastActiveTime;
			
			if (!previousLastActiveTime.ContainsKey(actionName)) {
				previousLastActiveTime.Add(actionName, 0.0f);
			}
			
			return previousLastActiveTime[actionName];
		}
	}
}