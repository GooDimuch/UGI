using UnityEngine;

namespace UGI_Test_1 {
	public class PlayerController : MonoBehaviour {
		private void Start() {
			var spaceship = new Scout();

			var mg = new MachineGun();
			var mgX2 = new MachineGunX2(mg);
			var mgX2pc = new PlasmaCannon(mgX2);

		}

		private void Update() { }
	}
}
