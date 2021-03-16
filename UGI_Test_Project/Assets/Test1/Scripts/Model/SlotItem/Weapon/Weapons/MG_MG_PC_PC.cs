namespace UGI_Test_1 {
	public class MG_MG_PC_PC : ComboSlotItem {
		public MG_MG_PC_PC() : base(nameof(MG_MG_PC_PC),
				100,
				ShipSlot.Type.Heavy,
				new MachineGun(),
				new MachineGun(),
				new PlasmaCannon(),
				new PlasmaCannon()) { }
	}
}