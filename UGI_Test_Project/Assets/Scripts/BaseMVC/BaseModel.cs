using UnityEngine;

namespace UGI_Test {
	public class BaseModel : ScriptableObject {
		public virtual string ToFullString() => GetType().Name;
	}
}