using System;

namespace WeaponSkillKeys.Selector {
	public class ItemSelectorFunction : ItemSelector {
		private readonly Predicate<Item> predicate;

		public ItemSelectorFunction(Predicate<Item> predicate) {
			this.predicate = predicate;
		}

		public bool isEligible(Item item) {
			return predicate.Invoke(item);
		}
	}
}