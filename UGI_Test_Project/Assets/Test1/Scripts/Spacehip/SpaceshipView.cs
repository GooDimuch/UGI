using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;

namespace UGI_Test_1 {
	public class SpaceshipView : MonoBehaviour {
		public float startPos = -1f;
		public float offset = 1f;
		public Transform ShipSlotsContainer;
		public TextMeshPro NameText;

		public void AddSlotShip(IReadOnlyList<ShipSlotController> controllers) {
			var count = 0;
			foreach (var slotView in controllers.Select(controller => controller.View)) {
				slotView.transform.position += startPos * Vector3.one + offset * Vector3.right * count++;
			}

			Debug.Log($"{MethodBase.GetCurrentMethod().Name}" +
					$"[{string.Join(", ", controllers.Select(controller => controller.Model.SlotType))}]" +
					$" to {name}");
		}
	}
}