namespace UGI_Test_1 {
	public class PlasmaCannon : WeaponDecorator {
		public PlasmaCannon(Weapon weapon) : base(WeaponConstants.PLASMA_CANNON_HP,
				weapon.Damage + WeaponConstants.PLASMA_CANNON_DAMAGE,
				WeaponConstants.PLASMA_CANNON_FIRE_RATE,
				WeaponConstants.PLASMA_CANNON_CLIP_SIZE,
				WeaponConstants.PLASMA_CANNON_RELOAD_TIME,
				ShipSlot.Type.Light,
				Ammo.Type.PlasmaBeam,
				weapon) { }
	}
}