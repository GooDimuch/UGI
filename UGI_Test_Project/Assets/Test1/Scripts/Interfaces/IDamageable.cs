namespace UGI_Test.UGI_Test_1 {
	public interface IDamageable {
		float MaxHP { get; set; }
		float HP { get; set; }
	}

	public interface IDamageableController {
		void TakeDamage(float damage, Ammo.Type damageType);

		void Die();
	}
}