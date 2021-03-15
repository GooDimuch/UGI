using System.Linq;
using UnityEngine;

namespace UGI_Test_2 {
	[CreateAssetMenu(fileName = "New_Hero_Icon", menuName = "ScriptableObjects/HeroIcon")]
	public class HeroIconModel : ScriptableObject {
		public string Name;
		public int Level;
		public float Exp;

		public HeroIconModel(string name, int level, float exp) {
			Name = name;
			Level = level;
			Exp = exp;
		}

		public override string ToString() =>
				string.Join(", ", GetType().GetFields().Select(info => $"{info.Name}: {info.GetValue(this)}"));
	}
}