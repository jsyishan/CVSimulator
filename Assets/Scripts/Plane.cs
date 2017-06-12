using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

	public float speed;
	public float torp_speed;
	public int torp_num;
	public bool torp_isShrink;

	void Awake () {
		speed = Manager.planedata.speed;
		torp_speed = Manager.planedata.torp_speed;
		torp_num = Manager.planedata.torp_num;
		torp_isShrink = Manager.planedata.torp_isShrink;
	}

	void Start () {
	
	}

	void Update () {
		
	}
}
