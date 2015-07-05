
public class Toolbox : Singleton<Toolbox> {
	protected Toolbox () {} // guarantee this will be always a singleton only - can't use the constructor!
	
	public bool level_racing_complete = false;
	public bool level_pirate_complete = false;
	public bool level_space_complete = false;
	public bool level_submarine_complete = false;
	public bool level_mideval_complete = false;

	void Awake () {
		// Your initialization code here
	}	
}

