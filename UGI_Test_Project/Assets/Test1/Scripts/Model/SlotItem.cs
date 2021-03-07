namespace UGI_Test_1 {
	public abstract class SlotItem : IDamageable, ISlotable {
		public string Name { get; set; }
		public int HP { get; set; }
		public ShipSlot.Type SlotType { get; set; }

		protected SlotItem(string name, int hp, ShipSlot.Type slotType) {
			Name = name;
			HP = hp;
			SlotType = slotType;
		}

		public void TakeDamage(int damage) { HP -= damage; }

		public virtual void Die() { }
	}
}