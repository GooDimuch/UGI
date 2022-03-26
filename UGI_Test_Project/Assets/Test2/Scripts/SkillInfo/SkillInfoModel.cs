using UnityEngine;

namespace UGI_Test.UGI_Test_2 {
	[CreateAssetMenu(fileName = nameof(SkillInfoModel),
			menuName = "ScriptableObjects/Task_2/" + nameof(SkillInfoModel))]
	public class SkillInfoModel : ScriptableObject {
		public string SkillName;
		[TextArea(1, 10)] public string SkillInfo;
	}
}