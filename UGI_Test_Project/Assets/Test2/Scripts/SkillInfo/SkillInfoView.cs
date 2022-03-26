using TMPro;
using UnityEngine;

namespace UGI_Test.UGI_Test_2 {
	public class SkillInfoView : MonoBehaviour {
		public const float BOTTOM_MARGIN = 12f;
		public TextMeshProUGUI SkillInfoText;
		public GameObject Arrow;

		private float? _height;
		private float Height => _height ?? GetComponent<RectTransform>().rect.height;

		private float? _parentHeight;

		private float ParentHeight =>
				_parentHeight ?? gameObject.transform.parent.GetComponent<RectTransform>().rect.height;

		public void MoveTo(Vector3 toPosition) {
			var newPos = transform.position;
			newPos.y = toPosition.y;
			transform.position = newPos;
			var bottomOffset = -ParentHeight / 2 + Height / 2 + BOTTOM_MARGIN;
			if (transform.localPosition.y < bottomOffset) {
				var newMainPos = transform.localPosition;
				newMainPos.y = bottomOffset;
				transform.localPosition = newMainPos;
			}
			Arrow.transform.position = newPos;
		}
	}
}