using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGI_Test.UGI_Test_2 {
	public class HeroPathManager : Singleton<HeroPathManager> {
		[Serializable]
		public class HeroPathData {
			[ReadOnly] public int HeroId;
			public GameObject HeroPreviewPrefab;
			public ScriptableObject HeroIconModel;
		}

		public List<HeroPathData> HeroData = new List<HeroPathData>();

#if UNITY_EDITOR
		private void OnValidate() {
			for (var i = 0; i < HeroData.Count; i++) { HeroData[i].HeroId = i; }
		}

		private static string GetPathByResources(Object obj) =>
				GetPathByResources(AssetDatabase.GetAssetPath(obj));

		private static string GetPathByResources(string path) =>
				Path.ChangeExtension(path.Substring(path.LastIndexOf(nameof(Resources), StringComparison.Ordinal) +
								nameof(Resources).Length +
								1),
						null);
#endif
	}
}