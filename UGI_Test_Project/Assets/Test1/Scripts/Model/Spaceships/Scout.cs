using System.Collections.Generic;

namespace UGI_Test_1 {
	public class Scout : Spaceship {
		public Scout() : base(SpaceshipConstants.SCOUT_SPACESHIP_HP,
				new List<ShipSlot.Type> {ShipSlot.Type.Heavy, ShipSlot.Type.Light}) { }

		public override void SetLevel(int level) {
			base.SetLevel(level);

			//в зависимости от уровня повышаются их характеристики
			HP = (HP * level / 2f).TI();
		}
	}
}