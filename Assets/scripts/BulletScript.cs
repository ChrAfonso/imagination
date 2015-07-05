﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public float BulletDamage;

	void Update () {
	
		if (transform.position.y > 35) 
		{

			Destroy(gameObject);

		}

	}

	void OnCollisionEnter(Collision collider)
	{

		if (collider.gameObject.tag == "Enemy") 
		{
			if (collider.gameObject.name != "Mothership")
			{
			collider.gameObject.GetComponent<enemy_script>().health -= BulletDamage;
			Destroy(gameObject);
			}
			else
			{
				collider.gameObject.GetComponent<MotherShipScript>().health -= BulletDamage;
				Destroy(gameObject);
			}

		}
		if (collider.gameObject.name == "bullet_enemy_boss") 
		{

			Destroy(gameObject);

		}

	}
}
