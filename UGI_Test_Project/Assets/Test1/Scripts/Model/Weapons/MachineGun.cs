namespace UGI_Test_1 {
	public class MachineGun : Weapon {
		public MachineGun() : base(WeaponConstants.MACHINE_GUN_HP,
				WeaponConstants.MACHINE_GUN_DAMAGE,
				WeaponConstants.MACHINE_GUN_FIRE_RATE,
				WeaponConstants.MACHINE_GUN_CLIP_SIZE,
				WeaponConstants.MACHINE_GUN_RELOAD_TIME,
				ShipSlot.Type.Light,
				Ammo.Type.Bullet) { }

		// public MachineGun(Weapon weapon) : base(WeaponConstants.MACHINE_GUN_HP,
		// 		weapon.Damage + WeaponConstants.MACHINE_GUN_DAMAGE,
		// 		WeaponConstants.MACHINE_GUN_FIRE_RATE,
		// 		WeaponConstants.MACHINE_GUN_CLIP_SIZE,
		// 		WeaponConstants.MACHINE_GUN_RELOAD_TIME,
		// 		WeaponSlot.Type.Light,
		// 		Ammo.Type.Bullet,
		// 		weapon) { }
	}
}