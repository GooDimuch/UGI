namespace UGI_Test_1 {
	public class EnergyShieldController : SlotItemController {
		public EnergyShield EnergyShield => Model as EnergyShield;

		protected override void OnAdded() {
			base.OnAdded();
			Spaceship.Model.ObtainedPlasmaResist += EnergyShield.PlasmaBeamResist;
		}

		protected override void OnRemoved() {
			base.OnRemoved();
			Spaceship.Model.ObtainedPlasmaResist -= EnergyShield.PlasmaBeamResist;
		}
	}
}