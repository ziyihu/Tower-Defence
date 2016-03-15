using UnityEngine;
using System.Collections;

public class EnemySlow : MonoBehaviour {
	
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

	//when an enemy reach the base, invoke this function
	void SlowEnemy(){

	}

	//after 2 second the enemy reach the base, invoke this function
	void SpeedNormalEnemy(){

	}
}
