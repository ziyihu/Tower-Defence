using UnityEngine;
using System.Collections;

public class AlienRecoveryAttack : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
				if (TowerBuildManager._instance.gManager.alienRecList.Count > 0 && Time.timeScale == 1) {
					foreach(Character chara in TowerBuildManager._instance.gManager.alienRecList){
						foreach(Character chara1 in EnemySpawnManager._instance.enemyList){
							if(chara1.Life <= 0){
								if(Vector3.Distance(chara.GetPos(),chara1.GetPos())< chara.GetAttackRange()){
									//for every enemy, add 10 diamond when killing them
									DiamondManager._instance.AddDiamond(150);
							InformationSave.instance.EarnedMoney += 150;
								}
							}
						}
					}
				}
	}
}
