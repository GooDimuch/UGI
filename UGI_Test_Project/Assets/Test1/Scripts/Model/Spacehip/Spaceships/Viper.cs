using System.Collections.Generic;
using UnityEngine;

namespace UGI_Test_1 {
	[CreateAssetMenu(fileName = "Viper", menuName = "ScriptableObjects/Task_1/Spaceships/Viper")]
	public class Viper : Spaceship {
		public Viper() : base(nameof(Viper),
				100,
				new List<ShipSlot.Type> {ShipSlot.Type.Heavy, ShipSlot.Type.Heavy}) { }

		// public override void SetLevel(int level) {
		// 	base.SetLevel(level);
		//
		// 	//в зависимости от уровня повышаются их характеристики
		// 	HP = (HP * level / 2f).TI();
		// }
	}
}