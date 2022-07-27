namespace WeaponSkillKeys.Selector {
	public class TagSelector : ItemSelector {
		private readonly Tag tag;

		public TagSelector(Tag tag) {
			this.tag = tag;
		}

		public bool isEligible(Item item) {
			return item.HasTag(tag);
		}
	}
}