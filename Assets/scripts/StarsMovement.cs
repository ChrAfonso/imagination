using UnityEngine;
using System.Collections;

public class StarsMovement : MonoBehaviour {

	public float Starspeed;

	void Update () {
	


		transform.Translate (Vector3.down * Starspeed, Space.World);

		if (transform.position.y < -490) 
		{

			Vector3 newPos = new Vector3 (0, 1000, 0);
			transform.Translate (newPos, Space.World);

		}

	}
}
