using UnityEngine;

namespace UGI_Test.UGI_Test_1 {
	[CreateAssetMenu(fileName = nameof(PlasmaCannon),
			menuName = "ScriptableObjects/Task_1/" +
					nameof(SlotItem) +
					"s/" +
					nameof(Weapon) +
					"s/" +
					nameof(PlasmaCannon))]
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