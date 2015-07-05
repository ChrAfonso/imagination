using UnityEngine;
using System.Collections;

public class MenuActivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find("Menu Camera").GetComponent<Camera>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			GameObject.Find("Menu Camera").GetComponent<Camera>().enabled = true;
		
			Time.timeScale = 0;
		}

	}
}
