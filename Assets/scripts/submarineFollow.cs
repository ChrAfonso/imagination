using UnityEngine;
using System.Collections;

public class submarineFollow : MonoBehaviour {

	public Transform submarine;
	public Vector3 Distance;
	Vector3 Pos;

	public enum follow
	{
		X,
		Y,
		XandY
	};

	public follow Choice = follow.XandY;

	void Update () 
	{

		Pos = new Vector3 (Distance.x, Distance.y, Distance.z);

			switch (Choice) 
			{

			case follow.X:
				{

					Pos.x += submarine.transform.position.x;
					transform.position = Pos;
					break;

				}

			case follow.Y:
				{

					Pos.y += submarine.transform.position.y;
					transform.position = Pos;
					break;

				}

			case follow.XandY:
				{

					Pos.x += submarine.transform.position.x;
					Pos.y += submarine.transform.position.y;
					transform.position = Pos;
					break;

				}


			}

		}


		
}
