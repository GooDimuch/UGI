using System;
using UnityEngine;

namespace UGI_Test_1 {
	public abstract class BaseController<T, E> : MonoBehaviour where T : MonoBehaviour where E : BaseModel {
		private T _view;

		public T View {
			get {
				if (_view == null) { _view = InitView(); }
				return _view;
			}
		}

		[SerializeField] private E _model;

		public E Model {
			get {
				if (_instantiate) return _model;
				_model = Instantiate(_model);
				_instantiate = true;
				return _model;
			}
		}

		private bool _instantiate;

		[TextArea(1, 10)] [ReadOnly] [SerializeField] private string DebugModel;

		protected void Awake() {
			if (View == null) { _view = InitView(); }
		}

		protected void Update() {
			SyncViewModel(View, Model);
			DebugModel = Model?.ToFullString();
		}

		private T InitView() {
			var view = GetComponent<T>();
			BindModelAndView(view, Model);
			return view;
		}

		protected abstract void BindModelAndView(T view, E model);

		protected abstract void SyncViewModel(T view, E model);

		public override string ToString() => Model.ToString();
	}
}