using UnityEngine;
using System.Collections;

public class CarControl : MonoBehaviour {

	public float maxAcceleration = 50.0f;
	public float turnSpeed = 0.5f;
	public float maxSpeed = 1000.0f;

	private float currentTurning = 0.0f;
	private float maxTurningDegree = 45.0f;
	private float targetTurning = 0.0f;
	private bool brake;

	WheelCollider Wheel_L1;
	WheelCollider Wheel_L2;
	WheelCollider Wheel_R1;
	WheelCollider Wheel_R2;

	private float powerInput;
	private Rigidbody carRigidbody;

	void Awake () 
	{
		Wheel_L1 = GameObject.Find ("Wheel_L1").GetComponent<WheelCollider> ();
		Wheel_R1 = GameObject.Find ("Wheel_R1").GetComponent<WheelCollider> ();
		Wheel_L2 = GameObject.Find ("Wheel_L2").GetComponent<WheelCollider> ();
		Wheel_R2 = GameObject.Find ("Wheel_R2").GetComponent<WheelCollider> ();

		carRigidbody = GetComponent<Rigidbody> ();
		powerInput = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Wheel_L1.motorTorque = 0.0f;
		//Wheel_R1.motorTorque = 0.0f;

	}

	void FixedUpdate ()
	{
		powerInput = Input.GetAxis ("Vertical") * maxSpeed;
		targetTurning = maxTurningDegree * Input.GetAxis ("Horizontal");

		//brake = Input.GetKey ("space");
		Wheel_L1.steerAngle = targetTurning;
		Wheel_R1.steerAngle = targetTurning;

		Wheel_L2.motorTorque = powerInput;
		Wheel_R2.motorTorque = powerInput;
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
