using System.Linq;

namespace WeaponSkillKeys.Selector {
	public class TagNameSelector : ItemSelector {
		private readonly string tag;

		public TagNameSelector(string tag) {
			this.tag = tag;
		}

		public bool isEligible(Item item) {
			return item.Tags.Any(tag1 => tag1.TagName == tag);
		}
	}
}