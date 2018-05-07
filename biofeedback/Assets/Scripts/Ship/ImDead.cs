using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImDead : MonoBehaviour {

	// Public variables
	public GameObject thisExplosion;

	void OnCollisionEnter (Collision other) {
		Instantiate (thisExplosion, transform.position, Quaternion.identity);
		//Play explosion sound
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
