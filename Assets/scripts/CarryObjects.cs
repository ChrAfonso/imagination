using UnityEngine;
using System.Collections;

public class CarryObjects : MonoBehaviour {

	private GameObject mainCamera;
	private bool carrying;
	private bool reelInCarriedObject = false; // drag it towards the carrier object
	private GameObject carriedObject;
	private float distance;
	public float smooth = 5.0f;
	private GameObject p;

	public GameObject CursorObject;

	void Start () {
	
		mainCamera = GameObject.FindWithTag ("MainCamera");

	}
	

	void Update () {
	
		if (carrying) {

			carry(carriedObject);
			checkDrop ();

		} else {

			pickUp();

		}

	}

	void pickUp()
	{

		if (Input.GetButtonDown ("HoldObject"))
	    {
			if (CursorObject)
			{ // Raycast to cursor
				Vector3 camToCursor = CursorObject.transform.position - mainCamera.transform.position;
				Ray ray = new Ray(mainCamera.transform.position, camToCursor);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.transform.gameObject.tag == "Item")
					{

						p = hit.collider.gameObject;

					}

					if (p != null && hit.distance <= camToCursor.magnitude)
					{

						distance = (mainCamera.transform.position - p.transform.position).magnitude;
						carrying = true;
						carriedObject = p.gameObject;
						p.gameObject.GetComponent<Rigidbody>().isKinematic = true;

						Debug.Log("Grab!");
					}

				}
			} else { // raycast fixed distance to screen center
				float x = Screen.width / 2;
				float y = Screen.height / 2;

				Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					distance = hit.distance;

					if (distance <= 1.5f && distance <= 3)
					{

						distance = 2.5f;

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

	}

	void carry(GameObject item)
	{
		if (reelInCarriedObject)
		{
			item.transform.position = Vector3.Lerp(item.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		}
		else
		{
			item.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;
		}
	}

	void checkDrop()
	{

		if (Input.GetButtonUp ("HoldObject")) { //  || (CursorObject && !CursorObject.GetComponent<Collider>().bounds.Intersects(carriedObject.GetComponent<Collider>().bounds))) {

			carrying = false;
			carriedObject = null;
			distance = 0;
			p.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			p = null;

			Debug.Log("Drop!");
		}

	}

}
