using UnityEngine;

namespace UGI_Test_1 {
	public abstract class SlotItem : ScriptableObject, ISlotable, IDamageable, IUpgradable {
#region inspector
		[SerializeField] private string _name;
		[SerializeField] private float _hp;
		[SerializeField] private ShipSlot.Type _slotType;
		[ReadOnly] [SerializeField] private int _level;
#endregion

		public Spaceship Spaceship { get; set; }
		public string Name { get => _name; set => _name = value; }
		public float HP { get => _hp; set => _hp = value; }
		public int Level { get => _level; set => _level = value; }
		public ShipSlot.Type SlotType { get => _slotType; set => _slotType = value; }

		protected SlotItem(string name, int hp, ShipSlot.Type slotType) {
			Name = name;
			HP = hp;
			SlotType = slotType;
		}

		public void TakeDamage(float damage, Ammo.Type damageType) {
			HP -= damage;
			if (HP < 0) { Die(); }
		}

		public virtual void Die() { }

		public override string ToString() {
			return $"{{{nameof(Name)}: {Name}, " + $"{nameof(SlotType)}: {SlotType}, " + $"{nameof(HP)}: {HP}}}";
			// var obj = this;
			// return
			// 		$"{{{string.Join(", ", GetType().GetProperties().Select(info => $"{info.Name}: {info.GetValue(obj)}"))}}}";
		}
	}
}