using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	public Transform Respawnarea;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col){

		col.transform.position = Respawnarea.position;
	
	}
}
