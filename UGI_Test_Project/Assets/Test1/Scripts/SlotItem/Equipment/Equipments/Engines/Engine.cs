namespace UGI_Test_1 {
	public abstract class Engine : Equipment {
		public float Speed { get; protected set; }

		protected Engine(string name, int hp, ShipSlot.Type slotType, float speed) : base(name, hp, slotType) {
			Speed = speed;
		}
	}
}