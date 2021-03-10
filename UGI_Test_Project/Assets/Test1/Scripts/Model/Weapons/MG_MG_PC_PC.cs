namespace UGI_Test_1 {
	public class MG_MG_PC_PC : ComboSlotItem {
		public MG_MG_PC_PC() : base(nameof(MG_MG_PC_PC),
				100,
				ShipSlot.Type.Heavy) {
			Items.Add(new MachineGun());
			Items.Add(new MachineGun());
			Items.Add(new PlasmaCannon());
			Items.Add(new PlasmaCannon());
		}
	}
}