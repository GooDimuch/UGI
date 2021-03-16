namespace UGI_Test_1 {
	public class MachineGunX2 : Weapon {
		public MachineGunX2() : base(nameof(MachineGunX2),
				WeaponConstants.MACHINE_GUN_HP,
				WeaponConstants.MACHINE_GUN_DAMAGE,
				WeaponConstants.MACHINE_GUN_FIRE_RATE,
				WeaponConstants.MACHINE_GUN_CLIP_SIZE,
				WeaponConstants.MACHINE_GUN_RELOAD_TIME,
				ShipSlot.Type.Medium,
				Ammo.Type.Bullet) { }
	}
}