﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour {

	public float shipSpeed = 1.0f;
	public float boundaryValue;
	public GameObject shot;
	public GameObject shipExplosion;

	// Update is called once per frame
	void Update() {
		// Move!
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * shipSpeed);
		Vector3 playerPos = new Vector3(Mathf.Clamp(xPos, -boundaryValue, boundaryValue), transform.position.y, transform.position.z);
		transform.position = playerPos;

		// Shoot!
		if (Input.GetKeyDown("space")) {
			Vector3 shotPos = playerPos + new Vector3(0f, 0f, 1.5f);
			Quaternion shotAngle = Quaternion.Euler(0f, -90f, -90f);
			GameObject newShot;
			newShot = Instantiate(shot, shotPos, shotAngle);
			newShot.GetComponent<ShotMover>().ship = gameObject;
			//newShot.GetComponent<ShotMover>().focusLevel = 1; /** Make it pull from attention **/
			newShot.GetComponent<ShotMover>().focusLevel = GM.instance.getAttention();

			GM.instance.playLaserSound();
		}
	}

	private void OnCollisionEnter(Collision collision) {
		Instantiate(shipExplosion, this.transform.position, Quaternion.identity);

		GM.instance.playShipExplosion();
		GM.instance.loseLife();

		Destroy(collision.gameObject);
		Destroy(this.gameObject);
		GM.instance.recreateShip();
	}
}