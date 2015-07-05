using UnityEngine;
using System.Collections;

public class EscapeToMainRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("escape")) {
			Application.LoadLevel("main_room");
		}


	}
}
