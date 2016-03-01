using UnityEngine;
using System.Collections;

public class StasisDamage : MonoBehaviour {

	private int stasisDamageNumber = 3;
	private float stasisDamageRate = 1f;
	private float timer = 1f;
	private float time = 0;

	private bool isStasisDamage = false;

	CharacterManager cManager;
	private TechNode node;

	// Use this for initialization
	void Start () {
		cManager = new CharacterManager ();
		node = new TechNode ();
	}
	
	// Update is called once per frame
	void Update () {
		if (node.GetStasisDamage) {
			isStasisDamage = true;
		}
		if (isStasisDamage) {
			time = time + Time.deltaTime;
			if(timer < time){
				for(int i = 0; i <= EnemySpawnManager._instance.enemyList.Count - 1 ; i++){
					foreach(Tower4 chara1 in TowerBuildManager._instance.GetStasisBuilding()){
						if(Vector3.Distance(EnemySpawnManager._instance.enemyList[i].GetPos(),chara1.GetPos()) < chara1.GetAttackRange()){
							if(EnemySpawnManager._instance.enemyList[i].Life > 0){
								EnemySpawnManager._instance.enemyList[i].OnBeHit(stasisDamageNumber);
							}
						}
					}
				}
				time = 0;
			}
		}
	}
}
