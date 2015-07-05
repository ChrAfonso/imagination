using UnityEngine;
using System.Collections;

public class ShipHit : MonoBehaviour {
	public static int hits = 0;
	GameObject boomIns;
	int count = 20;
	EllipsoidParticleEmitter emi;
	bool active = false;

	public AudioClip pirateMusic;
	public AudioClip pirateMusicWin;

	public AudioClip sfxHit;

	private AudioSource musicPlayer;
	private AudioSource sfxPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer = gameObject.AddComponent<AudioSource>();
		musicPlayer.clip = pirateMusic;
		musicPlayer.Play();

		sfxPlayer = gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

			if(hits >= 3)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y -.3f, transform.position.z);
				if(transform.position.y < 10 && !musicPlayer.isPlaying)
				{
					//emi.emit = false;
				/*
				while(GameObject.Find("Small explosion(Clone)") != null)
				{
					GameObject.Destroy(GameObject.Find("Small explosion(Clone)"));
				}*/
					GameObject.Destroy (gameObject);
					Application.LoadLevel("main_room");
					Toolbox.Instance.level_pirate_complete = true;
				}

			}
			//else{
		
		if (emi != null) {
				count--;
				//Debug.Log(count);
				if (count <= 0) {
				active = false;
					emi.emit = false;
					//SinkShip();//GameObject.Destroy (gameObject);
				emi.maxSize = hits>=2 ? 20 : 5;
					count = hits>=2 ? 40 : 20;
				}
			//}
		}
	}

	
	void OnCollisionEnter(Collision coll)
	{
		if (active) {
			return;
		}
		active = true;
		hits++;
		Debug.Log (coll.collider.gameObject);
		GameObject.Destroy (coll.collider.gameObject);

		GameObject boom = CannonFire.expl;
		//Debug.Log ("Test");

		sfxPlayer.PlayOneShot(sfxHit);

		boomIns = (GameObject) Instantiate (boom, coll.contacts[0].point, Quaternion.identity);
		//Debug.Log (coll.collider.gameObject.name);
		
		emi = boomIns.gameObject.GetComponent<EllipsoidParticleEmitter> ();
		emi.maxSize = 5;

		if (hits >= 3)
		{
			musicPlayer.clip = pirateMusicWin;
			musicPlayer.Play();
		}

	}

	void SinkShip(){


	}


}
