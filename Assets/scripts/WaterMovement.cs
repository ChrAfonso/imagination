using UnityEngine;
using System.Collections;

public class WaterMovement : MonoBehaviour {

	public float ForwardSpeed;
	public float DirectionChangeSpeed;
	private float rotationZ;
	public float minumumZ = 320f;
	public float maximumZ = 40f;
	Quaternion originalRotation;
	public Vector3 Cameradistance = new Vector3(0f, 0f, 25f);
    
    
	void Start()
	{

		originalRotation = transform.localRotation;
        
    }

	void Update () {
	

       
        if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {


				rotationZ += DirectionChangeSpeed * (Time.deltaTime / 2);
				rotationZ = ClampAngle (rotationZ, minumumZ, maximumZ);

		}

		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {


				rotationZ -= DirectionChangeSpeed * (Time.deltaTime / 2);
				rotationZ = ClampAngle (rotationZ, minumumZ, maximumZ);
			
		}

		Quaternion xQuaternion = Quaternion.AngleAxis (rotationZ, Vector3.forward);
		transform.localRotation = originalRotation * xQuaternion;

		transform.Translate (Vector3.left * ForwardSpeed * Time.deltaTime);

		if (transform.position.y > 5.2) {

			if (transform.rotation.z < 0)
			{
				rotationZ += DirectionChangeSpeed / 9;
			}
            
        }

		if (transform.position.y < -100) {
			
			if (transform.rotation.z > 0)
			{
				rotationZ -= DirectionChangeSpeed / 9;
            }
            
        }
        
        Camera.main.transform.position = transform.position + Cameradistance;

        
    }

	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
    }
    
}
