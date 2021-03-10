using System;

namespace UGI_Test_1 {
	public class ShipSlot : ISlotable {
		public enum Type {
			Light,
			Medium,
			Heavy,
		}

		public SlotItem SlotItem;

		public Type SlotType { get; set; }

		public ShipSlot(Type slotType) { SlotType = slotType; }

		public void Add(SlotItem item) {
			if (item.SlotType > SlotType) { throw new IncorrectSlotTypeException(); }
			SlotItem = item;
		}

		public void Remove() => SlotItem = null;

		public override string ToString() { return $"{SlotType} contain {SlotItem?.ToString() ?? "null"}"; }
	}

	public class IncorrectSlotTypeException : Exception {
		public IncorrectSlotTypeException() { }
		public IncorrectSlotTypeException(string message) : base(message) { }
	}
}