using System.Collections.Generic;

namespace UGI_Test_1 {
	public interface ISlotable {
		ShipSlot.Type SlotType { get; set; }
	}

	public class ShipSlot : ISlotable {
		public enum Type {
			Heavy,
			Medium,
			Light,
		}

		public List<ISlotable> slotables = new List<ISlotable>();

		public Type SlotType { get; set; }

		public ShipSlot(Type slotType) { SlotType = slotType; }
	}
}