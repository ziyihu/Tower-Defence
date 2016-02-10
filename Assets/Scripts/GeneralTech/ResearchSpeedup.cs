using UnityEngine;
using System.Collections;

public class ResearchSpeedup : MonoBehaviour {

	CharacterManager cManager;
	private TechNode node;

	private bool isResearchSpeedup = false;
	private bool hasResearchSpeedup = false;

	private float speedUpNumber = 0.1f;
	
	// Use this for initialization
	void Start () {
		cManager = new CharacterManager ();
		node = new TechNode ();
	}
	
	// Update is called once per frame
	void Update () {
		if (node.GetResearchSpeedup && hasResearchSpeedup == false) {
			isResearchSpeedup = true;
		}
		if (isResearchSpeedup) {
			ResearchPointManager._instance.SetSpeedUp(speedUpNumber);
			isResearchSpeedup = false;
			hasResearchSpeedup = true;
		}
	}
}
