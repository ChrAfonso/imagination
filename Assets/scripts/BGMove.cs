using UnityEngine;
using System.Collections;

public class BGMove : MonoBehaviour {

	public Transform submarine;


	void Update () 
	{

		if (transform.position.x - 975 > submarine.transform.position.x) 
		{

			transform.position += new Vector3(-2000,0,0);

		}



	}


}
