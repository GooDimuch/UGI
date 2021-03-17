using UnityEngine;

namespace UGI_Test_1 {
	[CreateAssetMenu(fileName = nameof(HpRegenerator),
			menuName = "ScriptableObjects/Task_1/" +
					nameof(SlotItem) +
					"s/" +
					nameof(Equipment) +
					"s/" +
					nameof(HpRegenerator))]
	public class HpRegenerator : Equipment {
#region inspector
		[SerializeField] private float _regenPerTic;
#endregion

		public float RegenPerTic { get => _regenPerTic; private set => _regenPerTic = value; }

		public HpRegenerator() : this(10) { }

		public HpRegenerator(float regenPerTic) : base(nameof(HpRegenerator), 100, ShipSlot.Type.Light) {
			RegenPerTic = regenPerTic;
		}
	}
}