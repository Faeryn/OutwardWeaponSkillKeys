namespace WeaponSkillKeys.Selector {
	public class WeaponTypeSelector : ItemSelector {
		private readonly Weapon.WeaponType weaponType;

		public WeaponTypeSelector(Weapon.WeaponType weaponType) {
			this.weaponType = weaponType;
		}

		public bool isEligible(Item item) {
			Weapon weapon = item as Weapon;
			return weapon && weapon.Type == weaponType;
		}
	}
}