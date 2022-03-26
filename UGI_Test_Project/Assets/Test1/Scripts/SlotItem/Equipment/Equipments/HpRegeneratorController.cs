using UnityEngine;

namespace UGI_Test.UGI_Test_1 {
	public class HpRegeneratorController : SlotItemController {
		public HpRegenerator HpRegenerator => Model as HpRegenerator;
		public int AmountEnergyShields { get; private set; }

		public void Update() {
			if (Spaceship != null) {
				AmountEnergyShields = Spaceship.CountItem(typeof(EnergyShield));
				Spaceship.Model.HP += AmountEnergyShields * HpRegenerator.RegenPerTic * Time.deltaTime;
			}
		}

		protected override void OnAdded() { base.OnAdded(); }

		protected override void OnRemoved() { base.OnRemoved(); }
	}
}