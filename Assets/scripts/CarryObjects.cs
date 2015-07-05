using UnityEngine;
using System.Collections;

public class CarryObjects : MonoBehaviour {

	private GameObject mainCamera;
	private GameObject objectUnderCursor;
	private bool carrying;
	private bool reelInCarriedObject = false; // drag it towards the carrier object
	protected GameObject carriedObject;
	private float distance;
	public float smooth = 5.0f;
	private GameObject p;
	
	public Texture2D HandGrab;
	public Texture2D HandFist;
	private bool drawHand;
	private bool drawing;

	private bool use;

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

	
	void OnGUI()
	{

		Rect HandPos = new Rect(Screen.width / 2 - 16, Screen.height / 2 - 16, 32, 32);
		
		if (drawHand) 
		{
			if (Input.GetMouseButton(0))
			{
				drawing = true;
			}
			else
			{
			GUI.DrawTexture(HandPos, HandGrab);
			}



		}

		if (use) 
		{

			GUI.DrawTexture(HandPos, HandGrab);

		}



		if (drawing) 
		{

			GUI.DrawTexture(HandPos, HandFist);

			if (Input.GetMouseButtonUp (0)) 
			{

				drawing = false;
				
			}

		}
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.transform.gameObject.tag == "Item") {
			objectUnderCursor = other.transform.gameObject;
			drawHand = true;
		}

		if (other.gameObject.tag == "UsableCanon") {
			use = true;
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.transform.gameObject == objectUnderCursor) {
			objectUnderCursor = null;
			drawHand = false;
		}
	
		if (other.gameObject.tag == "UsableCanon") {
			//use = false;
		}

	}

	void pickUp()
	{
		Debug.Log("mainCamera: " + mainCamera);

		if (Input.GetButtonDown ("HoldObject"))
	    {
			if (CursorObject && objectUnderCursor)
			{
				/*
				// Raycast to cursor
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
				*/
				distance = (mainCamera.transform.position - objectUnderCursor.transform.position).magnitude;
				carrying = true;
				carriedObject = objectUnderCursor;
				carriedObject.GetComponent<Rigidbody>().isKinematic = true;
				Debug.Log("Grab!");
			} else { // raycast fixed distance to screen center
				//float x = Screen.width / 2;
				//float y = Screen.height / 2;

				//Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
				//RaycastHit hit;
				//if (Physics.Raycast(ray, out hit))
				//{
				//	distance = hit.distance;

				//	if (distance <= 1.5f && distance <= 3)
				//	{

				//		distance = 2.5f;

				//	}

				//	if (hit.collider.transform.gameObject.tag == "Item")
				//	{

				//		p = hit.collider.gameObject;

				//	}

				//	if (p != null && distance <= 3)
				//	{

				//		carrying = true;
				//		carriedObject = p.gameObject;
				//		p.gameObject.GetComponent<Rigidbody>().isKinematic = true;

				//	}

				//}
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
			//item.transform.position = CursorObject.transform.position + mainCamera.transform.position;

		}
	}

	void checkDrop()
	{

		if (Input.GetButtonUp ("HoldObject")) { //  || (CursorObject && !CursorObject.GetComponent<Collider>().bounds.Intersects(carriedObject.GetComponent<Collider>().bounds))) {
			drop();
		}

	}

	protected virtual void drop()
	{
		carrying = false;
		distance = 0;
		carriedObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject = null;

		Debug.Log("Drop!");
	}

}
