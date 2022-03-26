namespace UGI_Test.UGI_Test_1 {
	public abstract class Weapon : SlotItem, IUpgradable {
		public int Level { get; set; }
		public float Damage { get; protected set; }
		public float FireRate { get; protected set; }
		public int ClipSize { get; protected set; }
		public float ReloadTime { get; protected set; }
		public Ammo.Type AmmoType { get; protected set; }

		protected Weapon(string name,
				int hp,
				float damage,
				float fireRate,
				int clipSize,
				float reloadTime,
				ShipSlot.Type slotType,
				Ammo.Type ammoType) : base(name, hp, slotType) {
			Damage = damage;
			FireRate = fireRate;
			ClipSize = clipSize;
			ReloadTime = reloadTime;
			AmmoType = ammoType;
			Level = Constants.DEFAULT_LEVEL;
		}

		public virtual void SetLevel(int level) { Level = level; }

		public void Upgrade(int addLevel) => SetLevel(Level + addLevel);
	}
}