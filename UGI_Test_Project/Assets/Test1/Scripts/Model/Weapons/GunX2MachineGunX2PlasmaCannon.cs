using System.Collections.Generic;

namespace UGI_Test_1 {
	public class GunX2MachineGunX2PlasmaCannon : SlotItem {
		public List<SlotItem> items = new List<SlotItem>();

		public GunX2MachineGunX2PlasmaCannon() : base(nameof(GunX2MachineGunX2PlasmaCannon),
				100,
				ShipSlot.Type.Heavy) {
			items.Add(new LargeEngine());
			items.Add(new MachineGun());
			items.Add(new PlasmaCannon());
		}
	}
}