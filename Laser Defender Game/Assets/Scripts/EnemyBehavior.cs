using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public int health;
	public float speed;
	public float fireFrequency = 0.5f;
	public GameObject BasicEnemyLaser;
	public int scoreValue;
	Score score;
	public AudioClip fire;
	public AudioClip death;
	public bool ableToFire=true;
	void Start(){
		score= GameObject.Find ("Score").GetComponent<Score> ();
	}
	void OnTriggerEnter2D(Collider2D col){
		Projectile laser = col.gameObject.GetComponent<Projectile>();
		if (laser) {
			health -= laser.GetDamage ();
			laser.Hit ();
			if (health <= 0) {
				Die ();
			}
		}
	}
	void Die(){
		Destroy (this.gameObject);
		score.ScorePoints (scoreValue);
		AudioSource.PlayClipAtPoint (death, transform.position);
	}
	void Fire(){
		GameObject enemyLaser = Instantiate(BasicEnemyLaser,transform.position, Quaternion.identity) as GameObject;
		enemyLaser.GetComponent<Rigidbody2D>().velocity += Vector2.down *speed;
		AudioSource.PlayClipAtPoint (fire,transform.position);
	}
	void Update(){
		if(ableToFire){
			float probability = Time.deltaTime * fireFrequency;
				if (Random.value < probability) {
					Fire ();
			}
		}
	}
}
