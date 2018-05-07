using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToKill : MonoBehaviour {

	// Public variables
	public float armorClass;
	public GameObject thisExplosion;
	public float setLevel;

	// Private variables
//	private DisplayData myHeadset;

	void Start () {
//		myHeadset = Camera.current.GetComponent<DisplayData> ();
	}

	void OnCollisionEnter (Collision other) {
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