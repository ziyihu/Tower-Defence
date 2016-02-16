using UnityEngine;
using System.Collections;

public class GeneratePowerIncrease : MonoBehaviour {

	private bool isGeneratorPower;
	private bool hasGeneratorPower = false;

	private int smallGenIncrease = 2;
	private int bigGenIncrease = 3;

	CharacterManager cManager;
	private TechNode node;

	// Use this for initialization
	void Start () {
		cManager = new CharacterManager ();
		node = new TechNode ();
	}
	
	// Update is called once per frame
	void Update () {
		if (node.GetGeneratorPower && hasGeneratorPower == false) {
			isGeneratorPower = true;
		}
		if (isGeneratorPower) {
			int addPower = TowerBuildManager._instance.GetSmallGenNum()*smallGenIncrease + TowerBuildManager._instance.GetLargeGenNum()*bigGenIncrease;
			TowerBuildManager._instance.AddPower(addPower);
			TowerBuildManager._instance.SetSmallGenPower(TowerBuildManager._instance.GetSmallGenPower() + smallGenIncrease);
			TowerBuildManager._instance.SetBigGenPower(TowerBuildManager._instance.GetBigGenPower() + bigGenIncrease);
			isGeneratorPower = false;
			hasGeneratorPower = true;
		}
	}
}
