using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

	public float enemySpeed = 0.05f;

	private Quaternion kRotation = Quaternion.Euler(0f, 180f, 0f);

	// Update is called once per frame
	void Update() {
		// Move!
		float zPos = transform.position.z - enemySpeed;
		Vector3 enemyPos = new Vector3(transform.position.x, 0, zPos);
		transform.position = enemyPos;
		transform.rotation = kRotation;

		// TODO: Remove Hardcode later...
		if (enemyPos.z < -9) {
			GM.instance.loseLife();
			Destroy(this.gameObject);
		}
	}
}
