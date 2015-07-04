using UnityEngine;
using System.Collections;

public class enemy_script : MonoBehaviour {


	public float DownSpeed;
	public Vector2 RotSpeedRange;
	private float RotSpeed;
	public float MaxHealth;
	public float health;
	public GameObject explosion;

	void Start()
	{

		health = MaxHealth;
		RotSpeed = Random.Range (RotSpeedRange.x, RotSpeedRange.y);

	}

	void Update () 
	{
	
		transform.Rotate(Vector3.up * Time.deltaTime * RotSpeed, Space.Self);
	
		transform.Translate (Vector3.down * DownSpeed, Space.World);
	
		if (health <= 0)
		{

			Instantiate(explosion, transform.position + new Vector3(0, 0, -2), explosion.transform.rotation);
			Destroy(gameObject);

		}

	}
}
