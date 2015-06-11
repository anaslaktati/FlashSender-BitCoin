using UnityEngine; 
using System.Collections; 


public class WheelJointBikeMovement : MonoBehaviour { 
	//reference to the wheel joints
	WheelJoint2D[] wheelJoints; 
	//center of mass of the car
	public Transform centerOfMass;
	//reference tot he motor joint
	JointMotor2D motorBack;  
	//horizontal movement keyboard input
	float dir = 0f; 
	//input for rotation of the car
	float torqueDir = 0f;
	//max fwd speed which the car can move at
	float maxFwdSpeed = -5000;
	//max bwd speed
	float maxBwdSpeed = 2000f;
	//the rate at which the car accelerates
	float accelerationRate = 500;
	//the rate at which car decelerates
	float decelerationRate = -100;
	//how soon the car stops on braking
	float brakeSpeed = 2500f;
	//acceleration due to gravity
	float gravity = 9.81f;
	//angle in which the car is at wrt the ground
	float slope = 0;
	//reference to the wheels
	public Transform rearWheel;
	public Transform frontWheel;

	public int elevation = 5700;
	public int invElevation = -2000;
	
	// Use this for initialization 
	void Start () { 
		//set the center of mass of the car
		GetComponent<Rigidbody2D>().centerOfMass = centerOfMass.transform.localPosition;
		//get the wheeljoint components
		wheelJoints = gameObject.GetComponents<WheelJoint2D>(); 
		//get the reference to the motor of rear wheels joint
		motorBack = wheelJoints[1].motor; 
	}  
	
	//all physics based assignment done here
	void FixedUpdate(){
		slope = transform.localEulerAngles.z;
		dir = Input.GetAxis("Vertical");
		if (dir != 0) {
			motorBack.motorSpeed += dir * -50;
			wheelJoints [1].motor = motorBack;
		} else {
			motorBack.motorSpeed = 0;
			wheelJoints [1].motor = motorBack;
		}
		
		dir = Input.GetAxis("Horizontal");
		if (dir < 0) {
			print ("up");
			frontWheel.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * elevation * Time.deltaTime);
		}
		if (dir > 0) {
			print ("down");
			frontWheel.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * invElevation * Time.deltaTime);
		}
		
	}
	
}