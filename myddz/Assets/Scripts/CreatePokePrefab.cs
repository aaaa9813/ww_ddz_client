using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreatePokePrefab : MonoBehaviour {

	// Use this for initialization
	public GameObject gb;
	void Start () {
	

		ModifyPrefab ();

	}

	//创建多个预制件
	void CreateMulPrefab()
	{
		Object obj;
		for (int i = 0; i < 4; i++) {
			for(int j = 0; j < 13; j++)
			{

				obj = PrefabUtility.CreateEmptyPrefab(string.Format("Assets/Resources/poke_prefab/Poke_{0}_{1}.prefab", i,j));
				PrefabUtility.ReplacePrefab(gb.gameObject, obj);

			}
		}
	}

	//批量修改预制件
	void ModifyPrefab()
	{
		string[] ids = AssetDatabase.FindAssets("", new string[] { "Assets/Resources/poke_prefab" });

		for (int i = 0; i < ids.Length; i++) {

			string path = AssetDatabase.GUIDToAssetPath(ids[i]);
			Debug.Log(path);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[MenuItem("Tools/BatchPrefab All Children")]
	public static void BatchPrefab(){
		Transform tParent = ((GameObject)Selection.activeObject).transform;
		Object tempPrefab;
		int i = 0;
		foreach(Transform t in tParent){
			tempPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Resources/poke_prefab/prefab" + i +".prefab");
			tempPrefab = PrefabUtility.ReplacePrefab(t.gameObject, tempPrefab);
			i ++;
		}
	}


	[ExecuteInEditMode]
	[MenuItem("Tools/RecordPoint Add Flame")]
	private static void RecordPointAddFlame()
	{
		GameObject twoSphere = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/TwoSphere.prefab", typeof(GameObject)) as GameObject;

		string[] ids = AssetDatabase.FindAssets("t:Prefab", new string[] { "Assets/Resources/Prefabs" });
		for (int i = 0; i < ids.Length; i++)
		{
			string path = AssetDatabase.GUIDToAssetPath(ids[i]);
			Debug.Log(path);
			if (!path.Contains("TwoCube"))
			{
				continue;
			}
			GameObject originTwoCube = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject;
			GameObject twoCube = PrefabUtility.InstantiatePrefab(originTwoCube) as GameObject;

			foreach (Transform item in twoCube.transform)
			{
				if (item.Find("TwoSphere") == null)
				{
					GameObject ts = PrefabUtility.InstantiatePrefab(twoSphere) as GameObject;
					ts.transform.parent = item;
				}
			}

			var newprefab = PrefabUtility.CreateEmptyPrefab("Assets/Resources/Prefabs/TwoCube.prefab");
			PrefabUtility.ReplacePrefab(twoCube, newprefab, ReplacePrefabOptions.Default);
		}

		AssetDatabase.SaveAssets();
		Debug.Log("Done");
	}
}
