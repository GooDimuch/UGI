using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UGI_Test.UGI_Test_2 {
	public class SkillInfoController : MonoBehaviour {
		private SkillInfoButtonView _view;

		public SkillInfoButtonView View {
			get {
				if (_view == null) { _view = InitializeItemView(); }
				return _view;
			}
		}

		public SkillInfoModel Model;
		public SkillInfoView SkillInfoGO;

		private void Start() {
			if (View == null) { _view = InitializeItemView(); }
		}

		private SkillInfoButtonView InitializeItemView() {
			var view = GetComponent<SkillInfoButtonView>();
			view.MainButton.onClick.AddListener(SkillButton_OnClick);
			view.EventTrigger.triggers.Add(GetEvent(EventTriggerType.PointerEnter, OnPointerEnterDelegate));
			view.EventTrigger.triggers.Add(GetEvent(EventTriggerType.PointerExit, OnPointerExitDelegate));
			return view;
		}

		private static EventTrigger.Entry GetEvent(EventTriggerType eventTriggerType,
				Action<PointerEventData> action) {
			var enterEvent = new EventTrigger.Entry {eventID = eventTriggerType};
			enterEvent.callback.AddListener(data => action((PointerEventData) data));
			return enterEvent;
		}

		private void SkillButton_OnClick() {
			// Debug.Log($"{MethodBase.GetCurrentMethod().Name} {Model.SkillName}");
		}

		private void OnPointerEnterDelegate(PointerEventData pointerEventData) {
			SkillInfoGO.gameObject.SetActive(true);
			SkillInfoGO.SkillInfoText.text = Model.SkillInfo;
			SkillInfoGO.MoveTo(View.transform.position);
		}

		private void OnPointerExitDelegate(PointerEventData pointerEventData) {
			SkillInfoGO.gameObject.SetActive(false);
		}
	}
}