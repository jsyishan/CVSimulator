using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float maxSpeed;
	public float helm;

	private float speed;
	private Rigidbody rb;

	void Start () {
		maxSpeed = Manager.enemydata.speed;
		helm = Manager.enemydata.helm;

		speed = 0f;
		rb = this.GetComponent<Rigidbody> ();
	}

	void Update () {
		if (speed < maxSpeed) {
			rb.AddForce (transform.up * 2.5f, ForceMode.Force);
			speed = rb.velocity.z;
			Debug.Log (speed);
		}
	}
}
