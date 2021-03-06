namespace UGI_Test_1 {
	public interface IDamageable {
		int HP { get; set; }

		void TakeDamage(int damage);
		void Die();
	}
}