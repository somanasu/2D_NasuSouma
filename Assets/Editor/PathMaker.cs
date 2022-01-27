using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// 選択している複数のObjectのパスをLogに表示させます。
/// SceneとProject両方に対応しています。
/// </summary>
public class PathMaker
{
	[MenuItem ("Tools/Util/PathMake")]
	static void PathMake ()
	{
		var targets = Selection.objects;
		if (targets.Length == 0) {
			Debug.LogError ("Nothing Selected!");
			return;
		}
			
		foreach (var target in targets) {
			var path = AssetDatabase.GetAssetOrScenePath (target);
			if (path.Contains (".unity")) {
				// in Scene

				//pathをリセット
				path = "";
				//直接Transformにキャストできないので一回GameObjectにする
				var targetTransfrom = (target as GameObject).transform;
				var targetList = new List<Transform> ();
				targetList.Add (targetTransfrom);
				//親改装をすべて取得
				while (targetTransfrom.parent != null) {
					targetTransfrom = targetTransfrom.parent;
					targetList.Add (targetTransfrom);
				}

				//Pathにつなげる
				for (int i = targetList.Count - 1; i >= 0; i--) {
					path += "/" + targetList [i].name;
				}

				WriteLog (target.name, path);
			} else {
				// in Project
				WriteLog (target.name, path);
			}
		}

	}

	/// <summary>
	/// Projectに存在するObjectの右クリックメニューに対応
	/// </summary>
	[MenuItem ("Assets/Util/PathMake")]
	static void PathMakeInProject ()
	{
		PathMake ();
	}

	/// <summary>
	/// Hierarchyに存在するObjectの右クリックメニューに対応
	/// </summary>
	[MenuItem ("GameObject/Util/PathMake", false, 20)]
	public static void PathMakeInHierarchy ()
	{
		PathMake ();
	}

	static void WriteLog (string name, string path)
	{
		Debug.Log (string.Format ("{0}\n{1}", name, path));
	}
}
