using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroIconView : MonoBehaviour {
	[HideInInspector] public string IconPath;
	public Button MainButton;
	public Image HeroImage;
	public Slider ExpSlider;
	public TextMeshProUGUI LevelText;
	public GameObject SelectedBorder;
}