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
			[SerializeField] private GameObject HeroPreviewPrefab;
			[SerializeField] private ScriptableObject HeroIconModel;
			public string HeroPreviewPath => GetPathByResources(HeroPreviewPrefab);
			public string HeroIconPath => GetPathByResources(HeroIconModel);
		}

		public List<HeroPathData> HeroData = new List<HeroPathData>();

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
	}
}