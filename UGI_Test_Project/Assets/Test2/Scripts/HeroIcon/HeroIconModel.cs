using System.Linq;

public class HeroIconModel {
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