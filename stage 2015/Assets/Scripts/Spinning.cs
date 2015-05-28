using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {
	
	
	public float rotationSpeed = 20f;
	public string axisName = "Horizontal";
	public Rigidbody2D rb;
	public float invRotationSpeed = -1;
	
	
	void Start () {
		
		
		GetComponent<Transform> ();
	}
	
	
	
	void FixedUpdate () {
		
		
		
		
		
		
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			
			transform.Rotate (0, 0, rotationSpeed);
			
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			
			transform.Rotate (0, 0, invRotationSpeed);
			
		}
	}
}
