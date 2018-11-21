using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDrawGizmo : MonoBehaviour {

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, 1.5f);
	}
}
