using System.Linq;
using UnityEngine;

namespace UGI_Test_1 {
	public abstract class SlotItem : BaseModel, ISlotable, IDamageable, IUpgradable {
		private static int _idCounter;

#region inspector
		[ReadOnly] [SerializeField] private int _id;
		[SerializeField] private string _name;
		[SerializeField] private float _maxHp;
		[ReadOnly] [SerializeField] private float _hp;
		[SerializeField] private ShipSlot.Type _slotType;
		[ReadOnly] [SerializeField] private int _level;
#endregion

		public int Id { get => _id; set => _id = value; }
		public string Name { get => _name; set => _name = value; }
		public float MaxHP { get => _maxHp; set => _maxHp = value; }
		public float HP { get => _hp; set => _hp = value; }
		public int Level { get => _level; set => _level = value; }
		public ShipSlot.Type SlotType { get => _slotType; set => _slotType = value; }

		protected SlotItem(string name, int hp, ShipSlot.Type slotType) {
			Id = _idCounter++;
			Name = name;
			HP = hp;
			SlotType = slotType;
		}

		public override bool Equals(object other) {
			if (other?.GetType() != GetType()) { return false; }
			return (other as SlotItem)?.Id == Id;
		}

		public override string ToString() =>
				$"{{{nameof(Name)}: {Name}, " + $"{nameof(SlotType)}: {SlotType}, " + $"{nameof(HP)}: {HP}}}";

		public override string ToFullString() =>
				$"{{{string.Join(", ", GetType().GetProperties().Select(info => $"{info.Name}: {info.GetValue(this)}"))}}}";
	}
}