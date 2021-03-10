namespace UGI_Test_1 {
	public class MG_PC_ES : ComboSlotItem {
		public MG_PC_ES() : base(nameof(MG_PC_ES), 100, ShipSlot.Type.Heavy) {
			Items.Add(new MG_MG_PC_PC());
			Items.Add(new PlasmaCannon());
			Items.Add(new EnergyShield());
		}
	}
}