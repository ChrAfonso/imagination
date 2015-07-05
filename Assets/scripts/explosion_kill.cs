using UnityEngine;
using System.Collections;

public class explosion_kill : MonoBehaviour {

	public float TimetoKill;
	public float DownSpeed;
	

	void Update () {
	
		transform.Translate (Vector3.down * DownSpeed, Space.World);

		TimetoKill -= 1;

		if (TimetoKill <= 0) 
		{

			Destroy(gameObject);

			if (!GameObject.Find("Rocket"))
			{

				Application.LoadLevel("main_room");

			}

		}

	}

	void OnDestroy()
	{

		if (gameObject.name == "mothership_explosion") 
		{

			Application.LoadLevel("main_room");

		}


	}
}
