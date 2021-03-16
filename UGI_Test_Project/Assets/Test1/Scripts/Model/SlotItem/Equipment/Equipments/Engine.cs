namespace UGI_Test_1 {
	public abstract class Engine : Equipment {
		public float Speed { get; protected set; }

		protected Engine(string name, int hp, ShipSlot.Type slotType, float speed) : base(name, hp, slotType) {
			Speed = speed;
		}
	}

	public class SmallEngine : Engine {
		public SmallEngine() : base(nameof(SmallEngine),
				EquipmentConstants.SMALL_ENGINE_HP,
				ShipSlot.Type.Medium,
				EquipmentConstants.SMALL_ENGINE_SPEED) { }
	}

	public class LargeEngine : Engine {
		public LargeEngine() : base(nameof(LargeEngine),
				EquipmentConstants.LARGE_ENGINE_HP,
				ShipSlot.Type.Heavy,
				EquipmentConstants.LARGE_ENGINE_SPEED) { }
	}
}