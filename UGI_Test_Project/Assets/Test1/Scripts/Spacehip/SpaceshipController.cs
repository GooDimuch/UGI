using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGI_Test.UGI_Test_1 {
	public class SpaceshipController : BaseController<SpaceshipView, Spaceship>, IUpgradableController,
			IDamageableController {
		private readonly List<ShipSlotController> _shipSlots = new List<ShipSlotController>();

		protected override void BindModelAndView(SpaceshipView view, Spaceship model) {
			view.NameText.text = model.Name;
			CreateSlotShip(view, model);
		}

		protected override void SyncViewModel(SpaceshipView view, Spaceship model) {
			view.NameText.text = model.Name;
		}

		private void CreateSlotShip(SpaceshipView view, Spaceship model) {
			foreach (var type in model.SlotTypes) {
				var prefab = Resources.Load($"Prefabs/ShipSlots/{type}_{nameof(ShipSlot)}") as GameObject ??
						throw new Exception($"Can't find prefab for {type}Slot by \"ShipSlots/{type}Slot\"");
				var go = Instantiate(prefab, view.ShipSlotsContainer);
				var viewController = go.GetComponentForce<ShipSlotController>();
				_shipSlots.Add(viewController);
				model.AddSlotShip(viewController.Model);
			}
			view.AddSlotShip(_shipSlots);
		}

		public bool ContainsItem(SlotItemController item) =>
				Model.ShipSlots.Select(slot => slot.SlotItem).Contains(item.Model);

		public int CountItem(Type type) => Model.ShipSlots.Count(slot => slot.SlotItem?.GetType() == type);

		public bool TryAddSlotItem(SlotItemController item, out ShipSlotController slot) {
			slot = _shipSlots.FirstOrDefault(shipSlot =>
					shipSlot.Model.SlotType == item.Model.SlotType && shipSlot.Model.SlotItem == null);
			if (slot == null) { return false; }
			slot.AddItem(item);
			item.Spaceship = this;
			return true;
		}

		public void RemoveSlotItem(SlotItemController item) {
			var slot = _shipSlots.FirstOrDefault(shipSlot => shipSlot.Model.SlotItem?.Id == item.Model.Id);
			item.Spaceship = null;
			slot?.Remove(item);
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
			if (Model.HP <= 0) { Die(); }
		}

		public void SetLevel(int level) { Model.Level = level; }

		public void Upgrade(int addLevel) { }

		public void Die() {
			Debug.Log($"{Model.Name} is die");
			OnDestroy();
		}

		private void OnDestroy() { gameObject.SetActive(false); }

		public void SetDamageToItems() {
			_shipSlots.Where(slot => slot.SlotItem != null)
					.Select(slot => slot.SlotItem)
					.ToList()
					.ForEach(item => item.TakeDamage(1, Ammo.Type.Bullet));
		}
	}
}