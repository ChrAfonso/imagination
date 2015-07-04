using UnityEngine;
using System.Collections;

public class MotherShipScript : MonoBehaviour {

	public float MaxHealth;
	public float health;
	public float DownSpeed;

	public GameObject explosion;

	void Start () {
	
		health = MaxHealth;

	}
	

	void Update () {

		if (transform.position.y < 22) 
		{

			DownSpeed = 0;

			Vector3 startPosition = new Vector3(0, 14, 0);
			gameObject.GetComponent<Animation>().Play("Take 001");
			transform.localPosition += startPosition;

		}
		transform.Translate (Vector3.down * DownSpeed, Space.World);
	
		if (health <= 0)
		{

			Instantiate(explosion, transform.position , transform.rotation);
			Destroy(gameObject);

		}

	}

	void LateUpdate()
	{
		if (transform.position.y < 22) 
		{
		Vector3 nowPosition = new Vector3(0, 14, 0);
		transform.localPosition = nowPosition;
		}

	}
}
