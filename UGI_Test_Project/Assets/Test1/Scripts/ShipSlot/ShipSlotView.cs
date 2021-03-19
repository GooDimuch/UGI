using UnityEngine;

namespace UGI_Test.UGI_Test_1 {
	public class ShipSlotView : MonoBehaviour {
		public MeshRenderer MeshRenderer;
		public Transform ItemContainer;

		public void Add(SlotItemController item) {
			item.transform.parent = ItemContainer;
			item.transform.localPosition = Vector3.zero;
		}

		public void Remove(SlotItemController item) {
			item.transform.parent = null;
			item.transform.position = item.View.StartPosition;
		}
	}
}