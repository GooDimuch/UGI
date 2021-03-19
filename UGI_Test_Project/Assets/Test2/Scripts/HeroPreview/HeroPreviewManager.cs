using System;
using UnityEngine;

namespace UGI_Test.UGI_Test_2 {
	public class HeroPreviewManager : MonoBehaviour {
		public HeroIconScrollAdapter HeroIconScrollAdapter;

		private HeroPreviewController _selectedHeroPreview;


		[SerializeField] private float slowSpeedRotation = 0.03f;
		[SerializeField] private float speedRotationTouch = 0.03f;
		[SerializeField] private float speedRotationMouse = 0.3f;
		private bool _isRotating = false;

		private Rigidbody _rb;

		private void Start() { }

		private void Update() {
			if (HeroIconScrollAdapter.SelectedItem != null &&
					HeroIconScrollAdapter.SelectedItem.Model.HeroId != _selectedHeroPreview?.Model.HeroId) {
				ChangeHeroPreview(HeroIconScrollAdapter.SelectedItem.Model.HeroId);
			}
			RotateHeroPreview();
		}

		private void ChangeHeroPreview(int id) {
			DestroyOldHeroPreview();
			CreateNewHeroPreview(id);
		}

		private void DestroyOldHeroPreview() {
			if (_selectedHeroPreview != null) { Destroy(_selectedHeroPreview.gameObject); }
			_selectedHeroPreview = null;
		}

		private void CreateNewHeroPreview(int id) {
			var prefab = Resources.Load(HeroPathManager.Instance.HeroData[id].HeroPreviewPath) as GameObject ??
					throw new Exception(
							$"Can't find prefab for {HeroPathManager.Instance.HeroData[id].HeroPreviewPath}\"");
			var go = Instantiate(prefab, transform);
			var viewController = go.GetComponentForce<HeroPreviewController>();
			_rb = go.GetComponentForce<Rigidbody>();
			_rb.useGravity = false;

			_selectedHeroPreview = viewController;
		}

		private void RotateHeroPreview() {
			if (Input.GetMouseButtonDown(0)) { _isRotating = true; }
			if (Input.GetMouseButtonUp(0)) { _isRotating = false; }
			if (Input.GetMouseButton(0) && _isRotating) {
				var speedRotation = 0f;
				var touchDeltaPosition = 0f;

				if (Input.touchCount == 1) {
					touchDeltaPosition = Input.GetTouch(0).deltaPosition.x;
					speedRotation = speedRotationTouch;
				}
				else {
					touchDeltaPosition = Input.GetAxis("Mouse X");
					speedRotation = speedRotationMouse;
				}

				_rb.AddTorque(transform.up * -touchDeltaPosition * speedRotation * Time.deltaTime);
			}
			else { _rb.angularDrag = slowSpeedRotation; }
		}
	}
}