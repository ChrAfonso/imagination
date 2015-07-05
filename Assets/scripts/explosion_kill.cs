using UnityEngine;
using System.Collections;

public class explosion_kill : MonoBehaviour {

	public float TimetoKill;
	public float DownSpeed;
	public AudioSource audioPlayer;
	

	void Awake()
	{
		audioPlayer = GetComponent<AudioSource> ();
		if (audioPlayer)
			audioPlayer.PlayOneShot (audioPlayer.clip);
	}

	void Update () {
	
		transform.Translate (Vector3.down * DownSpeed, Space.World);

		TimetoKill -= 1;

		if (TimetoKill <= 0) 
		{

			Destroy(gameObject);

			if (!GameObject.Find("Rocket"))
			{

				Application.LoadLevel("main_room");

			}

			if (!GameObject.Find("Mothership"))
			{

				Application.LoadLevel("main_room");

			}

		}

	}

}
