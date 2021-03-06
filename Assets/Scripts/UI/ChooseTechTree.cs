﻿using UnityEngine;
using System.Collections;

public class ChooseTechTree : MonoBehaviour {

	public UIButton Continue;
	public UIButton Start;
	public UIButton TechTree1;
	public UIButton TechTree2;
	public UIButton TechTree3;
	public UIButton Wiki;
	public UIButton ChooseTree1;
	public UIButton ChooseTree2;
	public UIButton ChooseTree3;

	public EnemySpawnManager enemySpawnManager;
	public EnemySpawnManager2 enemySpawnManager2;

	public int CurrentTechTree = 0;

	public void OnChooseTree1Clicked(){
		GameObject.Find ("TechTree").GetComponent<ActiveLevel1NodeManager> ().Active ();
		InformationSave.instance.TechTree = 1;
		ResearchPointManager._instance.SetCurrentPoint (2);
		SetChooseNotActive ();
		SetOtherButtonActive ();
		TechTree1.gameObject.SetActive (true);
		TechTree2.gameObject.SetActive (false);
		TechTree3.gameObject.SetActive (false);
		//Start create enemy from enemy manager1
		enemySpawnManager.StartCoroutine1 ();
		//stop create enemy from enemy manager2
		enemySpawnManager2.EndCoroutine2 ();
		CurrentTechTree = 1;
	}


	public void OnChooseTree2Clicked(){
		GameObject.Find ("TechTree2").GetComponent<ActiveLevel1NodeManager> ().Active ();
		InformationSave.instance.TechTree = 2;

		ResearchPointManager._instance.SetCurrentPoint (2);
		//ResearchPointManager._instance.SetCurrentPoint (7);
		//DiamondManager._instance.AddDiamond (1800);

		SetChooseNotActive ();
		SetOtherButtonActive ();
		TechTree1.gameObject.SetActive (false);
		TechTree2.gameObject.SetActive (true);
		TechTree3.gameObject.SetActive (false);

		//Start create enemy from enemy manager1
		enemySpawnManager.StartCoroutine1 ();
		//stop create enemy from enemy manager2
		enemySpawnManager2.EndCoroutine2 ();

		//start create enemy from enemy manager2
		//enemySpawnManager2.StartCoroutine2 ();
		//stop create enemy from enemy manager1
		//enemySpawnManager.EndCoroutine1 ();
		CurrentTechTree = 2;
	}

	public void OnChooseTree3Clicked(){
		GameObject.Find ("TechTree3").GetComponent<ActiveLevel1NodeManager> ().Active ();
		InformationSave.instance.TechTree = 3;

		ResearchPointManager._instance.SetCurrentPoint (2);
		/* if start the game from the 7th wave */
		//ResearchPointManager._instance.SetCurrentPoint (7);
		//DiamondManager._instance.AddDiamond (1800);

		SetChooseNotActive ();
		SetOtherButtonActive ();
		TechTree1.gameObject.SetActive (false);
		TechTree2.gameObject.SetActive (false);
		TechTree3.gameObject.SetActive (true);


		//Start create enemy from enemy manager1
		enemySpawnManager.StartCoroutine1 ();
		//stop create enemy from enemy manager2
		enemySpawnManager2.EndCoroutine2 ();

		/* start the game with 7th wave */
		//start create enemy from enemy manager2
		//enemySpawnManager2.StartCoroutine2 ();
		//stop create enemy from enemy manager1
		//enemySpawnManager.EndCoroutine1 ();
		CurrentTechTree = 3;
	}

	private void SetOtherButtonActive(){
		Continue.gameObject.SetActive (true);
		Start.gameObject.SetActive (true);
		Wiki.gameObject.SetActive (true);
	}

	private void SetChooseNotActive(){
		ChooseTree1.gameObject.SetActive (false);
		ChooseTree2.gameObject.SetActive (false);
		ChooseTree3.gameObject.SetActive (false);
	}
}
