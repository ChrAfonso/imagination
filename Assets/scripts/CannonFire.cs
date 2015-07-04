using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {
	public float ballSize = .05f;
	public float ballMass = 2f;
	public int shootPower = 1500;
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
	
	
	// Use this for initialization
	void Start () {
		//Debug.Log ("Start");
		expl = explo;
		power = shootPower;
		
		cannonOri = gameObject.AddComponent<CannonLook>();
		cannonOri.enabled = false;

		canCam = new GameObject();
		cannonView = canCam.AddComponent<Camera>();
		canCam.name = "CannonCam";
		//canCam.transform.parent = transform;
		canCam.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
		canCam.transform.position = transform.position;
		cannonLook = canCam.AddComponent<CannonLook>();
		//canCam.SetActive (false);
		cannonView.enabled = false;

		if (GameObject.FindObjectOfType<MeshCollider>() == null) {
			gameObject.AddComponent<MeshCollider>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log ("Update");
		if (Input.GetKey (KeyCode.Escape)) {
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
		}

		
		GameObject ball = GameObject.FindGameObjectWithTag ("CannonBall");
	
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
//		GameObject.Find("Test Sphere").GetComponent<Rigidbody> ().AddForce (cannonView.transform.forward * power);
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
			
			CannonRigid.AddForce (cannonView.transform.forward * power);
			//Vector3 cam = new Vector3(cannonView.rect.center.x,cannonView.rect.center.y, cannonView.farClipPlane);
			//Debug.DrawLine(cannonView.transform.position,cam,Color.white, 100000f);
			//Gizmos.DrawRay(cannonView.ScreenPointToRay(ball.transform.position));

			/*
			Debug.DrawLine(deb,ball.transform.position,Color.white, 100000f);
			deb=ball.transform.position;
*/
			//Vector3 dir2 = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
			//Debug.Log(Input.mousePosition);
		//	Debug.DrawRay(transform.position, dir2, Color.white, 1000000f);


/*----------------------------------------------------------
			Ray ray = cannonView.ScreenPointToRay(new Vector3(cannonView.transform.position.x, cannonView.transform.position.y, cannonView.transform.position.z));
			Debug.DrawRay(cannonView.transform.position, cannonView.transform.forward, Color.yellow, 1000000f);
*/




			//Debug.DrawLine(transform.forward,transform.forward*10,Color.white, 100000f);

			/*
			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			sphere.transform.position = ball.transform.position;
			sphere.transform.localScale = ball.transform.localScale;
			*/

			//SphereCollider coll = ball.GetComponent<SphereCollider> ();


			//-----------------------------------------------
			//ball.GetComponent<Rigidbody> ().AddForce(dir);
		
			//Vector3 controlDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			//Debug.Log (cannonView.transform.TransformDirection(controlDirection));


			//ball.GetComponent<Rigidbody>().WakeUp ();
			//float vel_y = ball.GetComponent<Rigidbody>().velocity.y-.1f;
		
			//ball.GetComponent<Rigidbody>().velocity = new Vector3(ball.GetComponent<Rigidbody>().velocity.x,vel_y,ball.GetComponent<Rigidbody>().velocity.z);
			//Debug.Log (newpos);


			/*
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		
		mesh.RecalculateNormals ();
		Vector3[] normals = mesh.normals;
		Debug.DrawRay (transform.position, normals [0]);

		Debug.Log (normals[0]);
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

		//Debug.Log ("Space Clicked!");
		if (GameObject.FindGameObjectWithTag ("CannonBall") != null) {
			return;
		}
		float scale = ballSize;
		float mass = ballMass;
		//Vector3 scaleVec = Vector3 (scale, scale, scale);
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.name = "CannonBall";
		sphere.tag = "CannonBall";
		CannonRigid = sphere.AddComponent<Rigidbody> ();
		Vector3 ballPos = transform.position + cannonView.transform.forward*.03f;
		sphere.transform.position = ballPos;
		sphere.transform.localScale -= new Vector3 (1 - scale, 1 - scale, 1 - scale);
		CannonRigid.mass = mass;
		deb = sphere.transform.position;

//		Material newMat = Resources.Load("Grey", typeof(Material)) as Material;
//		Debug.Log (newMat.name);
		sphere.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;

	sphere.gameObject.AddComponent<CannonBoom> ();

	}

	void OnMouseDown () {//Debug.Log ("Click");
		if (InCannonView) {
			return;
		}
		InCannonView = true;
		//GameObject.CreatePrimitive (PrimitiveType.Capsule);


		//canCam.SetActive (true);
		cannonOri.enabled = true;
		cannonView.enabled = true;
		//Debug.Log (transform.childCount);

		//canCam.transform.po

		/*
		cannonView = gameObject.AddComponent<Camera> ();
		cannonLook = cannonView.gameObject.AddComponent<CannonLook>();
*/




		/*
		GameObject sphere2 = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere2.transform.position = new Vector3(transform.position.x-.005f,transform.position.y,transform.position.z);
		sphere2.transform.localScale -= new Vector3(1-scale, 1-scale, 1-scale);
		*/



		//cb_rb.isKinematic = true;

		//cb_rb.transform.localScale -= new Vector3(1-scale, 1-scale, 1-scale);
		//cb_rb.velocity += Vector3.forward;
		//cb_rb.AddForce (Vector3.forward * 500);
		//sphere.GetComponent<Rigidbody>().AddForce(Vector3.forward*40,ForceMode.Impulse);
		//sphere.transform.localScale.Scale(Vector3(.25f,.25f,.25f));
		//Debug.Log (cb_rb.velocity);
	}
}


