using System.Linq;
using UnityEngine;

namespace UGI_Test.UGI_Test_2 {
	[CreateAssetMenu(fileName = nameof(HeroIconModel),
			menuName = "ScriptableObjects/Task_2/" + nameof(HeroIconModel))]
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