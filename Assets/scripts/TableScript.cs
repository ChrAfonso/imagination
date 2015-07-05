using UnityEngine;
using System.Collections;

public class TableScript : MonoBehaviour {

	Component[] rends;

	void Start () 
	{

			rends = GetComponentsInChildren<Renderer>();
			foreach (Renderer rend in rends) {

				Color randomC = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1); 
				rend.material.SetVector ("_MainColor", randomC);

			}
		}

	void OnCollisionStay(Collision other)
	{

		if (!Input.GetMouseButton (0)) {

			Debug.Log (other.gameObject.name);

			if (other.gameObject.name == "RacingCar_blocks") {

				Application.LoadLevel ("racetrack");

			}

			if (other.gameObject.name == "boat_blocks") {
				
				Application.LoadLevel ("pirates");
				
			}

			if (other.gameObject.name == "rocket_blocks") {
				
				Application.LoadLevel ("rocket");
				
			}

			if (other.gameObject.name == "Submarine_blocks") {
				
				Application.LoadLevel ("submarine_world");
				
			}

			if (other.gameObject.name == "castle_blocks") {
				
				Application.LoadLevel ("medieval");
				
			}

		}

	}
}
