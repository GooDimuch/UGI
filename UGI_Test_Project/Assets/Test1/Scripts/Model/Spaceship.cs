using System.Collections.Generic;
using UnityEngine;

namespace UGI_Test_1 {
	public abstract class Spaceship : IUpgradable, IDamageable {
		public int HP { get; set; }
		public int Level { get; set; }
		public bool IsEnemy { get; private set; }
		public List<ShipSlot> WeaponSlots { get; } = new List<ShipSlot>();

		private readonly IList<ShipSlot.Type> _slotTypes;

		protected Spaceship(int hp, IList<ShipSlot.Type> slotTypes, bool isEnemy = false) {
			HP = hp;
			_slotTypes = slotTypes;
			IsEnemy = isEnemy;

			SetLevel(Constants.DEFAULT_LEVEL);
			CreateSlotShip();
		}

		public virtual void SetLevel(int level) { Level = level; }

		public void Upgrade(int addLevel) => SetLevel(Level + addLevel);

		public void TakeDamage(int damage) {
			HP -= damage;
			if (HP < 0) { Die(); }
		}

		public virtual void Die() { }

		private void CreateSlotShip() {
			foreach (var type in _slotTypes) { AddSlotShip(type); }
		}

		public void AddSlotShip(ShipSlot.Type slotType) { WeaponSlots.Add(new ShipSlot(slotType)); }

		public bool TryAddSlotItem(SlotItem item, out ShipSlot slot) {
			slot = WeaponSlots.Find(shipSlot => shipSlot.SlotType > item.SlotType && shipSlot.SlotItem == null);
			if (slot == null) {
				Debug.LogError($"Can't add {item} to {this}");
				return false;
			}
			slot.Add(item);
			return true;
		}
	}
}