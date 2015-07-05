using UnityEngine;
using System.Collections;

public class CannonBoom : MonoBehaviour {
	GameObject boomIns;
	int count = 20;
	EllipsoidParticleEmitter emi;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (emi != null) {
			count--;
			//Debug.Log(count);
			if (count <= 0) {
				emi.emit = false;
				GameObject.Destroy (gameObject);
				
				count = 20;
			}
		}
	}

	void OnDestroy(){

		if (emi != null) {
			emi.emit = false;
		}
	}

	void OnCollisionEnter(Collision coll)
	{//Debug.Log (coll.collider.gameObject.name);

		if (coll.collider.gameObject.name.Equals ("Barrel 1") ||
		    coll.collider.gameObject.name.Equals ("Barrel 2") ||
		    coll.collider.gameObject.name.Equals ("Barrel 3") ||
		    coll.collider.gameObject.name.Equals ("Barrel")) {
			return;
		}
		if (coll.collider.gameObject.name.Equals ("Water Surface")) {
			if(emi == null)
			{
				GameObject.Destroy(gameObject);
			}
			return;
		}
		return;
		GameObject boom = CannonFire.expl;
		//Debug.Log ("Test");

		boomIns = (GameObject) Instantiate (boom, coll.contacts[0].point, Quaternion.identity);
		//Debug.Log (coll.collider.gameObject.name);

		emi = boomIns.gameObject.GetComponent<EllipsoidParticleEmitter> ();
		emi.maxSize = 2;
		//InvokeRepeating("FadeOut", 0, 1);


		//emi.emit = false;
		//GameObject.Destroy(boomIns,2);

	}
}