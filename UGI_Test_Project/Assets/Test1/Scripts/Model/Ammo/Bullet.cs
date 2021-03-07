namespace UGI_Test_1 {
	public abstract class Bullet : Ammo {
		protected Bullet(float shotDistance, float damageCoefficient) : base(Type.Bullet,
				shotDistance,
				damageCoefficient) { }
	}

	public class CommonBullet : Bullet {
		public CommonBullet() : base(AmmoConstants.COMMON_BULLET_SHOT_DISTANCE, 1) { }
	}

	public class ArmorPiercingBullet : Bullet {
		public ArmorPiercingBullet() : base(AmmoConstants.ARMOR_PIERCING_BULLET_SHOT_DISTANCE, 2) { }
	}
}