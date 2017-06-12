using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewside : MonoBehaviour {

	private bool left;
	private bool right;
	private bool up;
	private bool down;

	private Transform camTrans;

	public float TRANS_SPEED = 10.0f;

	public float SCALE_SENSETIVE = 10.0f;
	public float MAX_SCALE_SIZE = 55.0f;
	public float MIN_SCALE_SIZE = 22.0f;

	public float ROTATE_SPEED = 10f;
	public float MAX_ROTATE_ANGLE = 90.0f;
	public float MIN_ROTATE_ANGLE = 50.0f;

	void Start () {

		left = false;
		right = false;
		up = false;
		down = false;

		camTrans = Camera.main.transform;
	}

	public void onLeft () { left = true; }  
	public void onRight () { right = true; }
	public void onUp () { up = true; }
	public void onDown () { down = true;}

	public void outLeft () { left = false; }
	public void outRight () { right = false; }
	public void outUp () { up = false; }
	public void outDown () { down = false; }


	void Update () {
		OnMouseScroll ();
		OnMouseTranslate ();
	}

	private void OnMouseTranslate () {
		if (left) { camTrans.position = new Vector3 (camTrans.position.x - Time.deltaTime * TRANS_SPEED, camTrans.position.y, camTrans.position.z); }
		if (right) { camTrans.position = new Vector3 (camTrans.position.x + Time.deltaTime * TRANS_SPEED, camTrans.position.y, camTrans.position.z); }
		if (up) { camTrans.position = new Vector3 (camTrans.position.x , camTrans.position.y, camTrans.position.z + Time.deltaTime * TRANS_SPEED); }
		if (down) { camTrans.position = new Vector3 (camTrans.position.x , camTrans.position.y, camTrans.position.z - Time.deltaTime * TRANS_SPEED); }
	}


	private void OnMouseScroll () {

		var fov = Camera.main.fieldOfView;
		var delta = -Input.GetAxis ("Mouse ScrollWheel") * SCALE_SENSETIVE;
		//Debug.Log (delta);
		fov += delta;
		Camera.main.fieldOfView = Mathf.Clamp (fov, MIN_SCALE_SIZE, MAX_SCALE_SIZE);

		var rotX = camTrans.eulerAngles.x;
		rotX += delta * ROTATE_SPEED;
		if (rotX < MIN_ROTATE_ANGLE) { rotX = MIN_ROTATE_ANGLE; }
		if (rotX > MAX_ROTATE_ANGLE) { rotX = MAX_ROTATE_ANGLE; }
		//Debug.Log (rotX);
		var rot = Quaternion.Euler (rotX, 0, 0);
		//Debug.Log (rot);
		camTrans.rotation = Quaternion.Slerp (camTrans.rotation, rot, Time.deltaTime * 4.0f);
		if (rotX > MIN_ROTATE_ANGLE && rotX < MAX_ROTATE_ANGLE) { 
			camTrans.position = new Vector3 (camTrans.position.x, camTrans.position.y, camTrans.position.z + delta * 2.2f); 
		}
	
	}
		
}
