using UnityEngine;
using System.Collections;

public class MedievalCarry : CarryObjects {

	protected override void drop()
	{
		GameObject block = carriedObject;
		base.drop();

		MedievalLevelController.instance.blockReleased(block);
	}
}
