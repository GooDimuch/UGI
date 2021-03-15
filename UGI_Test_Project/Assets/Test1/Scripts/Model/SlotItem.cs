using System.Linq;

namespace UGI_Test_1 {
	public abstract class SlotItem : IDamageable, ISlotable {
		public string Name { get; set; }
		public float HP { get; set; }
		public ShipSlot.Type SlotType { get; set; }

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