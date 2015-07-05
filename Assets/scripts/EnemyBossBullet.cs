using UnityEngine;
using System.Collections;

public class EnemyBossBullet : MonoBehaviour {

	bool hit;
	public float transparency = 0.8f;
	public float BulletDamage;
	Renderer rend;

	void Start()
	{

		rend = GetComponent<Renderer> ();

	}

	void OnCollisionEnter(Collision collider)
	{

		if (collider.gameObject.name != "Mothership") 
		{

			hit = true;

		}
		if (collider.gameObject.name == "Rocket") 
		{

			collider.gameObject.GetComponent<RocketMovement>().health -= BulletDamage;

		}
	}

	void Update ()
	{

		if (transform.position.y < -25) 
		{

			hit = true;

		}

		if (hit) 
		{

			transparency -= 0.5f;

		}

		rend.material.SetFloat ("_Alpha", transparency);

		if (transparency <= 0)
		{

			Destroy(gameObject);

		}

	}

}
