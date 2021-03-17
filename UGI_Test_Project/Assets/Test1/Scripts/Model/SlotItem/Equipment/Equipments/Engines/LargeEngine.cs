using UnityEngine;

namespace UGI_Test_1 {
	[CreateAssetMenu(fileName = nameof(LargeEngine),
			menuName = "ScriptableObjects/Task_1/" +
					nameof(SlotItem) +
					"s/" +
					nameof(Equipment) +
					"s/" +
					nameof(Engine) +
					"s/" +
					nameof(LargeEngine))]
	public class LargeEngine : Engine {
		public LargeEngine() : base(nameof(LargeEngine),
				EquipmentConstants.LARGE_ENGINE_HP,
				ShipSlot.Type.Heavy,
				EquipmentConstants.LARGE_ENGINE_SPEED) { }
	}
}