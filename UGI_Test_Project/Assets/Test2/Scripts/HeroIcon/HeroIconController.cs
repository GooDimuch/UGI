using UnityEngine;

namespace UGI_Test.UGI_Test_2 {
	public class HeroIconController : MonoBehaviour {
		private HeroIconView _view;

		public HeroIconView View {
			get {
				if (_view == null) { _view = InitializeItemView(); }
				return _view;
			}
		}

		public HeroIconModel Model { get; set; }

		public void Start() {
			View.transform.localPosition = Vector3.zero;
			View.transform.localScale = new Vector3(0.75f, 0.65f, 1f);
		}

		private HeroIconView InitializeItemView() {
			var view = GetComponent<HeroIconView>();
			view.HeroName.text = Model.Name;
			view.HeroImage.sprite = Model.Icon;
			view.ExpSlider.value = Model.Exp;
			view.LevelText.text = Model.Level.ToString();
			view.SelectedBorder.SetActive(false);

			view.MainButton.onClick.AddListener(MainButton_OnClick);
			return view;
		}

		public void SetSelected(bool value) { View.SelectedBorder.SetActive(value); }

		public void MainButton_OnClick() {
			// Debug.Log($"click {Model}");
		}
	}
}