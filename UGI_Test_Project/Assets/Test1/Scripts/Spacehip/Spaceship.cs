﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGI_Test.UGI_Test_1 {
	public abstract class Spaceship : BaseModel, IDamageable, IUpgradable {
#region inspector
		[SerializeField] private string _name;
		[SerializeField] private float _maxHp;
		[ReadOnly] [SerializeField] private float _hp;
		[ReadOnly] [SerializeField] private int _level = 1;
		[ReadOnly] [SerializeField] private float _speed = 1f;

		[Header("Base resists")] public float BulletResist;
		public float PlasmaResist;

		[Header("Ship slot types")] [SerializeField] private List<ShipSlot.Type> _slotTypes;
#endregion

		public string Name { get => _name; set => _name = value; }
		public float MaxHP { get => _maxHp; set => _maxHp = value; }
		public float HP { get => _hp; set => _hp = Mathf.Clamp(value, 0, MaxHP); }
		public int Level { get => _level; set => _level = value; }
		public float Speed { get => _speed; set => _speed = value; }
		public bool IsEnemy { get; private set; }

		public List<ShipSlot.Type> SlotTypes { get => _slotTypes; private set => _slotTypes = value; }

		public float TotalBulletResist => BulletResist + ObtainedBulletResist;
		public float TotalPlasmaResist => PlasmaResist + ObtainedPlasmaResist;

		public float ObtainedBulletResist { get; set; }
		public float ObtainedPlasmaResist { get; set; }

		private readonly List<ShipSlot> _shipSlots = new List<ShipSlot>();
		public IReadOnlyList<ShipSlot> ShipSlots => _shipSlots;

		protected Spaceship(string name, int hp, List<ShipSlot.Type> slotTypes, bool isEnemy = false) {
			Name = name;
			HP = hp;
			SlotTypes = slotTypes;
			IsEnemy = isEnemy;
			Level = Constants.DEFAULT_LEVEL;
		}

		public void AddSlotShip(ShipSlot shipSlot) {
			_shipSlots.Add(shipSlot);
			_shipSlots.Sort((slot1, slot2) => slot1.SlotType.CompareTo(slot2.SlotType));
		}

		// public void PrintSlots() => Debug.Log(string.Join("\n", GetSlots()));
		//
		// public void PrintSlotItems() => Debug.Log(string.Join("\n", GetSlotItems()));
		//
		// public IEnumerable<SlotItem> GetSlots() => ShipSlots.Select(shipSlot => shipSlot.SlotItem);
		//
		// public IEnumerable<SlotItem> GetSlotItems() =>
		// 		ShipSlots.Select(shipSlot => shipSlot.SlotItem).SelectMany(GetSubItems);
		//
		// private static IEnumerable<SlotItem> GetSubItems(SlotItem item) {
		// 	return item is ComboSlotItem comboSlot
		// 			? comboSlot.Items.SelectMany(GetSubItems)
		// 			: new List<SlotItem> {item};
		// }

		public override string ToString() => $"{nameof(Name)}: {Name}, " + $"{nameof(Level)}: {Level}";

		public override string ToFullString() =>
				$"{{{string.Join(", ", GetType().GetProperties().Select(info => $"{info.Name}: {info.GetValue(this)}"))}}}";
	}
}