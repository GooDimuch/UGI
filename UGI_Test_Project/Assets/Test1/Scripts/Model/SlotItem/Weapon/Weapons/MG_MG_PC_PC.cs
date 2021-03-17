using UnityEngine;

namespace UGI_Test_1 {
	[CreateAssetMenu(fileName = nameof(MG_MG_PC_PC),
			menuName = "ScriptableObjects/Task_1/" +
					nameof(SlotItem) +
					"s/" +
					nameof(Weapon) +
					"s/" +
					nameof(MG_MG_PC_PC))]
	public class MG_MG_PC_PC : ComboSlotItem {
		public MG_MG_PC_PC() : base(nameof(MG_MG_PC_PC),
				100,
				ShipSlot.Type.Heavy,
				new MachineGun(),
				new MachineGun(),
				new PlasmaCannon(),
				new PlasmaCannon()) { }
	}
}