using UnityEngine;

namespace UGI_Test_1 {
	public class BaseModel : ScriptableObject {
		public virtual string ToFullString() => GetType().Name;
	}
}