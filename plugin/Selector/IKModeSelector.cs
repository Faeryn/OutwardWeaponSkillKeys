namespace WeaponSkillKeys.Selector {
	public class IKModeSelector : ItemSelector {
		private readonly Equipment.IKMode ikMode;

		public IKModeSelector(Equipment.IKMode ikMode) {
			this.ikMode = ikMode;
		}

		public bool isEligible(Item item) {
			Equipment equipment = item as Equipment;
			return equipment && equipment.IKType == ikMode;
		}
	}
}