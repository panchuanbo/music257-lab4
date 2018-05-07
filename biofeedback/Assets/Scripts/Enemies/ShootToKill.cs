using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToKill : MonoBehaviour {

	// Public variables
	public float armorClass;
	public GameObject thisExplosion;
	public float setLevel;

	void Start () {}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag != "Laser") return;

		if (setLevel > armorClass) {
			Instantiate (thisExplosion, transform.position, Quaternion.identity);
			//Play explosion sound
			Destroy(other.gameObject);
			Destroy(gameObject);
		} else {
			//Play "thunk" sound
		}
	}
}