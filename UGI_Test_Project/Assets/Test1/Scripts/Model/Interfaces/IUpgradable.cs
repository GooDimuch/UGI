namespace UGI_Test_1 {
	public interface IUpgradable {
		int Level { get; set; }
		void SetLevel(int level);
		void Upgrade(int addLevel);
	}
}