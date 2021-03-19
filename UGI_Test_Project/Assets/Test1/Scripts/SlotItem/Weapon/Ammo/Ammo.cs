namespace UGI_Test.UGI_Test_1 {
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
}