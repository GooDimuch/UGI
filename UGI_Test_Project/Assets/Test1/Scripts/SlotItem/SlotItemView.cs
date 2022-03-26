using TMPro;
using UnityEngine;

namespace UGI_Test.UGI_Test_1 {
	public class SlotItemView : MonoBehaviour {
		public TextMeshPro NameText;
		[ReadOnly] public Vector3 StartPosition;

		public void Start() { StartPosition = transform.position; }
	}
}