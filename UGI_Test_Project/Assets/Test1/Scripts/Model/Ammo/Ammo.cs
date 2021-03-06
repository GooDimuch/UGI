namespace UGI_Test_1 {
	public abstract class Ammo {
		public enum Type {
			Bullet,
			PlasmaBeam,
		}

		public Type AmmoType { get; protected set; }
		public float ShotDistance { get; protected set; }
		public float DamageCoefficient { get; protected set; }

		protected Ammo(Type ammoType, float shotDistance, float damageCoefficient) {
			AmmoType = ammoType;
			ShotDistance = shotDistance;
			DamageCoefficient = damageCoefficient;
		}
	}

	public abstract class Bullet : Ammo {
		protected Bullet(float shotDistance, float damageCoefficient) : base(Type.Bullet,
				shotDistance,
				damageCoefficient) { }
	}

	public abstract class PlasmaBeam : Ammo {
		protected PlasmaBeam(float shotDistance, float damageCoefficient) : base(Type.PlasmaBeam,
				shotDistance,
				damageCoefficient) { }
	}

	public class CommonBullet : Bullet {
		public CommonBullet() : base(AmmoConstants.COMMON_BULLET_SHOT_DISTANCE, 1) { }
	}

	public class ArmorPiercingBullet : Bullet {
		public ArmorPiercingBullet() : base(AmmoConstants.ARMOR_PIERCING_BULLET_SHOT_DISTANCE, 2) { }
	}

	public class CommonPlasmaBeam : PlasmaBeam {
		public CommonPlasmaBeam() : base(AmmoConstants.COMMON_PLASMA_BEAM_SHOT_DISTANCE, 1) { }
	}

	public class ImprovedPlasmaBeam : PlasmaBeam {
		public ImprovedPlasmaBeam() : base(AmmoConstants.IMPROVED_PLASMA_BEAM_SHOT_DISTANCE * 2, 1) { }
	}
}