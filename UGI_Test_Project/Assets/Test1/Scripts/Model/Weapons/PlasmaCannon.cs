namespace UGI_Test_1 {
	public class PlasmaCannon : Weapon {
		public PlasmaCannon() : base(nameof(PlasmaCannon),
				WeaponConstants.PLASMA_CANNON_HP,
				WeaponConstants.PLASMA_CANNON_DAMAGE,
				WeaponConstants.PLASMA_CANNON_FIRE_RATE,
				WeaponConstants.PLASMA_CANNON_CLIP_SIZE,
				WeaponConstants.PLASMA_CANNON_RELOAD_TIME,
				ShipSlot.Type.Light,
				Ammo.Type.PlasmaBeam) { }
	}
}