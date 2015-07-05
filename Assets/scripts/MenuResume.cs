using UnityEngine;
using System.Collections;

public class MenuResume : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		GameObject.Find("Menu Camera").GetComponent<Camera>().enabled = false;
		
		Time.timeScale = 1;

	}
}
