using UnityEngine;
using System.Collections;

public class MotherShipScript : MonoBehaviour {

	public float MaxHealth;
	public float health;
	public float DownSpeed;
	public float MoveSpeed;
	public Vector2 LeftRightCornersMax;

	public GameObject Bullet;
	public Transform BulletSpawner;
	public Transform Rocket;
	public float BulletSpeed;

	public AudioSource audioPlayer;
	public AudioClip pew;

	public GameObject explosion;
	public float MaxReloadTime;
	Vector3 StartPos;
	Vector3 nowPos;
	float pos;
	Vector3 movPos;
	int dec;
	float ReloadTime;

	void Start () {
	

		dec = Mathf.Clamp((Random.Range(-2, 2)), 0, 1);
		health = MaxHealth;
		StartPos = transform.position;
		//gameObject.GetComponent<Animation>().Play("Take 001");
		transform.localPosition = StartPos;
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;


	}
	

	void Update () {
	


		if (transform.position.y > 14) 
		{

			pos += 20;

		} 
		else 
		{

			Shoot ();

			if (dec == 0)
			{
				GoLeft(true);
				GoRight(false);
			}

			if (dec == 1)
			{

				GoLeft(false);
				GoRight(true);

			}


			if (transform.position.x - MoveSpeed * Time.deltaTime <= LeftRightCornersMax.x)
			{

				dec = 1;

			}

			if (transform.position.x + MoveSpeed * Time.deltaTime >= LeftRightCornersMax.y)
			{

				dec = 0;

			}

		}




		if (health <= 0)
		{

			Instantiate(explosion, transform.position , transform.rotation);
			Destroy(gameObject);
		}

	}

	void LateUpdate()
	{
		nowPos = new Vector3(0, StartPos.y , 0);
		Vector3 movePos = new Vector3 (0, -DownSpeed, 0);
		//transform.localPosition += new Vector3(0, -DownSpeed, 0);
		transform.localPosition = nowPos + (movePos * pos * DownSpeed);
		transform.localPosition += movPos;

	}

	void GoRight(bool doit)
	{

		if (doit) {
			movPos += new Vector3 (MoveSpeed * Time.deltaTime, 0, 0);
		}


	}

	void GoLeft(bool doit)
	{

		if (doit) {
			movPos -= new Vector3 (MoveSpeed * Time.deltaTime, 0, 0);
		}

	}

	void Shoot ()
	{

		ReloadTime -= 1;

		if (ReloadTime <= 0)
		{

			ReloadTime = MaxReloadTime;
			GameObject getBullet;
			getBullet = Instantiate(Bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation) as GameObject;
			getBullet.GetComponent<Rigidbody>().AddForce(Vector3.down * BulletSpeed);
			//Physics.IgnoreCollision (Bullet.GetComponent<Collider> (), GetComponent<Collider> ());
			if (audioPlayer && pew)
				audioPlayer.PlayOneShot(pew);


		}


	}
}
