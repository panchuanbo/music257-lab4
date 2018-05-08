using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMover : MonoBehaviour {

	// Public variables
	public float shotSpeed;
	public GameObject ship;
	public float range;
	public float focusLevel;

	// Update is called once per frame
	void Update () {
		Vector3 newPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + shotSpeed);
		transform.position = newPos;

		float distanceShot = transform.position.z - ship.transform.position.z;
		if (distanceShot > range) {
			Destroy(gameObject);
		}
	}

	// Destroy object when it hits something
	void OnCollisionEnter (Collision other) {
		Destroy (gameObject);
	}
}
