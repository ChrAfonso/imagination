using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {
	public float ballSize = .5f;
	public float ballMass = 2f;
	public int shootPower = 10000;
	public GameObject explo;
	public static GameObject expl;
	Camera cannonView;
	CannonLook cannonLook;
	CannonLook cannonOri;
	int power;
	bool InCannonView = false;
	bool Shooting = false;
	Vector3 deb;
	GameObject canCam;
	Vector3 newpos;
	Vector3 dir;
	Rigidbody CannonRigid;
	GameObject active;
	
	// Use this for initialization
	void Start () {
		//Debug.Log ("Start");
		expl = explo;
		power = shootPower;

		cannonOri = gameObject.AddComponent<CannonLook>();
		cannonOri.enabled = false;

		
		canCam = GameObject.Find ("CannonCam");
		if (canCam == null) {

			canCam = new GameObject ();
			canCam.name = "CannonCam";
			cannonView = canCam.AddComponent<Camera> ();
			cannonLook = canCam.AddComponent<CannonLook>();	
			canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);

		} else {
			cannonView = canCam.GetComponent<Camera> ();
		}
		CannonLook.ChangeAngles(155F, 205F, 0F, 10F);
		/*CannonLook.ChangeAngles(155F, 205F, 0F, 10F);
		switch (gameObject.name) {
		case "Barrel": CannonLook.ChangeAngles(-35F, 25F, 0F, 10F);
			break;
		case "Barrel 1": CannonLook.ChangeAngles(-35F, 25F, 0F, 10F);
			break;
		case "Barrel 2": CannonLook.ChangeAngles(155F, 205F, 0F, 10F);
			break;
		case "Barrel 3": CannonLook.ChangeAngles(155F, 205F, 0F, 10F);
			break;
		}
*/

		/*

		if (gameObject.name == ("Barrel 2") ||
		    gameObject.name == ("Barrel 3")) {
			canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
		} else {	
			//Debug.Log (gameObject.name);
			canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
		}

		*/




	//	canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);


//		if (cannonView == null) {
//		}
		//canCam.transform.parent = transform;

		/*---------------------------------------------------------
		if (gameObject.name == ("Barrel 2") ||
			gameObject.name == ("Barrel 3")) {
			canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
		} else {	
			canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
		}


		canCam.transform.position = transform.position;

-------------------------------------------*/
		//canCam.SetActive (false);
		cannonView.enabled = false;

		if (gameObject.GetComponent<MeshCollider>() == null) {
			gameObject.AddComponent<MeshCollider>();
		}
	}


	// Update is called once per frame
	void Update () {
		if (gameObject != active) {
			return;
		}
		//Debug.Log ("Update");
		if (Input.GetKey (KeyCode.Backspace)) {
			InCannonView = false;
			if(cannonView != null)
			{
				//GameObject.Destroy(cannonView);
				
				cannonView.enabled = false;
			}
			if(canCam != null)
			{
				//GameObject.Destroy(canCam);
				//canCam.SetActive (false);

			}
			cannonOri.enabled = false;
			active = null;
		}

		
		GameObject ball = GameObject.Find("CannonBall");
	
		if (Shooting) {
			if (ball == null) {
				Shooting = false;
				return;
			}
			//CannonRigid.AddForce (cannonView.transform.forward * power);
			Debug.DrawLine(deb,ball.transform.position,Color.white, 100000f);
			deb=ball.transform.position;
			//power--;
			/*
			//Debug.DrawLine(deb,ball.transform.position,Color.white, 100000f);
			deb=ball.transform.position;
			Vector3 mov = ball.transform.position+dir*.1f;
			ball.transform.position = new Vector3(mov.x,mov.y,mov.z);
			*/
			if(ball.transform.position.y < 0)
			{
				Shooting = false;
			}
			return;
		}

		if (Input.GetKey (KeyCode.Space)) {
			if (ball == null) {
				power = shootPower;
				if(InCannonView)
				{
					ShootCannon();
				}
				return;
			}

			//float posx, posy, posz;
			newpos = cannonView.transform.forward*power;
			dir = newpos-ball.transform.position;
			Shooting=true;
			
			CannonRigid.AddForce (cannonView.transform.forward* power);
			Debug.Log(cannonView.transform.forward);

/*----------------------------------------------------------
			Ray ray = cannonView.ScreenPointToRay(new Vector3(cannonView.transform.position.x, cannonView.transform.position.y, cannonView.transform.position.z));
			Debug.DrawRay(cannonView.transform.position, cannonView.transform.forward, Color.yellow, 1000000f);
*/








		}

		if (ball == null) {
			return;
		}
		if (ball.transform.position.y < 0) {
			GameObject.Destroy (ball);
		}
		
	}
	void OnCollisionEnter(Collision coll)
	{
		//Debug.Log (coll.rigidbody);

	}

	void ShootCannon () {
		/*
		if (ShipHit.explosion) {
			return;
		}*/
		//Debug.Log ("Space Clicked!");
		if (GameObject.Find ("CannonBall") != null) {
			return;
		}
		float scale = ballSize;
		float mass = ballMass;
		//Vector3 scaleVec = Vector3 (scale, scale, scale);
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.name = "CannonBall";
		//sphere.tag = "CannonBall";
		CannonRigid = sphere.AddComponent<Rigidbody> ();
		Vector3 ballPos = transform.position + cannonView.transform.forward*2f;
		sphere.transform.position = ballPos;
		sphere.transform.localScale -= new Vector3 (1 - scale, 1 - scale, 1 - scale);
		CannonRigid.mass = mass;
		deb = sphere.transform.position;

//		Material newMat = Resources.Load("Grey", typeof(Material)) as Material;
//		Debug.Log (newMat.name);
		sphere.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;

	sphere.gameObject.AddComponent<CannonBoom> ();

	}





	void OnMouseDown () {//Debug.Log (gameObject.name);
		if (active != null) {
			return;
		}
		active = gameObject;
		//Debug.Log (active.name);

		if (InCannonView) {
			return;
		}
		InCannonView = true;

		if (gameObject.name == "Barrel 2"){
			//canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
			
			CannonLook.ChangeAngles(155F, 205F, 0F, 10F);
		} else {
			//canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y - 180, transform.eulerAngles.z);
			
			CannonLook.ChangeAngles(-25F, 35F, 0F, 10F);
		}
		//canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
		canCam.transform.position = transform.position+cannonView.transform.forward*1.5f;
	
		cannonOri.enabled = true;
		cannonView.enabled = true;



	}
}


