using UnityEngine;
using System.Collections;

public class MenuExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		
		Time.timeScale = 1;
		Application.LoadLevel("main_room");

	}
}
