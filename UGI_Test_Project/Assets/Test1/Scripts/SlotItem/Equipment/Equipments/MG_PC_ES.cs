using UnityEngine;

namespace UGI_Test.UGI_Test_1 {
	[CreateAssetMenu(fileName = nameof(MG_PC_ES),
			menuName = "ScriptableObjects/Task_1/" +
					nameof(SlotItem) +
					"s/" +
					nameof(Equipment) +
					"s/" +
					nameof(MG_PC_ES))]
	public class MG_PC_ES : ComboSlotItem {
		public MG_PC_ES() : base(nameof(MG_PC_ES),
				100,
				ShipSlot.Type.Heavy,
				new MG_MG_PC_PC(),
				new PlasmaCannon(),
				new EnergyShield()) { }
	}
}