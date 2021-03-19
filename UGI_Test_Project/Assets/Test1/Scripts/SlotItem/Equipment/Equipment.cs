namespace UGI_Test.UGI_Test_1 {
	public abstract class Equipment : SlotItem, IUpgradable {
		public int Level { get; set; }

		protected Equipment(string name, int hp, ShipSlot.Type slotType) : base(name, hp, slotType) {
			Level = Constants.DEFAULT_LEVEL;
		}

		public virtual void SetLevel(int level) { Level = level; }

		public void Upgrade(int addLevel) => SetLevel(Level + addLevel);
	}
}