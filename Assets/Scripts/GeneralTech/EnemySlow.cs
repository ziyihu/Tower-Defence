using UnityEngine;
using System.Collections;

public class EnemySlow : MonoBehaviour {

	private bool isExtraSlow = false;
	private bool hasExtraSlow = false;
	private float slowSpeed = 0.015f;

	CharacterManager cManager;
	private TechNode node;

	// Use this for initialization
	void Start () {
		cManager = new CharacterManager ();
		node = new TechNode ();
	}
	
	// Update is called once per frame
	void Update () {
		if (node.GetExtraSlow) {
			isExtraSlow = true;
		}
		if (isExtraSlow) {
			for(int i = 0 ; i < EnemySpawnManager._instance.enemyList.Count ; i++){
				EnemySpawnManager._instance.enemyList[i].SetSpeed(slowSpeed);
			}
		}
	}
}
