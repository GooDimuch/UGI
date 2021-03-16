namespace UGI_Test_1 {
	public interface IDamageable {
		float HP { get; set; }
	}

	public interface IDamageableController {
		void TakeDamage(float damage, Ammo.Type damageType);

		void Die();
	}
}