namespace UGI_Test_1 {
	public abstract class Weapon : IUpgradable, IDamageable, ISlotable {
		public int HP { get; set; }
		public int Level { get; set; }
		public float Damage { get; protected set; }
		public float FireRate { get; protected set; }
		public int ClipSize { get; protected set; }
		public float ReloadTime { get; protected set; }
		public Ammo.Type AmmoType { get; protected set; }
		public ShipSlot.Type SlotType { get; set; }

		protected Weapon(int hp,
				float damage,
				float fireRate,
				int clipSize,
				float reloadTime,
				ShipSlot.Type slotType,
				Ammo.Type ammoType) {
			HP = hp;
			Damage = damage;
			FireRate = fireRate;
			ClipSize = clipSize;
			ReloadTime = reloadTime;
			SlotType = slotType;
			AmmoType = ammoType;

			SetLevel(1);
		}

		public virtual void SetLevel(int level) { Level = level; }

		public void Upgrade(int addLevel) => SetLevel(Level + addLevel);

		public void TakeDamage(int damage) { HP -= damage; }

		public virtual void Die() { }

		public virtual void Add(Weapon weapon) { }
	}

	public abstract class WeaponDecorator : Weapon {
		protected Weapon Weapon;

		protected WeaponDecorator(int hp,
				float damage,
				float fireRate,
				int clipSize,
				float reloadTime,
				ShipSlot.Type slotType,
				Ammo.Type ammoType,
				Weapon weapon) : base(hp, damage, fireRate, clipSize, reloadTime, slotType, ammoType) {
			Weapon = weapon;
		}
	}
}