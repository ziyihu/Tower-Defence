using UnityEngine;
using System.Collections;

public class EnemySlow2 : MonoBehaviour {

	private bool isExtraSlow = false;
	private bool hasExtraSlow = false;
	private float slowSpeed = 0.015f;


	//only extra slow for a little while, for 2 seconds
	private float timer = 2f;
	private float time = 0f;


	CharacterManager cManager;
	private TechNode node;
	
	// Use this for initialization
	void Start () {
		cManager = new CharacterManager ();
		node = new TechNode ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (node.GetExtraSlow2) {
			isExtraSlow = true;
		}
		if (isExtraSlow) {
			//still in the slow time
			if(timer > time){
				for(int i = 0 ; i < EnemySpawnManager._instance.enemyList.Count ; i++){
					EnemySpawnManager._instance.enemyList[i].SetSpeed(slowSpeed);
				}
			} 
			//already two seconds later
			else {
				for(int i = 0 ; i < EnemySpawnManager._instance.enemyList.Count ; i++){
					EnemySpawnManager._instance.enemyList[i].SetSpeed(0.02f);
				}
				time = 0;
			}
		}
	}
}
