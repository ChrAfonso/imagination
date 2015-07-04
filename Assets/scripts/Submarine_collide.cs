using UnityEngine;
using System.Collections;

public class Submarine_collide : MonoBehaviour {


	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag == "SubmarineCollider") {

			Application.LoadLevel(Application.loadedLevel);


		}
	}
}
