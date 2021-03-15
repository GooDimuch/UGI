namespace UGI_Test_1 {
	public class MG_PC_ES : ComboSlotItem {
		public MG_PC_ES() : base(nameof(MG_PC_ES),
				100,
				ShipSlot.Type.Heavy,
				new MG_MG_PC_PC(),
				new PlasmaCannon(),
				new EnergyShield()) { }
	}
}