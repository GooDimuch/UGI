using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectHeroScrollAdapter : MonoBehaviour {
	public int AmountHero = 10;
	public GameObject HeroPrefab;

	private Transform Content;
	private HeroIconViewModel _selectedItem;
	private readonly List<HeroIconViewModel> _heroIcons = new List<HeroIconViewModel>();

	private void Start() {
		Content = GetContent();
		for (var i = 0; i < AmountHero; i++) { AddItem(); }
	}

	private void Update() { }

	private Transform GetContent() {
		if (TryGetComponent(typeof(ScrollRect), out var scrollRect)) {
			return (scrollRect as ScrollRect)?.content;
		}
		Debug.LogError($"{nameof(ScrollRect)} not found in {name}");
		return null;
	}

	public void AddItem() {
		var model = new HeroIconModel(Random.Range(0, 10) % 2 == 0 ? "IronHead" : "AnotherHero",
				Random.Range(1, 30),
				Random.value,
				_heroIcons.Count == 0);
		var heroGO = Instantiate(HeroPrefab, Content);
		heroGO.transform.localPosition = Vector3.zero;
		heroGO.transform.localScale = new Vector3(0.75f, 0.65f, 1f);
		var view = InitializeItemView(heroGO, model);
		var viewModel = new HeroIconViewModel(view, model);
		if (viewModel.model.Selected) { _selectedItem = viewModel; }
		_heroIcons.Add(viewModel);
	}

	private HeroIconView InitializeItemView(GameObject heroGO, HeroIconModel model) {
		var view = new HeroIconView(heroGO);
		view.IconPath = $"heroes/{model.Name}Icon";
		view.HeroImage.sprite = Resources.Load<Sprite>(view.IconPath);
		view.ExpSlider.value = model.Exp;
		view.LevelText.text = model.Level.ToString();
		view.SelectedBorder.SetActive(model.Selected);

		view.MainButton.onClick.AddListener(() => {
			if (_selectedItem.view.HeroIcon != heroGO) {
				_selectedItem.SetSelected(false);
				_selectedItem = _heroIcons.FirstOrDefault(viewModel => viewModel?.view.Equals(view) ?? false);
				_selectedItem?.SetSelected(true);
			}
		});
		return view;
	}
}

public class HeroIconViewModel {
	public HeroIconView view;
	public HeroIconModel model;

	public HeroIconViewModel(HeroIconView view, HeroIconModel model) {
		this.view = view;
		this.model = model;
	}

	public void SetSelected(bool value) {
		model.Selected = value;
		view.SelectedBorder.SetActive(value);
	}
}

public class HeroIconView {
	public GameObject HeroIcon;
	public string IconPath;
	public Button MainButton;
	public Image HeroImage;
	public Slider ExpSlider;
	public TextMeshProUGUI LevelText;
	public GameObject SelectedBorder;

	public HeroIconView(GameObject rootView) {
		HeroIcon = rootView;
		var heroIcon = HeroIcon.GetComponent<HeroIconContainer>();
		MainButton = heroIcon.MainButton;
		HeroImage = heroIcon.HeroImage;
		ExpSlider = heroIcon.ExpSlider;
		LevelText = heroIcon.LevelText;
		SelectedBorder = heroIcon.SelectedBorder;
	}
}

public class HeroIconModel {
	public string Name;
	public int Level;
	public float Exp;
	public bool Selected;

	public HeroIconModel(string name, int level, float exp, bool selected) {
		Name = name;
		Level = level;
		Exp = exp;
		Selected = selected;
	}

	public override string ToString() =>
			string.Join(", ", GetType().GetFields().Select(info => $"{info.Name}: {info.GetValue(this)}"));
}