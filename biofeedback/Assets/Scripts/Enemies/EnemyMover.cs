using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

	public float enemySpeed = 0.05f;

	// Update is called once per frame
	void Update() {
		// Move!
		float zPos = transform.position.z - enemySpeed;
		Vector3 enemyPos = new Vector3(transform.position.x, transform.position.y, zPos);
		transform.position = enemyPos;
	}
}
