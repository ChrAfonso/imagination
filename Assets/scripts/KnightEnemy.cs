using UnityEngine;
using System.Collections;

public class KnightEnemy : MonoBehaviour {

	public float Speed = 1; // units/second
	private GameObject target; // walk towards this

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("MainCamera"); // walk towards player
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Collider>().bounds.Intersects(GameObject.FindGameObjectWithTag("Castle").GetComponent<Collider>().bounds)) return; // don't walk into castle

		Vector3 direction = (target.transform.position - transform.position);
		//direction.y = 0;
		direction.Normalize();

		transform.LookAt(target.transform.position);
		//GetComponent<Rigidbody>().velocity = direction * Speed;
		transform.position += direction * Speed * Time.deltaTime;

		// ground on terrain
		Vector3 position = transform.position;
		position.y = GameObject.FindGameObjectWithTag("Terrain").GetComponent<Terrain>().SampleHeight(position);
		transform.position = position;
	}
}
