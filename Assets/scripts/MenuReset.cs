﻿using UnityEngine;
using System.Collections;

public class MenuReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevelName);
		//Application.LoadLevel("main_room");

	}
}
