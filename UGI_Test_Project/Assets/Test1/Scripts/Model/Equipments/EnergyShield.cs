namespace UGI_Test_1 {
	public class EnergyShield : Equipment {
		public float PlasmaBeamResist { get; }

		public EnergyShield() : this(20) { }

		public EnergyShield(float plasmaBeamResist) : base(nameof(EnergyShield), 100, ShipSlot.Type.Medium) {
			PlasmaBeamResist = plasmaBeamResist;
		}
	}
}