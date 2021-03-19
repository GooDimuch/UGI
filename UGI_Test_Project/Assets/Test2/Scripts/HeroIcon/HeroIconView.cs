using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UGI_Test.UGI_Test_2 {
	public class HeroIconView : MonoBehaviour {
		[HideInInspector] public string IconPath;
		public Button MainButton;
		public Image HeroImage;
		public Slider ExpSlider;
		public TextMeshProUGUI LevelText;
		public GameObject SelectedBorder;
	}
}