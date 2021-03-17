namespace UGI_Test_1 {
	public class ShipSlotController : BaseController<ShipSlotView, ShipSlot> {
		public SlotItemController SlotItem { get; private set; }

		protected override void BindModelAndView(ShipSlotView view, ShipSlot model) {
			view.MeshRenderer.material.color = model.PrefabColor;
		}

		public void AddItem(SlotItemController item) {
			SlotItem = item;
			Model.Add(item.Model);
			View.Add(item);
		}

		public void Remove(SlotItemController item) {
			SlotItem = null;
			Model.Remove();
			View.Remove(item);
		}
	}
}