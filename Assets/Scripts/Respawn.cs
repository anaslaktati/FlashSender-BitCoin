using UnityEngine;
using System.Collections;


public class Respawn : MonoBehaviour {

	public GameObject Player;
	public Transform RespawnPoint;
	private Camera2DFollow cam;
	private Transform CameraTarget;



	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
		Instantiate (Player, RespawnPoint.position, Quaternion.identity);
		cam = Camera.main.GetComponent<Camera2DFollow>();
		CameraTarget = GameObject.FindGameObjectWithTag ("Player").transform;
		cam.target = CameraTarget;


	}
}