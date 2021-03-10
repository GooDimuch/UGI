using System.Collections.Generic;
using System.Linq;

namespace UGI_Test_1 {
	public class ComboSlotItem : SlotItem {
		public List<SlotItem> Items { get; } = new List<SlotItem>();

		public ComboSlotItem(string name, int hp, ShipSlot.Type slotType) : base(name, hp, slotType) { }

		public override string ToString() {
			return $"{{{nameof(Name)}: {Name}, " +
					$"{nameof(SlotType)}: {SlotType}, " +
					$"{nameof(HP)}: {HP}, " +
					$"\n\t{nameof(Items)}: [{string.Join(", \n\t", Items)}]}}";
			var obj = this;
			var props = GetType()
					.GetProperties()
					.Select(info =>
							info.Name == "Items" ? $"[{string.Join(", ", Items)}]" : $"{info.Name}: {info.GetValue(obj)}");
			return $"{{{string.Join(", ", props)}}}";
		}
	}
}