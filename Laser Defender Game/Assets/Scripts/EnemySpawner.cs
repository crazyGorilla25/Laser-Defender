using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width;
	public float height;
	float xmin;
	float xmax;
	bool right;
	public float speed;
	public float spawnDelay;
	// Use this for initialization
	void Start () {
		SpawnUntilFull ();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 left = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 right = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xmin = left.x+(width/2);
		xmax = right.x-(width/2);
}
	void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height,1));
	}
	// Update is called once per frame
	void Update () {
		if (right) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else if (!right) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (transform.position.x > xmax) {
			right = false;
		}
		if (transform.position.x < xmin) {
			right = true;
		}

		if (AllMembersDead ()) {
			SpawnUntilFull ();
		}
	}
	Transform nextFreePostion(){
		foreach (Transform childPosition in transform) {
			if (childPosition.childCount == 0) {
				return childPosition;
			}
		}
		return null;
	}
	bool AllMembersDead(){
		foreach (Transform childPosition in transform){
			if (childPosition.childCount > 0) {
				return false;
			}
		}
		return true;
	}
		void SpawnUntilFull(){
		Transform freePostion = nextFreePostion();
		if (freePostion) {
			GameObject enemy = Instantiate (enemyPrefab, freePostion.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePostion;
		}
		if(nextFreePostion()){
			Invoke ("SpawnUntilFull", spawnDelay);
		}
		}

}