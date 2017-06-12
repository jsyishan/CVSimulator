using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Planedata {
	public float speed;
	public float torp_speed;
	public int torp_num;
	public bool torp_isShrink;
	public int group;
}

public class Enemydata {
	//public float length;
	public float speed;
	public float helm;
}

public class Manager : MonoBehaviour {

	private JSONObject data;

	public static Planedata planedata = new Planedata ();
	public static Enemydata enemydata = new Enemydata ();

	public static List<GameObject> tbs;

	void Awake () {
		var jsonString = Application.dataPath + "/data/data.json";
		if (File.Exists (jsonString)) {
			data = new JSONObject (File.ReadAllText (jsonString));
		} else {
			Debug.LogError ("err -> json file: " + jsonString + " not exists. ");
		}
		loadData ();
	}

	void Start() {


		initUI ();
	}

	private void initUI () {
		
		tbs = new List<GameObject> ();
		for (int i = 1; i <= planedata.group; i++) {
			var go = Instantiate (Resources.Load ("tb")) as GameObject;
			go.transform.SetParent (GameObject.Find ("ui").transform);
			var refPos = go.transform.parent.GetChild (0).GetComponent<RectTransform> ().position;
			go.GetComponent<RectTransform> ().SetPositionAndRotation (new Vector3 (refPos.x + 120 * i, refPos.y, refPos.z), Quaternion.identity);
			go.name = "tb" + i.ToString();
			go.GetComponentInChildren<Text> ().text = go.name;
			tbs.Add (go);
		}
	}

	private void loadData () {
		
		var plane = data.GetField ("plane");

		planedata.speed = plane.GetField ("speed").f;
		planedata.group = (int) plane.GetField ("group").f;

		var torp = plane.GetField ("torp");
		planedata.torp_speed = torp.GetField ("speed").f;
		if (torp.GetField ("type").str == "us") {
			planedata.torp_isShrink = false;
			planedata.torp_num = 6;
		} else {
			planedata.torp_isShrink = true;
			planedata.torp_num = 4;
		}

		var enemy = data.GetField ("enemy");

		//enemydata.length = enemy.GetField ("length").f;
		enemydata.speed = enemy.GetField ("speed").f;
		enemydata.helm = enemy.GetField ("helm").f;

	}

	void Update () {
		
	}
}
