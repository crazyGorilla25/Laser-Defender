using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float padding;
	float xmin;
	float xmax;
	public GameObject laser;
	public float laserSpeed;
	public float fireRate= 0.2f;
	public int health = 10;
	public AudioClip fire;
	void Start(){
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 left = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 right = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xmin = left.x+padding;
		xmax = right.x-padding;
	}
	void Fire(){
		GameObject playerLaser = Instantiate (laser, transform.position, Quaternion.identity) as GameObject; 
		playerLaser.GetComponent<Rigidbody2D> ().velocity = Vector3.up * laserSpeed;
		AudioSource.PlayClipAtPoint(fire,transform.position);
	}
	void Die(){
		Application.LoadLevel("Win");
		Destroy (this.gameObject);
	}
	void Update(){
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000000001f, fireRate);
	}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}

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
}