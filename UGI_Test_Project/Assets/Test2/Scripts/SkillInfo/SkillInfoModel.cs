using UnityEngine;

namespace UGI_Test_2 {
	[CreateAssetMenu(fileName = "New_Skill_Info", menuName = "ScriptableObjects/SkillInfo")]
	public class SkillInfoModel : ScriptableObject {
		public string SkillName;
		[TextArea(1, 10)] public string SkillInfo;
	}
}