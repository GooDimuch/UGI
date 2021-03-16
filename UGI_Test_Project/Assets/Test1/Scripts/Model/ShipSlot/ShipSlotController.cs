namespace UGI_Test_1 {
	public class ShipSlotController : BaseController<ShipSlotView, ShipSlot> {
		protected override void BindModelAndView(ShipSlotView view, ShipSlot model) {
			view.MeshRenderer.material.color = model.PrefabColor;
		}
	}
}