namespace WeaponSkillKeys.Selector {
	public static class ItemSelectorExtensions {
		
		public static ItemSelector And(this ItemSelector firstSelector, ItemSelector secondSelector) {
			return new ItemSelectorFunction(item => firstSelector.isEligible(item) && secondSelector.isEligible(item));
		}
		
		public static ItemSelector Or(this ItemSelector firstSelector, ItemSelector secondSelector) {
			return new ItemSelectorFunction(item => firstSelector.isEligible(item) || secondSelector.isEligible(item));
		}
		
	}
}