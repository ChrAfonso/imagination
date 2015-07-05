using UnityEngine;
using System.Collections;

public class RocketMovement : MonoBehaviour {

	public Vector2 MaxCorners;
	public Vector2 MinCorners;
	public float VerticalSpeed;
	public float HorizontalSpeed;
	public Vector2 MaxRot;
	private float rotationX;
	public float RotSpeed;

	public float MaxHealth;
	public float health;

	public GameObject shot;
	public Transform shotSpawner;
	public GameObject explosion;
	public AudioSource audioPlayer;
	public AudioClip pew;

	Quaternion originalRotation;


	void Start()
	{

		originalRotation = transform.localRotation;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
		health = MaxHealth;

	}

	void Update () {
	
		GetComponent<Rigidbody> ().velocity = new Vector3(0, 0, 0);
		GetComponent<Rigidbody> ().AddForce (Vector3.zero);
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
		{

			rotationX += VerticalSpeed * Time.deltaTime  * RotSpeed;
			rotationX = ClampAngle (rotationX, MaxRot.x, MaxRot.y);

			if (transform.position.x - HorizontalSpeed * Time.deltaTime > MinCorners.x)
			{

				transform.Translate(Vector3.left * HorizontalSpeed * Time.deltaTime, Space.World);

			}


		} 
		else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 
		{
			
			rotationX -= VerticalSpeed * Time.deltaTime * RotSpeed;
			rotationX = ClampAngle (rotationX, MaxRot.x, MaxRot.y);
			
			if (transform.position.x + HorizontalSpeed * Time.deltaTime < MaxCorners.x)
			{
				
				transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime, Space.World);
				
			}

		} 
		else 
		{

			rotationX = Mathf.Lerp(rotationX, 0, Time.deltaTime * RotSpeed);

		}

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) 
		{			
			if (transform.position.y + VerticalSpeed * Time.deltaTime < MaxCorners.y)
			{
				
				transform.Translate(Vector3.up * VerticalSpeed * Time.deltaTime, Space.World);
				
			}
			
			
		} 

		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) 
		{

			if (transform.position.y - VerticalSpeed * Time.deltaTime > MinCorners.y)
			{
				
				transform.Translate(Vector3.down * VerticalSpeed * Time.deltaTime, Space.World);
				
			}
			
		} 

		if (Input.GetKeyDown (KeyCode.Space)) 
		{

			GameObject Bullet;
			Bullet = Instantiate(shot, shotSpawner.transform.position, shotSpawner.rotation) as GameObject;
			Rigidbody rb = Bullet.GetComponent<Rigidbody>();
			rb.AddForce(Vector3.up * 3000);
			if (audioPlayer && pew)
				audioPlayer.PlayOneShot(pew);

		}


		Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
		transform.localRotation = originalRotation * xQuaternion;

		if (health <= 0) 
		{

			Instantiate(explosion, transform.position , transform.rotation);
			Destroy(gameObject);

		}

	}

	void OnCollisionEnter(Collision collider)
	{

		if (collider.gameObject.tag == "Enemy") 
		{

			Instantiate(explosion, transform.position , transform.rotation);
			Destroy(gameObject);

		}

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
