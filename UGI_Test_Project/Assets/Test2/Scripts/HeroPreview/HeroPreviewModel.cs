using UnityEngine;

namespace UGI_Test.UGI_Test_2 {
	[CreateAssetMenu(fileName = nameof(HeroPreviewModel),
			menuName = "ScriptableObjects/Task_2/" + nameof(HeroPreviewModel))]
	public class HeroPreviewModel : BaseModel {
		public int HeroId;
	}
}