namespace UGI_Test_1 {
	public interface IDamageable {
		float HP { get; set; }

		void TakeDamage(float damage, Ammo.Type damageType);

		void Die();
	}
}