using UnityEngine;

namespace UGI_Test_1 {
	[CreateAssetMenu(fileName = "MachineGun",
			menuName = "ScriptableObjects/Task_1/SlotItems/Weapons/MachineGun")]
	public class MachineGun : Weapon {
		public MachineGun() : base(nameof(MachineGun),
				WeaponConstants.MACHINE_GUN_HP,
				WeaponConstants.MACHINE_GUN_DAMAGE,
				WeaponConstants.MACHINE_GUN_FIRE_RATE,
				WeaponConstants.MACHINE_GUN_CLIP_SIZE,
				WeaponConstants.MACHINE_GUN_RELOAD_TIME,
				ShipSlot.Type.Light,
				Ammo.Type.Bullet) { }
	}
}