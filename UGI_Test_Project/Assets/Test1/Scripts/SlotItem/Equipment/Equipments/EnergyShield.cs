using UnityEngine;

namespace UGI_Test_1 {
	[CreateAssetMenu(fileName = nameof(EnergyShield),
			menuName = "ScriptableObjects/Task_1/" +
					nameof(SlotItem) +
					"s/" +
					nameof(Equipment) +
					"s/" +
					nameof(EnergyShield))]
	public class EnergyShield : Equipment {
#region inspector
		[SerializeField] private float _plasmaBeamResist;
#endregion

		public float PlasmaBeamResist { get => _plasmaBeamResist; private set => _plasmaBeamResist = value; }

		public EnergyShield() : this(0.2f) { }

		public EnergyShield(float plasmaBeamResist) : base(nameof(EnergyShield), 100, ShipSlot.Type.Medium) {
			PlasmaBeamResist = plasmaBeamResist;
		}
	}
}