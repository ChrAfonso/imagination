using UnityEngine;
using System.Collections;

public class ActivateCannon : MonoBehaviour {
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
	MeshCollider colli;

	// Use this for initialization
	void Start () {
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
			colli = gameObject.AddComponent<MeshCollider>();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
