using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperCapacitor : Building {
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
	public SuperCapacitor(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("supercapacitor"));
		model.name = "" + ID;
		status = model.GetComponent<CharacterStatus> ();
		status.rotateWeapon = true;
		status.CurPose = CharacterStatus.Pose.None;
		//get the building
		Transform house = model.transform.GetChild (0);
		house.gameObject.GetComponent<Renderer>().sortingOrder = layerOrder = LAYER_BASE + 1;
		buildingType = CharacterData.buildingMode.CAPACITOR;
	}
	
	//change the cannon direction
	Vector3 lastDir = Vector3.zero;
	
	//Find the towers
	public void FindTowers(){
		if (GameManager.Instance.CurStatus != GameManager.Status.START_GAME) {
			return;
		}
		foreach(Character chara in TowerBuildManager._instance.getAllAttackBuilding()){
			if(Vector3.Distance(this.GetPos(),chara.GetPos()) < this.GetAttackRange()){
				towerList.Add(chara);
			}
		}
	}
	
	//Increase the attack rate 
	public void IncreaseAttackRate(){
		if (GameManager.Instance.CurStatus != GameManager.Status.START_GAME) {
			return;
		}
		if(towerList.Count > 0){
			foreach(Character chara in towerList){
				foreach(Character chara1 in hasIncreasedList){
					if(chara.ID == chara1.ID){
						hasIncreased = true;
					}
				}
				if(hasIncreased == false){
					chara.SetAttackRate(0.5f);
					hasIncreasedList.Add(chara);
				} else {
					hasIncreased = false;
				}
			} 
		}
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
