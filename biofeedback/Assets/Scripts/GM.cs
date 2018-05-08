using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	// MARK: - Singleton

    public static GM instance = null;

	// MARK: - Public Instance

	public int lives = 3;
	public GameObject basicEnemy;
	public GameObject playerShip;

	public AudioClip shipExplosion;
	public AudioClip enemyExplosion;
	public AudioClip thunkSound;
	public AudioClip laserSound;

	public Text livesText;
	public Text messageText;
	public Text gameOverText;
	public Text numDestroyedText;
	public Text attentionRequiredText;

	public Camera mainCamera;

	// MARK: - Private Instance

	private AudioSource audioSource;

	private DisplayData headset = null;
	private int currentState = 0;
	private int enemiesDestroyed = 0;

	private int timeUntilNextSpawn = 1;
	private int spawnInterval = 85;
	private int timeUntilDifficulityIncrease = 600;
	private int attentionRequired = 0;

	private string[] messages = { 
		"You're still alive? Wow.", 
		"Hey... nice going. Kinda...",  
		"Hmmm...",
		"Impressive...",
		"Us messages live in a randomly generated world.",
		"Is there anybody out there?",
		"42",
		"So long and thanks for all for all the fish.",
		"Poppy is behind you."
	};

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
		this.gameOverText.enabled = false;

		this.audioSource = GetComponent<AudioSource>();
		this.headset = this.mainCamera.GetComponent<DisplayData>();

		Instantiate(this.playerShip);
	}

	private void Update() { /* we're fixed :D */ }

	private void FixedUpdate() {
		timeUntilNextSpawn++;

		if (timeUntilNextSpawn % spawnInterval == 0) {
			spawnEnemy();
		}

		if (timeUntilNextSpawn % timeUntilDifficulityIncrease == 0) {
			this.messageText.text = messages[Random.Range(0, messages.Length)];
			timeUntilNextSpawn = 0;
			spawnInterval -= 5;
			attentionRequired += 5;
			attentionRequired = (attentionRequired >= 100) ? 100 : attentionRequired;

			attentionRequiredText.text = "Attention Required: " + attentionRequired;
		}
	}

	private void spawnEnemy() {
		Vector3 enemyPos = new Vector3(Random.Range(-20, 20), 0f, 12f);
		Quaternion shipAngle = Quaternion.Euler(0f, 180f, 0f);
		Instantiate(basicEnemy, enemyPos, shipAngle);
	}

	public void loseLife() {
		this.lives = (this.lives == 0) ? 0 : this.lives - 1;

		this.livesText.text = "Lives: " + this.lives;

		UnityEngine.Debug.Log("Lost Life :(");

		if (this.lives == 0) {
			this.gameOverText.enabled = true;
			Time.timeScale = 0;
		}
	}

	public void recreateShip() {
		Instantiate(this.playerShip);
	}

	// MARK: - Headset Data

	public float getAttention() {
		Debug.Log("My Attention is: " + this.headset.getAttention());
		return this.headset.getAttention();
	}

	// MARK: - Sound

	public void playEnemyExplosion() {
		this.audioSource.PlayOneShot(this.enemyExplosion);
		this.enemiesDestroyed++;

		this.numDestroyedText.text = "Destroyed: " + this.enemiesDestroyed;
	}

	public void playShipExplosion() {
		this.audioSource.PlayOneShot(this.shipExplosion);
	}

	public void playThunkSound() {
		this.audioSource.PlayOneShot(this.thunkSound);
	}

	public void playLaserSound() {
		this.audioSource.PlayOneShot(this.laserSound);
	}
}
