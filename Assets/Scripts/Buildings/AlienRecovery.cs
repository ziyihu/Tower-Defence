using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlienRecovery : Building {

	public List<Character> towerList = new List<Character> ();
	public List<Character> hasIncreasedList = new List<Character>();

	private bool hasIncreased = false;
	
	public float time = 0;
	float mHitDelta;
	int curFps = 0;
	float mFPS = 10;
	Vector3 dirPos;
	float attackIntervale = 1;
	bool isExist;
	public AlienRecovery(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("alienrecovery"));
		model.name = "" + ID;
		status = model.GetComponent<CharacterStatus> ();
		status.rotateWeapon = true;
		status.CurPose = CharacterStatus.Pose.None;
		//get the building
		Transform house = model.transform.GetChild (0);
		house.gameObject.GetComponent<Renderer>().sortingOrder = layerOrder = LAYER_BASE + 1;
		buildingType = CharacterData.buildingMode.ALIEN;
	}
	
	public void SetPosition(Vector3 pos){
		if (model != null) {
			model.transform.position = pos;
		}
	}
	
	public void SetDirection(Vector3 dir){
		if (model != null) {
			model.transform.localRotation = Quaternion.Euler (dir);
		}
	}
	
	public Vector3 GetPosition(){
		return model.transform.position;
	}
}
