using UnityEditor;
using UnityEngine;

namespace UGI_Test_1 {
	public class PlayerController : MonoBehaviour {
		private void Start() {
			var scout = new Scout();
			scout.TryAddSlotItem(new MG_PC_ES(), out _);
			if (scout.TryAddSlotItem(new MG_MG_PC_PC(), out var slot)) {
				if (slot.SlotItem is ComboSlotItem comboSlot) { Debug.Log(comboSlot.Items.Count); }
			}
			scout.TryAddSlotItem(new MG_PC_ES(), out _);
			scout.TryAddSlotItem(new SmallEngine(){Level = 2}, out _);
			scout.TryAddSlotItem(new EnergyShield(), out _);
			scout.TryAddSlotItem(new PlasmaCannon(), out _);

			scout.PrintSlots();
			scout.PrintSlotItems();

			var shipGO = new GameObject(scout.Name);
			shipGO.transform.parent = transform;
			var shipController = shipGO.AddComponent<SpaceshipController>();
			shipController.Spaceship = scout;

			// EditorApplication.isPlaying = false;
		}

		private void Update() { }
	}
}