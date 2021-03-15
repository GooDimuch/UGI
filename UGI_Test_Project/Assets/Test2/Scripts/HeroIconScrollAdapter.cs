using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HeroIconScrollAdapter : MonoBehaviour {
	public int AmountHero = 10;
	public GameObject HeroPrefab;

	private Transform Content;
	private HeroIconController _selectedItem;
	private readonly List<HeroIconController> _heroIcons = new List<HeroIconController>();

	private void Start() {
		Content = GetContent();
		for (var i = 0; i < AmountHero; i++) { AddItem(); }
	}

	private Transform GetContent() {
		if (TryGetComponent(typeof(ScrollRect), out var scrollRect)) {
			return (scrollRect as ScrollRect)?.content;
		}
		Debug.LogError($"{nameof(ScrollRect)} not found in {name}");
		return null;
	}

	public void AddItem() =>
			AddItem(new HeroIconModel(Random.Range(0, 10) % 2 == 0 ? "IronHead" : "AnotherHero",
					Random.Range(1, 30),
					Random.value));

	public void AddItem(string name, int level, float exp, bool selected) =>
			AddItem(new HeroIconModel(name, level, exp));

	public void AddItem(HeroIconModel model) {
		var heroGO = Instantiate(HeroPrefab, Content);

		var viewController = GetHeroIconController(heroGO);
		viewController.Model = model;

		viewController.View.MainButton.onClick.AddListener(() => {
			if (_selectedItem.View.gameObject != viewController.View.gameObject) {
				_selectedItem.SetSelected(false);
				_selectedItem = viewController;
				_selectedItem.SetSelected(true);
			}
		});

		if (_heroIcons.Count == 0) {
			_selectedItem = viewController;
			_selectedItem.SetSelected(true);
		}
		_heroIcons.Add(viewController);
	}

	private HeroIconController GetHeroIconController(GameObject heroGO) {
		if (!TryGetComponent(typeof(HeroIconController), out var component)) {
			component = heroGO.AddComponent<HeroIconController>();
		}
		return component as HeroIconController ??
				throw new Exception($"Can't get {nameof(HeroIconController)} component");
	}
}