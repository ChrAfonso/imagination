using UnityEngine;
using System.Collections;

public class CarControl : MonoBehaviour {

	public float motorTorque = 1000.0f;
	public float maxTurningDegree = 30.0f;
	public float maxSpeed = 100.0f;

	private bool brake;

	GameObject o_Wheel_L1;
	GameObject o_Wheel_L2;
	GameObject o_Wheel_R1;
	GameObject o_Wheel_R2;

	WheelCollider c_Wheel_L1;
	WheelCollider c_Wheel_L2;
	WheelCollider c_Wheel_R1;
	WheelCollider c_Wheel_R2;

	private float powerInput;
	private Rigidbody carRigidBody;


	void Awake () 
	{
		o_Wheel_L1 = GameObject.Find ("o_Wheel_L1");
		c_Wheel_L1 = GameObject.Find ("c_Wheel_L1").GetComponent<WheelCollider> ();

		o_Wheel_L2 = GameObject.Find ("o_Wheel_L2");
		c_Wheel_L2 = GameObject.Find ("c_Wheel_L2").GetComponent<WheelCollider> ();

		o_Wheel_R1 = GameObject.Find ("o_Wheel_R1");
		c_Wheel_R1 = GameObject.Find ("c_Wheel_R1").GetComponent<WheelCollider> ();

		o_Wheel_R2 = GameObject.Find ("o_Wheel_R2");
		c_Wheel_R2 = GameObject.Find ("c_Wheel_R2").GetComponent<WheelCollider> ();

		carRigidBody = GetComponent<Rigidbody> ();
		Vector3 center_of_mass = carRigidBody.centerOfMass;
		center_of_mass = center_of_mass + (-1.0f * transform.up.normalized) * 2.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		brake = Input.GetKey ("space");
		//Wheel_L1.motorTorque = 0.0f;
		//Wheel_R1.motorTorque = 0.0f;

	}

	void FixedUpdate ()
	{
		powerInput = Input.GetAxis ("Vertical") * motorTorque;
		float targetTurning = maxTurningDegree * Input.GetAxis ("Horizontal");

		c_Wheel_L1.steerAngle = targetTurning;
		c_Wheel_R1.steerAngle = targetTurning;

		float slip = (0.01f + 0.022f/(carRigidBody.velocity.magnitude+1.0f))*0.5f;


		WheelFrictionCurve curve = c_Wheel_L1.sidewaysFriction;
		curve.stiffness = slip;


		float currentSpeed = carRigidBody.velocity.magnitude;

		Debug.Log ("Speed: " + currentSpeed);

		if (currentSpeed > maxSpeed) {
			carRigidBody.velocity = carRigidBody.velocity.normalized * maxSpeed;
		}


		float f = 1 - (maxSpeed - carRigidBody.velocity.magnitude) / maxSpeed;

		carRigidBody.AddForce (transform.up.normalized * -1.0f * f * 0.09f);
	//	c_Wheel_L1.sidewaysFriction = curve;

	//	c_Wheel_L2.sidewaysFriction = curve;
	//	c_Wheel_R1.sidewaysFriction = curve;
	//	c_Wheel_R2.sidewaysFriction = curve;

		if (!brake) {

			//float f = 1.0f;
			//(maxSpeed - carRigidBody.velocity.magnitude) / maxSpeed;

			c_Wheel_L1.brakeTorque = 0.0f;
			c_Wheel_L2.brakeTorque = 0.0f;
			c_Wheel_R1.brakeTorque = 0.0f;
			c_Wheel_R2.brakeTorque = 0.0f;

			c_Wheel_L2.motorTorque = 0.4f * powerInput;
			c_Wheel_R2.motorTorque = 0.4f * powerInput;

			c_Wheel_L1.motorTorque = powerInput;
			c_Wheel_R1.motorTorque = powerInput;

		} else {


			c_Wheel_L1.brakeTorque = motorTorque;
			c_Wheel_L2.brakeTorque = motorTorque;
			c_Wheel_R1.brakeTorque = motorTorque;
			c_Wheel_R2.brakeTorque = motorTorque;
			
			c_Wheel_L2.motorTorque = 0.0f;
			c_Wheel_R2.motorTorque = 0.0f;

		
		}



		Vector3 pos;
		Quaternion rot;

		c_Wheel_L1.GetWorldPose(out pos, out rot); 
		o_Wheel_L1.transform.position = pos;
		o_Wheel_L1.transform.rotation = rot;

		c_Wheel_L2.GetWorldPose(out pos, out rot); 
		o_Wheel_L2.transform.position = pos;
		o_Wheel_L2.transform.rotation = rot;

		c_Wheel_R1.GetWorldPose(out pos, out rot); 
		o_Wheel_R1.transform.position = pos;
		o_Wheel_R1.transform.rotation = rot;

		c_Wheel_R2.GetWorldPose(out pos, out rot); 
		o_Wheel_R2.transform.position = pos;
		o_Wheel_R2.transform.rotation = rot;

		//o_Wheel_L1.transform.rotation = c_Wheel_L1.GetWorldPose()
	
	}
		/*
		if (brake) {
			Wheel_L2.brakeTorque = 10.0f;
			Wheel_L1.brakeTorque = 10.0f;
			Wheel_R1.brakeTorque = 10.0f;
			Wheel_R2.brakeTorque = 10.0f;
			
			Wheel_L2.motorTorque = 0.0f;
			Wheel_R2.motorTorque = 0.0f;

		} else {
			Wheel_L2.brakeTorque = 0.0f;
			Wheel_L1.brakeTorque = 0.0f;
			Wheel_R1.brakeTorque = 0.0f;
			Wheel_R2.brakeTorque = 0.0f;
			
		/*
		//transform.forward = carRigidbody.velocity.normalized;

		if (currentTurning != targetTurning) {
			float turn = targetTurning - currentTurning;
			if ((turn > 0 && turn < 0.1) || (turn < 0 && turn > -0.1)) {
				turn = 0;
				currentTurning = targetTurning;
			}
			currentTurning = currentTurning + turnSpeed * turn;

			if (currentTurning > maxTurningDegree)
				currentTurning = maxTurningDegree;

			if (currentTurning < (maxTurningDegree * -1))
				currentTurning = maxTurningDegree * -1;

			leftWheel.GetComponent<Collider>.

			Vector3 rotation = leftWheel.transform.eulerAngles;
			rotation.y = currentTurning + transform.rotation.y;
			leftWheel.transform.eulerAngles = rotation;
			rightWheel.transform.eulerAngles = rotation;
		}

		float currentAccel = powerInput * maxAcceleration;

		float currentSpeed = carRigidbody.velocity.z;

		Vector3 AccelVector = transform.forward * currentAccel;
		Vector3 TurningVector = (transform.right * currentSpeed * 0.1f) * currentTurning; 

		carRigidbody.AddForce (AccelVector + TurningVector);
		carRigidbody.AddTorque (TurningVector);

		Debug.Log ("current speed: " + currentSpeed);

	}
	 */


}
