using UnityEngine;
using System.Collections;

public class BikeController : MonoBehaviour {

	Transform[] wheels;


	float enginePower=150.0f;

	float power=0.0f;
	float brake=0.0f;
	float steer=0.0f;

	float maxSteer=25.0f;

	float mass;
	public Rigidbody rb;
	public Rigidbody CenterOfMass;

	void Start () {
	
		rb = GetComponent<Rigidbody>();
		rb.mass = mass;


	}
	

	void Update () {
	
		power = Input.GetAxis ("Vertical") * enginePower * Time.deltaTime * 250;
		steer = Input.GetAxis ("Horizontal") * maxSteer;
		brake = Input.GetKey ("space") ? rb.mass * 0.1f: 0.0f;

		
		if(brake > 0.0f){
			GetCollider(0).brakeTorque=brake;
			GetCollider(1).brakeTorque=brake;
			GetCollider(2).brakeTorque=brake;
			GetCollider(3).brakeTorque=brake;
			GetCollider(2).motorTorque=0.0f;
			GetCollider(3).motorTorque=0.0f;
		} else {
			GetCollider(0).brakeTorque=0;
			GetCollider(1).brakeTorque=0;
			GetCollider(2).brakeTorque=0;
			GetCollider(3).brakeTorque=0;
			GetCollider(2).motorTorque=power;
			GetCollider(3).motorTorque=power;;
		}
	}

	public WheelCollider GetCollider(int n){
		return wheels[n].gameObject.GetComponent<WheelCollider>();
	}
}
