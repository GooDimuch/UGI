using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGI_Test_1 {
	public abstract class Spaceship : IUpgradable, IDamageable {
		public string Name { get; set; }
		public float HP { get; set; }
		public int Level { get; set; }
		public bool IsEnemy { get; private set; }
		public List<ShipSlot> ShipSlots { get; } = new List<ShipSlot>();

		public delegate void DieHandler();

		public event DieHandler DieEvent;

		private readonly IList<ShipSlot.Type> _slotTypes;

		protected Spaceship(string name, int hp, IList<ShipSlot.Type> slotTypes, bool isEnemy = false) {
			Name = name;
			HP = hp;
			_slotTypes = slotTypes;
			IsEnemy = isEnemy;

			SetLevel(Constants.DEFAULT_LEVEL);
			CreateSlotShip();
		}

		public virtual void SetLevel(int level) { Level = level; }

		public void Upgrade(int addLevel) => SetLevel(Level + addLevel);

		public void TakeDamage(float damage, Ammo.Type damageType) {
			switch (damageType) {
				case Ammo.Type.Bullet: break;
				case Ammo.Type.PlasmaBeam:
					var resistItems = GetSlotItems().Where(item => item is EnergyShield).ToArray();
					if (resistItems.Any()) {
						var resist = resistItems.Cast<EnergyShield>().Sum(item => item.PlasmaBeamResist);
						damage -= damage * (100 - resist) / 100;

						var regen = GetSlotItems()
								.Where(item => item is HpRegenerator)
								.Cast<HpRegenerator>()
								.Sum(item => item.RegenPerTic);
						HP += regen;
					}
					break;
				default: throw new ArgumentOutOfRangeException(nameof(damageType), damageType, null);
			}
			HP -= damage;
			if (HP < 0) { Die(); }
		}

		public virtual void Die() { DieEvent?.Invoke(); }

		private void CreateSlotShip() {
			foreach (var type in _slotTypes) { AddSlotShip(type); }
		}

		public void AddSlotShip(ShipSlot.Type slotType) {
			ShipSlots.Add(new ShipSlot(slotType));
			ShipSlots.Sort((slot1, slot2) => slot1.SlotType.CompareTo(slot2.SlotType));
		}

		public bool TryAddSlotItem(SlotItem item, out ShipSlot slot) {
			slot = ShipSlots.Find(shipSlot => shipSlot.SlotType >= item.SlotType && shipSlot.SlotItem == null);
			if (slot == null) {
				Debug.LogError($"Can't add {item} to {this}");
				return false;
			}
			Debug.Log($"Add {item} to slot {slot.SlotType}");
			slot.Add(item);
			return true;
		}

		public void PrintSlots() => Debug.Log(string.Join("\n", GetSlots()));

		public void PrintSlotItems() => Debug.Log(string.Join("\n", GetSlotItems()));

		public IEnumerable<SlotItem> GetSlots() => ShipSlots.Select(shipSlot => shipSlot.SlotItem);

		public IEnumerable<SlotItem> GetSlotItems() =>
				ShipSlots.Select(shipSlot => shipSlot.SlotItem).SelectMany(GetSubItems);

		private static IEnumerable<SlotItem> GetSubItems(SlotItem item) {
			return item is ComboSlotItem comboSlot
					? comboSlot.Items.SelectMany(GetSubItems)
					: new List<SlotItem> {item};
		}

		public override string ToString() { return $"{nameof(Name)}: {Name}" + $"{nameof(Level)}: {Level}"; }
	}
}