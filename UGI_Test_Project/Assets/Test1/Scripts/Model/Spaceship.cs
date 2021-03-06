using System.Collections.Generic;

namespace UGI_Test_1 {
	public abstract class Spaceship : IUpgradable, IDamageable {
		public int HP { get; set; }
		public int Level { get; set; }

		public int AmountWeaponSlots { get; private set; }
		public bool IsEnemy { get; private set; }

		private readonly List<ShipSlot> weaponSlots = new List<ShipSlot>();

		protected Spaceship(int hp, int amountWeaponSlots, bool isEnemy = false) {
			HP = hp;
			AmountWeaponSlots = amountWeaponSlots;
			IsEnemy = isEnemy;

			SetLevel(1);
			CreateWeaponSlots();
		}

		public virtual void SetLevel(int level) { Level = level; }

		public void Upgrade(int addLevel) => SetLevel(Level + addLevel);

		public void TakeDamage(int damage) {
			HP -= damage;
			if (HP < 0) { Die(); }
		}

		public virtual void Die() { }

		private void CreateWeaponSlots() {
			for (var i = 0; i < AmountWeaponSlots; i++) { AddWeaponSlot(ShipSlot.Type.Light); }
		}

		public void AddWeaponSlot(ShipSlot.Type slotType) { weaponSlots.Add(new ShipSlot(slotType)); }
	}
}