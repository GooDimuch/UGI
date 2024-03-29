﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UGI_Test.UGI_Test_1 {
	public class PlayerController : MonoBehaviour {
		public List<SpaceshipController> Spaceships;
		public List<SlotItemController> SlotItems;

		[ReadOnly] [SerializeField] SpaceshipController SelectedSpaceship;

		private void Start() { }

		private void Update() {
			CheckRaycast();
			DamageShip();
			AddHealthBar();
		}

		private void DamageShip() {
			if (Input.GetKeyDown(KeyCode.Alpha1)) { SelectedSpaceship.TakeDamage(100, Ammo.Type.PlasmaBeam); }
			if (Input.GetKeyDown(KeyCode.Alpha2)) { SelectedSpaceship.SetDamageToItems(); }
		}

		private void AddHealthBar() {
			if (SelectedSpaceship == null) { return; }
			var healthBarLength = 10;
			var maxHP = SelectedSpaceship.Model.MaxHP;
			var hp = SelectedSpaceship.Model.HP;
			var ratio = (int) (hp / maxHP * healthBarLength);
			var name = SelectedSpaceship.Model.Name.Split(' ')[0];
			var health = "";
			for (var i = 0; i < healthBarLength; i++) { health += i < ratio ? "0" : "_"; }
			SelectedSpaceship.Model.Name = name + $" [{health}]";
		}

		private void CheckRaycast() {
			if (Input.GetMouseButtonUp(0)) {
				var curMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				var rayHit = Physics2D.Raycast(curMousePos, Vector2.zero);
				if (rayHit.transform != null) {
					if (rayHit.transform.gameObject.TryGetComponent(typeof(SpaceshipController), out var component)) {
						SelectedSpaceship = component as SpaceshipController;
					}
					else if (rayHit.transform.gameObject.TryGetComponent(typeof(SlotItemController), out component)) {
						var item = component as SlotItemController ??
								throw new Exception($"Can't cast {component.GetType()} to {nameof(SlotItemController)}");
						if (SelectedSpaceship != null) {
							if (SelectedSpaceship.ContainsItem(item)) { SelectedSpaceship.RemoveSlotItem(item); }
							else {
								if (SelectedSpaceship.TryAddSlotItem(item, out _)) {
									Debug.Log($"Add {item.Model} to slot {item.Model.SlotType}");
								}
								else { Debug.LogError($"Can't add {item.Model} to {SelectedSpaceship}"); }
							}
						}
						else { Debug.Log($"{nameof(SelectedSpaceship)} is null"); }
					}
					else { Debug.Log("Selected object: " + rayHit.transform.name); }
				}
			}
		}
	}
}