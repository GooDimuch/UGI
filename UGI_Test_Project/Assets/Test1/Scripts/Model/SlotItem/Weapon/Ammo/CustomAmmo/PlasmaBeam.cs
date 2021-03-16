namespace UGI_Test_1 {
	public abstract class PlasmaBeam : Ammo {
		protected PlasmaBeam(float shotDistance, float damageCoefficient) : base(Type.PlasmaBeam,
				shotDistance,
				damageCoefficient) { }
	}

	public class CommonPlasmaBeam : PlasmaBeam {
		public CommonPlasmaBeam() : base(AmmoConstants.COMMON_PLASMA_BEAM_SHOT_DISTANCE, 1) { }
	}

	public class ImprovedPlasmaBeam : PlasmaBeam {
		public ImprovedPlasmaBeam() : base(AmmoConstants.IMPROVED_PLASMA_BEAM_SHOT_DISTANCE * 2, 1) { }
	}
}