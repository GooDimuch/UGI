namespace UGI_Test_1 {
	public class MachineGunX2 : WeaponDecorator {
		public MachineGunX2(Weapon weapon) : base(WeaponConstants.MACHINE_GUN_HP,
				weapon.Damage + WeaponConstants.MACHINE_GUN_DAMAGE,
				WeaponConstants.MACHINE_GUN_FIRE_RATE,
				WeaponConstants.MACHINE_GUN_CLIP_SIZE,
				WeaponConstants.MACHINE_GUN_RELOAD_TIME,
				ShipSlot.Type.Medium,
				Ammo.Type.Bullet,
				weapon) { }
	}
}