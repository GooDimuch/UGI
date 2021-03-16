using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGI_Test_1 {
	public class SpaceshipController : BaseController<SpaceshipView, Spaceship>, IUpgradableController,
			IDamageableController {
		private readonly List<ShipSlotController> _shipSlots = new List<ShipSlotController>();

		private void Start() { }

		protected override void BindModelAndView(SpaceshipView view, Spaceship model) {
			CreateSlotShip(view, model);
		}

		private void CreateSlotShip(SpaceshipView view, Spaceship model) {
			var shipSlotsContainer = new GameObject("ShipSlots");
			shipSlotsContainer.transform.parent = transform;
			shipSlotsContainer.transform.localPosition = Vector3.zero;
			foreach (var type in model.SlotTypes) {
				var prefab = Resources.Load($"Prefabs/ShipSlots/{type}Slot") as GameObject ??
						throw new Exception($"Can't find prefab for {type}Slot by \"ShipSlots/{type}Slot\"");
				var go = Instantiate(prefab, shipSlotsContainer.transform);
				var viewController = GetController<ShipSlotController>(go);
				_shipSlots.Add(viewController);
				model.AddSlotShip(viewController.Model);
			}
			view.AddSlotShip(_shipSlots);
		}

		private T GetController<T>(GameObject go) where T : MonoBehaviour {
			if (!go.TryGetComponent(typeof(T), out var component)) { component = go.AddComponent<T>(); }
			return component as T ?? throw new Exception($"Can't get {nameof(T)} component");
		}

		public bool TryAddSlotItem(SlotItem item, out ShipSlot slot) {
			slot = Model.ShipSlots.FirstOrDefault(shipSlot =>
					shipSlot.SlotType >= item.SlotType && shipSlot.SlotItem == null);
			if (slot == null) {
				Debug.LogError($"Can't add {item} to {this}");
				return false;
			}
			Debug.Log($"Add {item} to slot {slot.SlotType}");
			slot.Add(item);
			// item.Selected = true;
			return true;
		}

		public void TakeDamage(float damage, Ammo.Type damageType) {
			var resist = 0f;
			switch (damageType) {
				case Ammo.Type.Bullet:
					resist = Model.TotalBulletResist;
					break;
				case Ammo.Type.PlasmaBeam:
					resist = Model.TotalPlasmaResist;
					break;
				default: throw new ArgumentOutOfRangeException(nameof(damageType), damageType, null);
			}
			Model.HP -= damage * (1 - resist);
			// if (_spaceship.HP < 0) { Die(); }
		}

		public void SetLevel(int level) { Model.Level = level; }
		public void Upgrade(int addLevel) { }

		public void Die() {
			Debug.Log("Die");
			OnDestroy();
		}

		private void OnDestroy() { gameObject.SetActive(false); }
	}
}