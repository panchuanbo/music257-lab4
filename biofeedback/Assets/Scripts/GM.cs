using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	// MARK: - Singleton

    public static GM instance = null;

	// MARK: - Public Instance

	public int lives = 3;
	public GameObject basicEnemy;

	// MARK: - Private Instance

	private DisplayData headset = null;

	// MARK: - Game Management

	private void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		Setup();
	}

	public void Setup() {
		//this.headset = Camera.current.GetComponent<DisplayData>();
		spawnEnemy();
	}

	private void Update() {
		// spawnEnemy();
	}

	private void spawnEnemy() {
		Vector3 enemyPos = new Vector3(Random.Range(-20, 20), 0f, 8.83f);
		Quaternion shipAngle = Quaternion.Euler(0f, 180f, 0f);
		Instantiate(basicEnemy, enemyPos, shipAngle);
	}
}
