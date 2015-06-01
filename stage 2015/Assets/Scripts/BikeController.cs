using UnityEngine;
using System.Collections;

public class BikeController : MonoBehaviour {

	public GameObject go;
	public int power;
	public int reverse;
	public Vector2 force;
	private Vector3 trigfunction;
	public float maxSpeed = 200f;
	private Rigidbody2D rigidbody;
	private Transform transform;


	void Awake (){
	
		rigidbody = go.GetComponent<Rigidbody2D>();
		transform = go.GetComponent<Transform> ();

	}
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update ()
	{
		trigfunction = transform.TransformDirection(Vector3.right); 
		force.Set(trigfunction.x,trigfunction.y);
		
		if (Input.GetKey(KeyCode.UpArrow))
			rigidbody.AddForce(force*power);
		else if (Input.GetKey(KeyCode.DownArrow))
			rigidbody.AddForce(force*-reverse);
	}
	
	void FixedUpdate ()
	{
		if(rigidbody.velocity.magnitude > maxSpeed) {
			rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
		}
	}
}
/**
//reference to the wheel joints
HingeJoint2D Hinge; 
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
public Transform wheel;

// Use this for initialization 
void Start () { 
	
	//set the center of mass of the car
	
	Rigidbody2D rearWheel = GameObject.Find("rearWheel").GetComponent<Rigidbody2D>();
	Rigidbody2D wheel = GameObject.Find("wheel").GetComponent<Rigidbody2D>();
	
	Transform centerOfMass = GameObject.Find("centerOfMass").GetComponent<Transform>();
	centerOfMass = GetComponent<Transform>();
	//get the wheeljoint components
	
	
	//get the reference to the motor of rear wheels joint
	JointMotor2D motorBack = Hinge.motor; 
}  

//all physics based assignment done here
void FixedUpdate(){
	//add ability to rotate the car around its axis
	torqueDir = Input.GetAxis("Horizontal"); 
	if(torqueDir!=0){ 
		GetComponent<Rigidbody2D>().AddTorque(3*Mathf.PI*torqueDir, ForceMode2D.Force);
	} 
	else{
		GetComponent<Rigidbody2D>().AddTorque(0);
	}
	
	//determine the cars angle wrt the horizontal ground
	slope = transform.localEulerAngles.z;
	
	//convert the slope values greater than 180 to a negative value so as to add motor speed 
	//based on the slope angle
	if(slope>=180)
		slope = slope - 360;
	//horizontal movement input. same as torqueDir. Could have avoided it, but decided to 
	//use it since some of you might want to use the Vertical axis for the torqueDir
	dir = Input.GetAxis("Horizontal"); 
	
	//explained in the post in detail
	//check if there is any input from the user
	if(dir!=0)
		//add speed accordingly
		motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed -(dir*accelerationRate - gravity*Mathf.Sin((slope * Mathf.PI)/180)*80 )*Time.deltaTime, maxFwdSpeed, maxBwdSpeed);
	//if no input and car is moving forward or no input and car is stagnant and is on an inclined plane with negative slope
	if((dir==0 && motorBack.motorSpeed < 0 ) ||(dir==0 && motorBack.motorSpeed==0 && slope < 0)){
		//decelerate the car while adding the speed if the car is on an inclined plane
		motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed - (decelerationRate - gravity*Mathf.Sin((slope * Mathf.PI)/180)*80)*Time.deltaTime, maxFwdSpeed, 0);
	}
	//if no input and car is moving backward or no input and car is stagnant and is on an inclined plane with positive slope
	else if((dir==0 && motorBack.motorSpeed > 0 )||(dir==0 && motorBack.motorSpeed==0 && slope > 0)){
		//decelerate the car while adding the speed if the car is on an inclined plane
		motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed -(-decelerationRate - gravity*Mathf.Sin((slope * Mathf.PI)/180)*80)*Time.deltaTime, 0, maxBwdSpeed);
	}
	
	
	
	//apply brakes to the car
	if (Input.GetKey(KeyCode.Space) && motorBack.motorSpeed > 0){
		motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed - brakeSpeed*Time.deltaTime, 0, maxBwdSpeed); 
	}
	else if(Input.GetKey(KeyCode.Space) && motorBack.motorSpeed < 0){ 
		motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed + brakeSpeed*Time.deltaTime, maxFwdSpeed, 0);
	}
	//connect the motor to the joint
	Hinge.motor = motorBack; 
	
  }
}
**/