using UnityEngine;

namespace UGI_Test_1 {
	[CreateAssetMenu(fileName = nameof(MachineGunX2),
			menuName = "ScriptableObjects/Task_1/" +
					nameof(SlotItem) +
					"s/" +
					nameof(Weapon) +
					"s/" +
					nameof(MachineGunX2))]
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