using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	/*
	Camera main;
	Camera second;
	public ScreenWipe wipe;
	// Use this for initialization
	void Start () {
		main = Camera.allCameras [0];
		second = Camera.allCameras [1];
		Debug.Log ("Test");
		second.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		bool down = Input.GetKeyDown(KeyCode.Space);

		if (down) {
			//main.enabled = !main.enabled;
			//second.enabled = !second.enabled;

			AnimationCurve 
			IEnumerator wiperet = wipe.CrossFadePro(main,second,1);

		}
	}
	*/
	public Camera camera1;
	public Camera camera2;
	public float wipeTime = 2.0f;
	public AnimationCurve curve;
	private Texture tex;
	private RenderTexture renderTex;
	private Texture2D tex2D;

	void Start () {
		//camera1 = Camera.allCameras [0];
		//camera2 = Camera.allCameras [1];
		//Debug.Log ("Test");
		camera2.gameObject.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetKeyDown ("up")) {
			//StartCoroutine (DoWipe (ScreenWipe.ZoomType.Grow));
		} else if (Input.GetKeyDown ("down")) {
			//Debug.Log("tsde");

			StartCoroutine(ScreenWipe.use.DreamWipe (camera1, camera2, wipeTime, .07f, 25.0f));
		}
	}

}
