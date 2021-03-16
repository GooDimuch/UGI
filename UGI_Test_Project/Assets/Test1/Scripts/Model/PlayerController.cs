using System.Collections.Generic;
using UnityEngine;

namespace UGI_Test_1 {
	public class PlayerController : MonoBehaviour {
		public List<SpaceshipController> Spaceships;

		[ReadOnly] [SerializeField] SpaceshipController SelectedSpaceship;

		private void Start() {
			Spaceships[1].SetLevel(-1);
			Spaceships.ForEach((controller => Debug.Log(controller.Model.ToString())));

			// var spaceship = Spaceships[0];
			// var scout = spaceship.Model as Scout ?? throw new Exception("Spaceship is null");
			// spaceship.TryAddSlotItem(new MG_PC_ES() {Spaceship = scout}, out _);
			// if (spaceship.TryAddSlotItem(new MG_MG_PC_PC(), out var slot)) {
			// 	if (slot.SlotItem is ComboSlotItem comboSlot) { Debug.Log(comboSlot.Items.Count); }
			// }
			// spaceship.TryAddSlotItem(new MG_PC_ES(), out _);
			// spaceship.TryAddSlotItem(new SmallEngine() {Level = 2}, out _);
			// spaceship.TryAddSlotItem(new EnergyShield(), out _);
			// spaceship.TryAddSlotItem(new PlasmaCannon(), out _);
			//
			// spaceship.TakeDamage(10, Ammo.Type.Bullet);
			//
			// scout.PrintSlots();
			// scout.PrintSlotItems();
			// EditorApplication.isPlaying = false;
		}

		private void Update() {
			// var spaceship = Spaceships[0];
			// if (Input.GetKeyDown(KeyCode.Alpha1)) { spaceship.TakeDamage(100, Ammo.Type.PlasmaBeam); }
			// if (Input.GetKeyDown(KeyCode.Alpha2)) {
			// 	spaceship.Model?.ShipSlots.FirstOrDefault(slot => slot.SlotItem != null)
			// 			?.SlotItem.TakeDamage(1, Ammo.Type.Bullet);
			// }
		}
	}
}