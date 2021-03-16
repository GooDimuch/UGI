namespace UGI_Test_1 {
	public class SlotItemController : BaseController<SlotItemView, SlotItem>, IDamageableController {
		protected override void BindModelAndView(SlotItemView view, SlotItem model) { }

		public void TakeDamage(float damage, Ammo.Type damageType) { throw new System.NotImplementedException(); }

		public void Die() { throw new System.NotImplementedException(); }
	}
}