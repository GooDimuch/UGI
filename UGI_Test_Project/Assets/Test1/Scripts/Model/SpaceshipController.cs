using System.Linq;
using UnityEngine;

namespace UGI_Test_1 {
	public class SpaceshipController : MonoBehaviour {
		private Spaceship _spaceship;

		public Spaceship Spaceship {
			get => _spaceship;
			set {
				_spaceship = value;
				_spaceship.DieEvent += OnDie;
			}
		}

		private void OnDie() {
			Debug.Log("Die");
			OnDestroy();
		}

		private void Start() { }

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Alpha1)) { Spaceship?.TakeDamage(100, Ammo.Type.PlasmaBeam); }
			if (Input.GetKeyDown(KeyCode.Alpha2)) {
				Spaceship?.ShipSlots.FirstOrDefault(slot => slot.SlotItem != null)
						?.SlotItem.TakeDamage(1, Ammo.Type.Bullet);
			}
		}

		private void OnDestroy() { gameObject.SetActive(false); }
	}
}