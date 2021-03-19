using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UGI_Test.UGI_Test_2 {
	public class HeroIconScrollAdapter : MonoBehaviour {
		public int AmountHero = 10;
		public GameObject HeroPrefab;

		private Transform Content;
		[ReadOnly] [SerializeField] public HeroIconController SelectedItem;
		private readonly List<HeroIconController> _heroIcons = new List<HeroIconController>();

		private void Start() {
			Content = GetContent();
			for (var i = 0; i < 2; i++) { AddItem(0); }
			for (var i = 0; i < AmountHero; i++) { AddItem(); }
		}

		private Transform GetContent() {
			if (TryGetComponent(typeof(ScrollRect), out var scrollRect)) {
				return (scrollRect as ScrollRect)?.content;
			}
			Debug.LogError($"{nameof(ScrollRect)} not found in {name}");
			return null;
		}

		public void AddItem() {
			var heroId = Random.Range(0, HeroPathManager.Instance.HeroData.Count);
			AddItem(heroId);
		}

		public void AddItem(int heroId) {
			var model = Instantiate(HeroPathManager.Instance.HeroData[heroId].HeroIconModel) as HeroIconModel ??
					throw new Exception($"Can't instantiate {HeroPathManager.Instance.HeroData[heroId].HeroIconModel}");
			model.HeroId = heroId;
			model.Level = Random.Range(1, 31);
			model.Exp = Random.value;
			AddItem(model);
		}

		public void AddItem(HeroIconModel model) {
			var heroGO = Instantiate(HeroPrefab, Content);

			var viewController = GetHeroIconController(heroGO);
			viewController.Model = model;

			viewController.View.MainButton.onClick.AddListener(() => {
				if (SelectedItem.View.gameObject != viewController.View.gameObject) {
					SelectedItem.SetSelected(false);
					SelectedItem = viewController;
					SelectedItem.SetSelected(true);
				}
			});

			if (_heroIcons.Count == 0) {
				SelectedItem = viewController;
				SelectedItem.SetSelected(true);
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
}