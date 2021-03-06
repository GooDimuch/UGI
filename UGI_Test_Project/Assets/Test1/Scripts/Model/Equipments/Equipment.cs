namespace UGI_Test_1 {
	public abstract class Equipment : IUpgradable, IDamageable, ISlotable {
		public int HP { get; set; }
		public int Level { get; set; }
		public ShipSlot.Type SlotType { get; set; }

		protected Equipment(int hp, ShipSlot.Type slotType) {
			HP = hp;
			SlotType = slotType;

			SetLevel(1);
		}

		public virtual void SetLevel(int level) { Level = level; }

		public void Upgrade(int addLevel) => SetLevel(Level + addLevel);

		public void TakeDamage(int damage) { HP -= damage; }

		public virtual void Die() { }
	}

	public abstract class Engine : Equipment {
		public float Speed { get; private set; }

		protected Engine(int hp, ShipSlot.Type slotType, float speed) : base(hp, slotType) { Speed = speed; }
	}

	public class SmallEngine : Engine {
		public SmallEngine() : base(EquipmentConstants.SMALL_ENGINE_HP,
				ShipSlot.Type.Medium,
				EquipmentConstants.SMALL_ENGINE_SPEED) { }
	}

	public class LargeEngine : Engine {
		public LargeEngine() : base(EquipmentConstants.LARGE_ENGINE_HP,
				ShipSlot.Type.Heavy,
				EquipmentConstants.LARGE_ENGINE_SPEED) { }
	}
}