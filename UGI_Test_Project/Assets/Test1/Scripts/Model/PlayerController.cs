using UnityEditor;
using UnityEngine;

namespace UGI_Test_1 {
	public class PlayerController : MonoBehaviour {
		private void Start() {
			var scout = new Scout();
			if (scout.TryAddSlotItem(new GunX2MachineGunX2PlasmaCannon(), out var slot)) {
				Debug.Log(slot.SlotItem.GetType());
				if (slot.SlotItem is GunX2MachineGunX2PlasmaCannon mgX2pc) {
					Debug.Log(mgX2pc.items.Count);
				}
			}

			var mg = new MachineGun();
			// var mgX2 = new MachineGunX2(mg);
			// var mgX2pc = new PlasmaCannon(mgX2);

			EditorApplication.isPlaying = false;
		}

		private void Update() { }
	}
}