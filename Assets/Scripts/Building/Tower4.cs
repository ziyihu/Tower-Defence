using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower4 : Building {

	public Antenna powerProvider;

	//Current Enemy
	public Character curEnemy;
	public List<Character> enemyLists = new List<Character> ();
	public int attackPower = 100;
	TechNode node;
	float mHitDelta;
	bool endAttack = true;
	int curFps = 0;
	float mFPS = 10;
	float moveDistance = 0.5f;
	//the cannon will be bigger when attacking the enemy
	float scalefactor = 0.6f;
	int turnSpeed = 12;
	Vector3 dirPos;
	float attackIntervale = 1;
	float dirRotation;
	bool isExist;

	void Start(){
		node = new TechNode ();
	}

	public Tower4(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("tower4"));
		model.name = "" + ID;
		status = model.GetComponent<CharacterStatus> ();
		status.rotateWeapon = true;
		status.CurPose = CharacterStatus.Pose.None;
		//get the building
		Transform house = model.transform.GetChild (0);
		house.gameObject.GetComponent<Renderer>().sortingOrder = layerOrder = LAYER_BASE + 1;
		buildingType = CharacterData.buildingMode.TOWER4;
	}

	public bool InRange(int i){
		return (Vector3.Distance (this.GetPos (), EnemySpawnManager._instance.enemyList [i].GetPos ()) <= this.GetAttackRange ());
	}

	float lastTime = Time.realtimeSinceStartup;
	float lastAttackTime = Time.realtimeSinceStartup;


	//Find the nearest enemy
	public void CheckEnemy(){
		if (GameManager.Instance.CurStatus != GameManager.Status.START_GAME) {
			return;
		}
		if (Time.realtimeSinceStartup > lastTime + data.attackInterval) {
			//get the enemy list
			if(EnemySpawnManager._instance.enemyList.Count > 0){
				//attack the enemy
				foreach(Character chara in EnemySpawnManager._instance.enemyList){
					if(Vector3.Distance(this.GetPos(),chara.GetPos()) < this.GetAttackRange() && chara.Life >= 0){
						isExist = false;
						for(int i = 0 ; i < enemyLists.Count; i++) {
							if(enemyLists[i].ID == chara.ID){
								isExist = true;
							}
						}
						if(isExist == false){
							enemyLists.Add(chara);
						}
						for(int i = 0;i < enemyLists.Count ; i ++){
							if(enemyLists[i].Life <= 0){
								enemyLists.Remove(enemyLists[i]);
								i--;
							}
						}
					}
				}
				lastTime = Time.realtimeSinceStartup;
			} else if(EnemySpawnManager._instance.enemyList.Count == 0){
				enemyLists.Clear();
			}
		}
	}



	//Hit the enmey
	public void SlowEnemy(float extraSlowPercentage){
//		if (GameManager.Instance.CurStatus != GameManager.Status.START_GAME) {
//			return;
//		}
		for(int i = 0 ; i < enemyLists.Count ; i++){
			if(Vector3.Distance(this.GetPosition(),enemyLists[i].GetPos()) >= this.GetAttackRange()){
				if(enemyLists[i].isSlow == true){
//					if(node != null && node.GetExtraSlow2){
//						EnemySpawnManager._instance.enemyList[i].SetSpeed(0.015f);
//						EnemySpawnManager._instance.enemyList[i].isSlow = false;
//					} else {
					enemyLists[i].SetSpeed(0.02f * extraSlowPercentage);
						enemyLists[i].isSlow = false;
					//}
				}
			}
		else {
				if(enemyLists[i].isSlow == false){
					enemyLists[i].isSlow = true;
					enemyLists[i].SetSpeed(0.015f * extraSlowPercentage);
				}
			}
		}
	}

	public void SetPosition(Vector3 pos){
		if (model != null) {
			model.transform.position = pos;
		}
	}
	
	public Vector3 GetPosition(){
		return model.transform.position;
	}
}
