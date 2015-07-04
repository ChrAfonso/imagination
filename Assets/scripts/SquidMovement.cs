using UnityEngine;
using System.Collections;

public class SquidMovement : MonoBehaviour {

	public Vector3 Movement;
	public float StartDistance;
	public Transform submarine;

	void Update () {
	

		if (Mathf.Abs (Vector3.Distance (transform.position, submarine.transform.position)) <= StartDistance) 
		{

			transform.Translate (Movement, Space.Self);

		}

		if (transform.position.x - 250 > submarine.transform.position.x) 
		{

			Destroy(gameObject);

		}

	}
}
