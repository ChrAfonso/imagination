using UnityEngine;
using System.Collections;

public class waterAnim : MonoBehaviour {

	private Renderer MatRend;

	public float AnimSpeed_1 = 23f;
	public float AnimSpeed_2 = 14f;
	public Transform submarine;

	void Start () {
	
		MatRend = GetComponent <Renderer>();

	}

	void Update () 
	{

		MatRend.material.mainTextureOffset = new Vector2 (Time.time / AnimSpeed_1, 0);
		MatRend.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(0, Time.time / AnimSpeed_2));

		if (transform.position.x - 475 > submarine.transform.position.x) 
		{

			transform.position += new Vector3(-1000,0,0);

		}



	}


}
