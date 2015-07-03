using UnityEngine;
using System.Collections;

public class CarryObjects : MonoBehaviour {

	private GameObject mainCamera;
	private bool carrying;
	private GameObject carriedObject;
	private float distance;
	public float smooth = 5.0f;
	private GameObject p;


	void Start () {
	
		mainCamera = GameObject.FindWithTag ("MainCamera");

	}
	

	void Update () {
	
		if (carrying) {

			carry (carriedObject);
			checkDrop ();

		} else {

			pickUp();

		}

	}

	void pickUp()
	{

		if (Input.GetButtonDown ("HoldObject"))
	    {

			float x = Screen.width / 2;
			float y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				distance = hit.distance;

				if (distance <= 1.5f && distance <= 3)
				{

					distance = 2.5f ;

				}

				if (hit.collider.transform.gameObject.tag == "Item")
				{

					p = hit.collider.gameObject;

				}

				if (p != null && distance <= 3)
				{

					carrying = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().isKinematic = true;

				}

			}
			                                          

		}

	}

	void carry(GameObject item)
	{

		item.transform.position = Vector3.Lerp (item.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);

	}

	void checkDrop()
	{

			if (Input.GetButtonUp ("HoldObject")) {

			carrying = false;
			carriedObject = null;
			p.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			p = null;

		}

	}

}
