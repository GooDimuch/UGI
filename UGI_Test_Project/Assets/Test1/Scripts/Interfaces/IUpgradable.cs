namespace UGI_Test_1 {
	public interface IUpgradable {
		int Level { get; set; }
	}

	public interface IUpgradableController {
		void SetLevel(int level);
		void Upgrade(int addLevel);
	}
}