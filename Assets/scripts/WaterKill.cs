using UnityEngine;
using System.Collections;

public class WaterKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.gameObject.name.Equals("Water Surface")) {
			Application.LoadLevel("pirates");
		}
		//Debug.Log (coll.collider.gameObject.name);
	}
}
