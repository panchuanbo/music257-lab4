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

		float focus = other.gameObject.GetComponent<ShotMover>().focusLevel;

		if (focus >= GM.instance.getAttentionRequired()) {
			Instantiate (thisExplosion, transform.position, Quaternion.identity);
			//Play explosion sound
			Destroy(other.gameObject);
			Destroy(gameObject);

			GM.instance.playEnemyExplosion();
		} else {
			GM.instance.playThunkSound();
		}
	}
}