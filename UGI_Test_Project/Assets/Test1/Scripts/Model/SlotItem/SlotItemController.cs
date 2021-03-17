using UnityEngine;

namespace UGI_Test_1 {
	public class SlotItemController : BaseController<SlotItemView, SlotItem>, IDamageableController {
		private SpaceshipController _spaceship;

		public SpaceshipController Spaceship {
			get => _spaceship;
			set {
				if (value == null) {
					OnRemoved();
					_spaceship = value;
				}
				else {
					_spaceship = value;
					OnAdded();
				}
			}
		}

		protected override void BindModelAndView(SlotItemView view, SlotItem model) {
			view.NameText.text = model.Name;
		}

		protected virtual void OnAdded() { }

		protected virtual void OnRemoved() { }

		public void TakeDamage(float damage, Ammo.Type damageType) {
			var resist = 0f;
			Model.HP -= damage * (1 - resist);
			if (Model.HP <= 0) { Die(); }
		}

		public void Die() {
			Debug.Log($"{Model.Name} is die");
			OnDestroy();
		}

		private void OnDestroy() { gameObject.SetActive(false); }
	}
}