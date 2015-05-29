using UnityEngine;
using System.Collections;

public class WheelSpin : MonoBehaviour {
	
	public float speed = 1.0f;
	public string axisName = "Horizontal";
	

	void Start () {
	}
	

	void Update () {
		
		if(Input.GetKey(KeyCode.UpArrow)) {
			// Counter-clockwise
			transform.Rotate(0, 0, 3.0f); 
		}
		
		if(Input.GetKey(KeyCode.DownArrow)) {
			// clockwise
			transform.Rotate(0, 0, -3.0f);
		}
		
	}
}