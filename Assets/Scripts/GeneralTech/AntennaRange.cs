using UnityEngine;
using System.Collections;

public class AntennaRange : MonoBehaviour {

	//set the antenna range to a bigger number
	//set the number to the create function
	//set the number to the two lists: 1. already powered antenna list   2. unpowered antenna list

	private bool isIncreased = false;
	private bool hasIncreased = false;
	private TechNode node;
	CharacterManager cManage;

	public float increasedAntennaRange = 3f;

	// Use this for initialization
	void Start () {
		node = new TechNode ();
		cManage = new CharacterManager ();
	}
	
	// Update is called once per frame
	void Update () {
		if (node.GetAntennaRange && hasIncreased == false) {
			isIncreased = true;
		}
		if (isIncreased) {
			//set the unpowered antenna range
			foreach(Character chara in TowerBuildManager._instance.GetAntennaList()){
				chara.SetAttackRange(increasedAntennaRange);
			}
			//set the powered antenna range
			foreach(Character chara in AntennaAndPower._instance.hasPoweredAntenna){
				chara.SetAttackRange(increasedAntennaRange);
			}
			cManage.SetAntennaRange(increasedAntennaRange);
			hasIncreased = true;
			isIncreased = false;
		}
	}
}
