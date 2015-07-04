using UnityEngine;
using System.Collections;

public class MedievalLevelController : MonoBehaviour {

	public static MedievalLevelController instance { get; private set; }

	private int state = 0;
	private const int STATE_RUNNING = 0;
	private const int STATE_GAMEOVER = 1;

	public AudioClip music; // includes lose at the end (timed)
	public AudioClip winMusic;

	public AudioClip sfxSlotIn;

	private AudioSource musicPlayer;
	private AudioSource sfxPlayer;

	private GameObject[] blockTriggers;
	private int repairedBlocks;

	public GameObject EnemyPrefab;
	public int NumberOfEnemies = 20;
	public float EnemyStartDistance = 100;

	private float gameOverTimer;
	private float gameOverResetDelay = 5;

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

		initEnemyArmy();

		state = STATE_RUNNING;
	}

	private void initEnemyArmy()
	{
		for (int i = 0; i < NumberOfEnemies; i++)
		{
			GameObject enemy = GameObject.Instantiate(EnemyPrefab);
			Vector3 position = Quaternion.AngleAxis(i*360/NumberOfEnemies, Vector3.up) * new Vector3(0, 0, EnemyStartDistance);
			position.y = GameObject.Find("Terrain").GetComponent<Terrain>().SampleHeight(position) + 1;
			enemy.transform.position = position;

			// TEST
			enemy.GetComponent<KnightEnemy>().Speed = EnemyStartDistance/music.length * 0.9f; // they should arrive at the climax of the music
		}
	}

	void Update()
	{
		if (state == STATE_RUNNING)
		{
			// check army arrival (timer? music end?)
			//if (musicPlayer.clip == music && !musicPlayer.isPlaying)
			if (musicPlayer.clip == music && musicPlayer.time > music.length*0.95f)
			{
				Debug.Log("Game Over!");
				enemiesArrived();
			}
		}
		else if (state == STATE_GAMEOVER)
		{
			gameOverTimer += Time.deltaTime;
			if (gameOverTimer >= gameOverResetDelay)
			{
				Application.LoadLevel("main_room"); // TODO replace this with camera transition
			}
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
		// disable input
		//Component.Destroy(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<WalkCamera>());

		state = STATE_GAMEOVER;
		gameOverTimer = 0;

		// destroy castle
		GameObject[] wallBlocks = GameObject.FindGameObjectsWithTag("PlacedItem");
		Debug.Log("wallBlocks: "+wallBlocks.Length);
		foreach (GameObject wallBlock in wallBlocks)
		{
			Rigidbody rb = wallBlock.AddComponent<Rigidbody>();

			// TODO add force?
			//rb.AddExplosionForce(100, new Vector3(0, -10, 0), 100);
			//rb.AddForce(new Vector3(Random.Range(-10, 10), 30, Random.Range(-10, 10)));
			rb.velocity = -wallBlock.transform.position.normalized * Random.Range(0, 20) + new Vector3(Random.Range(-5, 5), Random.Range(0, 20), Random.Range(-5, 5));
		}
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
