using System.Collections.Generic;

namespace UGI_Test_1 {
	public class GunX2MachineGunX2PlasmaCannon : Weapon {
		private List<Weapon> weapons = new List<Weapon>();

		public GunX2MachineGunX2PlasmaCannon(Weapon weapon) : base(WeaponConstants.MACHINE_GUN_HP,
				weapon.Damage + WeaponConstants.MACHINE_GUN_DAMAGE,
				WeaponConstants.MACHINE_GUN_FIRE_RATE,
				WeaponConstants.MACHINE_GUN_CLIP_SIZE,
				WeaponConstants.MACHINE_GUN_RELOAD_TIME,
				ShipSlot.Type.Heavy,
				Ammo.Type.Bullet) { }

		public override void Add(Weapon weapon) { weapons.Add(weapon); }
	}
}