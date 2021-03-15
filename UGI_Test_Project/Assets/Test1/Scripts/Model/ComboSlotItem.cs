﻿using System.Collections.Generic;

namespace UGI_Test_1 {
	public abstract class ComboSlotItem : SlotItem {
		private readonly List<SlotItem> _items = new List<SlotItem>();
		public IReadOnlyList<SlotItem> Items => _items;

		protected ComboSlotItem(string name, int hp, ShipSlot.Type slotType, params SlotItem[] items) : base(name,
				hp,
				slotType) {
			_items.AddRange(items);
		}

		public override string ToString() {
			return $"{{{nameof(Name)}: {Name}, " +
					$"{nameof(SlotType)}: {SlotType}, " +
					$"{nameof(HP)}: {HP}, " +
					$"\n\t{nameof(Items)}: [{string.Join(", \n\t", Items)}]}}";
			// var obj = this;
			// var props = GetType()
			// 		.GetProperties()
			// 		.Select(info =>
			// 				info.Name == "Items" ? $"[{string.Join(", ", Items)}]" : $"{info.Name}: {info.GetValue(obj)}");
			// return $"{{{string.Join(", ", props)}}}";
		}
	}
}