using UnityEngine;

namespace UGI_Test_1 {
	[CreateAssetMenu(fileName = nameof(SmallEngine),
			menuName = "ScriptableObjects/Task_1/" +
					nameof(SlotItem) +
					"s/" +
					nameof(Equipment) +
					"s/" +
					nameof(Engine) +
					"s/" +
					nameof(SmallEngine))]
	public class SmallEngine : Engine {
		public SmallEngine() : base(nameof(SmallEngine),
				EquipmentConstants.SMALL_ENGINE_HP,
				ShipSlot.Type.Medium,
				EquipmentConstants.SMALL_ENGINE_SPEED) { }
	}
}