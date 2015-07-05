using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public GameObject level_racing_icon;
	public GameObject level_pirate_icon;
	public GameObject level_space_icon;
	public GameObject level_mideval_icon;
	public GameObject level_submarine_icon;

	
	private Toolbox toolbox;


	void disable_color(GameObject o)
	{

		Material newMat = new Material (Shader.Find("Diffuse"));

		foreach (MeshRenderer renderer in o.GetComponentsInChildren<MeshRenderer>()) {
			renderer.material = newMat;
		}
	}

	void set_item_tag(GameObject o)
	{
		o.tag = "Item";
	}


	void Awake () {
		toolbox = Toolbox.Instance;	
		if (!toolbox)
			return;

		if (!toolbox.level_racing_complete && level_racing_icon) 
		{
			disable_color(level_racing_icon);
			set_item_tag(level_racing_icon);
		}
		if (!toolbox.level_pirate_complete && level_pirate_icon) 
		{
			disable_color(level_pirate_icon);
			set_item_tag(level_pirate_icon);
		}
		if (!toolbox.level_mideval_complete && level_mideval_icon) 
		{
			disable_color(level_mideval_icon);
			set_item_tag(level_mideval_icon);
		}
		if (!toolbox.level_space_complete && level_space_icon) 
		{
			disable_color(level_space_icon);
			set_item_tag(level_space_icon);
		}
		if (!toolbox.level_submarine_complete && level_submarine_icon) 
		{
			disable_color(level_submarine_icon);
			set_item_tag(level_submarine_icon);
		}
	}
}
