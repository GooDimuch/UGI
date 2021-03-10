namespace UGI_Test_1 {
	public class HpRegenerator : Equipment {
		public float RegenPerTic { get; }
		public HpRegenerator() : this(10) { }

		public HpRegenerator(float regenPerTic) : base(nameof(HpRegenerator), 100, ShipSlot.Type.Light) {
			RegenPerTic = regenPerTic;
		}
	}
}