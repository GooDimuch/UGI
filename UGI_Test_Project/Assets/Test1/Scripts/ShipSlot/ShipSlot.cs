using UnityEngine;

namespace UGI_Test.UGI_Test_1 {
	[CreateAssetMenu(fileName = nameof(ShipSlot), menuName = "ScriptableObjects/Task_1/" + nameof(ShipSlot))]
	public class ShipSlot : BaseModel, ISlotable {
		public enum Type {
			Light,
			Medium,
			Heavy,
		}

#region inspector
		[SerializeField] private Type _slotType;
		[SerializeField] private Color _prefabColor;
#endregion

		[ReadOnly] public SlotItem SlotItem;

		public Type SlotType { get => _slotType; set => _slotType = value; }
		public Color PrefabColor => _prefabColor;

		public ShipSlot(Type slotType) { SlotType = slotType; }

		public void Add(SlotItem item) { SlotItem = item; }

		public void Remove() => SlotItem = null;

		public override string ToString() { return $"{SlotType} contain {SlotItem?.ToString() ?? "null"}"; }
	}
}