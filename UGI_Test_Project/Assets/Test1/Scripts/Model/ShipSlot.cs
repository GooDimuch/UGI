using System;

namespace UGI_Test_1 {
	public class ShipSlot : ISlotable {
		public enum Type {
			Heavy,
			Medium,
			Light,
		}

		public SlotItem SlotItem;

		public Type SlotType { get; set; }

		public ShipSlot(Type slotType) { SlotType = slotType; }

		public void Add(SlotItem item) {
			if (item.SlotType > SlotType) { throw new IncorrectSlotTypeException(); }
			SlotItem = item;
		}

		public void Remove() => SlotItem = null;
	}

	public class IncorrectSlotTypeException : Exception {
		public IncorrectSlotTypeException() { }
		public IncorrectSlotTypeException(string message) : base(message) { }
	}
}