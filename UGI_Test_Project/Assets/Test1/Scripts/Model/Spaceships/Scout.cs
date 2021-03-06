namespace UGI_Test_1 {
	public class Scout : Spaceship {
		public Scout() : base(SpaceshipConstants.SCOUT_SPACESHIP_HP, SpaceshipConstants.SCOUT_WEAPON_SLOTS) { }

		public override void SetLevel(int level) {
			base.SetLevel(level);

			//в зависимости от уровня повышаются их характеристики
			HP = (HP * level / 2f).TI();
		}
	}
}