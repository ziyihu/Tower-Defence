using UnityEngine;
using System.Collections;

public class Tower4Attack : MonoBehaviour {

	TechNode techNode = new TechNode();

	// Update is called once per frame
	void Update () {
		if (TowerBuildManager._instance.gManager.tower4List.Count > 0 && Time.timeScale == 1) {
			for(int i = 0 ; i < EnemySpawnManager._instance.enemyList.Count ; i++){
				foreach (Tower4 t in TowerBuildManager._instance.gManager.tower4List) {
					if(t.GetPowerProvider()!= null){
						t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
						t.CheckEnemy();
						if(techNode.GetExtraSlow && techNode.GetExtraSlow2){
							t.SlowEnemy(0.8f);
						} else if(techNode.GetExtraSlow && techNode.GetExtraSlow2 == false){
							t.SlowEnemy(0.9f);
						} else if(techNode.GetExtraSlow == false && techNode.GetExtraSlow2){
							t.SlowEnemy(0.85f);
						} else {
							t.SlowEnemy(1f);
						}
						//in the range
//						if(t.InRange(i)){
//							//slow the enemy
//							EnemySpawnManager._instance.enemyList[i].SetSpeed(0.015f * extraSlowNum);
//							EnemySpawnManager._instance.enemyList[i].isSlow = true;
//							InSlowTowerRange = true;
//						}
					} else {
						t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
					}
//					if(InSlowTowerRange == false){
//						if(node.GetExtraSlow2){
//							EnemySpawnManager._instance.enemyList[i].SetSpeed(0.018f * extraSlowNum);
//						} else {
//							EnemySpawnManager._instance.enemyList[i].SetSpeed(0.02f * extraSlowNum);
//						}
//					}
//					InSlowTowerRange = false;
				}
			}
			
		}
	}
}
