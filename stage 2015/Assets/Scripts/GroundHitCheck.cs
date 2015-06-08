using UnityEngine;
using System.Collections;

public class GroundHitCheck : MonoBehaviour {
	
	//flag to find out if the object is grounded
	public GameObject go;
	bool isGrounded = false;
	private playerScript script;

	//Empty gameobject created to determine the bounds/center of the object
	public Transform GroundCheck1;
	//public Transform GroundCheck2; //uncomment this for OverlapArea
	
	//The layer for which the overlap has to be detected 
	public LayerMask ground_layers;

	void Awake(){
	
		script = go.GetComponent<playerScript> ();
	}

	void Start(){
	

	}
	//All the Physics related things to be done here
	void FixedUpdate(){
		//check if the empty object created overlaps with the 'ground_layers' within a radius of 1 units
		isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 1, ground_layers);
		Debug.Log ("Grounded: " + isGrounded);
		if (!isGrounded){

			script.enabled = false;
		}
		if (isGrounded){

			script.enabled = true;
		}	

	}
}