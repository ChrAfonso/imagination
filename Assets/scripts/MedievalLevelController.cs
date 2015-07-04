using UnityEngine;
using System.Collections;

public class MedievalLevelController : MonoBehaviour {

	public static MedievalLevelController instance { get; private set; }

	private bool running = false;

	public AudioClip music; // includes lose at the end (timed)
	public AudioClip winMusic;

	public AudioClip sfxSlotIn;

	private AudioSource musicPlayer;
	private AudioSource sfxPlayer;

	private GameObject[] blockTriggers;
	private int repairedBlocks;

	// Use this for initialization
	void Start () {
		Debug.Log("Init Medieval Level Controller");

		instance = this;

		blockTriggers = GameObject.FindGameObjectsWithTag("BlockTrigger");
		repairedBlocks = 0;

		if (music) {
			musicPlayer = gameObject.AddComponent<AudioSource>();
			musicPlayer.clip = music;
			musicPlayer.Play();
		}

		sfxPlayer = gameObject.AddComponent<AudioSource>();

		running = true;
	}

	void Update()
	{
		if (running)
		{
			// TODO advance army

			// TODO check army arrival (timer?)
		}
	}

	public void blockReleased(GameObject block)
	{
		Debug.Log("Block Released! Checking triggers...");

		for (int i = 0; i < blockTriggers.Length; i++) {
			GameObject trigger = blockTriggers[i];

			Debug.Log("Trigger nr. "+i+" childCount: "+trigger.transform.childCount);
			if (trigger.transform.childCount == 0 && trigger.GetComponent<Collider>().bounds.Intersects(block.GetComponent<Collider>().bounds))
			{
				Debug.Log("Trigger nr. " + i + ": Adding block");
				
				block.transform.parent = trigger.transform;
				block.transform.localPosition = Vector3.zero; // TODO create script to animate?
				block.transform.localRotation = Quaternion.identity;
				block.tag = "PlacedItem";
				Component.Destroy(block.GetComponent<Rigidbody>());

				repairedBlocks++;

				// TODO play slot-in sound
				if (sfxSlotIn)
				{
					sfxPlayer.PlayOneShot(sfxSlotIn);
				}

				// DEBUG change trigger color
				Color color = Color.gray;
				trigger.GetComponent<MeshRenderer>().material.color = color;
			}
		}

		// TODO check repair finished
		Debug.Log("repairedBlocks: "+repairedBlocks);

		if (repairedBlocks == blockTriggers.Length)
		{
			repairFinished();
		}
	}

	void enemiesArrived()
	{
		// TODO disable input

		// TODO return to main scene after delay
		Application.LoadLevel("main_room");
	}

	void repairFinished()
	{
		// TODO play win music

		// TODO show success message?

		// TODO return to main room after winMusic played
		onWinMusicFinished();
	}

	void onWinMusicFinished()
	{
		// TODO notify global game manager of success

		Application.LoadLevel("main_room");
	}
}
