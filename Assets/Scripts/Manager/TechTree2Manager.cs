﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TechTree2Manager : MonoBehaviour {

	public static TechTree2Manager instance;

	public UILabel level1AvaliableLabel;
	public UILabel level2AvaliableLabel;
	public UILabel level3AvaliableLabel;
	public UILabel level4AvaliableLabel;
	public UILabel level5AvaliableLabel;

	public List<TechNode> level1TechNodeList = new List<TechNode>();
	public List<TechNode> level2TechNodeList = new List<TechNode>();
	public List<TechNode> level3TechNodeList = new List<TechNode>();
	public List<TechNode> level4TechNodeList = new List<TechNode>();
	public List<TechNode> level5TechNodeList = new List<TechNode>();

	public static int level1ActiveNode = 0;
	public static int level2ActiveNode = 0;
	public static int level3ActiveNode = 0;
	public static int level4ActiveNode = 0;
	public static int level5ActiveNode = 0;

	public static int level2CanActiveNode = 0;
	public static int level3CanActiveNode = 0;
	public static int level4CanActiveNode = 0;
	public static int level5CanActiveNode = 0;
 
	// Use this for initialization
	void Start () {
		instance = this;
		level1AvaliableLabel.text = 3 + "";
		//Remove 1 node from level3
		RandomRemoveFromList (level3TechNodeList, 1);
		//Remove 1 node from level4
		RandomRemoveFromList (level4TechNodeList, 1);
		//Remove 1 node from level5
		RandomRemoveFromList (level5TechNodeList, 1);

		int number = 0;
		int level = 2;

		foreach (TechNode tn in level2TechNodeList) {
			//tn.SetNodeNotActive();
			level2AvaliableLabel.text = level2TechNodeList.Count + "";
		}

		foreach (TechNode tn in level3TechNodeList) {
			tn.SetNodeNotActive();
			tn.transform.localPosition = new Vector3(-350+number*130, 170-90*level,0);
			number++;
			level3AvaliableLabel.text = 0 + "";
		}

		number = 0;
		level++;

		foreach (TechNode tn in level4TechNodeList) {
			tn.SetNodeNotActive();
			tn.transform.localPosition = new Vector3(-350+number*130, 170-90*level,0);
			number++;
			level4AvaliableLabel.text = 0 + "";
		}

		number = 0;
		level++;

		foreach (TechNode tn in level5TechNodeList) {
			tn.SetNodeNotActive();
			tn.transform.localPosition = new Vector3(-350+number*130, 170-90*level,0);
			number++;
			level5AvaliableLabel.text = 0 + "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if active, remove from the level1 tech node list
		for (int i = 0; i < level1TechNodeList.Count; i++) {
			if(level1TechNodeList[i].isTechActive){
				level1TechNodeList.RemoveAt(i);
				i--;
			}
		}
		level1AvaliableLabel.text = level1TechNodeList.Count + "";
//		//if level1 count equals to 3, no level2 tech can be actived
//		if (level1TechNodeList.Count == 3) {
//			level2CanActiveNode = 0;
//		}
//		//if level1 count equals to 2, 2 of level2 tech can be actived
//		else if (level1TechNodeList.Count == 2) {
//			level2CanActiveNode = 2;
//		}
//		//if level1 count equals to 1, 3 of level2 tech can be actived
//		else if(level1TechNodeList.Count == 1){
//			level2CanActiveNode = 3;
//		}
//		//if level1 count equals to 0, 5 of level2 tech can be actived
//		else if(level1TechNodeList.Count == 0){
//			level2CanActiveNode = 5;
//		}

		//level2 technology tree
		if (level1TechNodeList.Count == 3) {
			foreach(TechNode tn in level2TechNodeList){
				tn.SetNodeNotActive();
			}
			level2AvaliableLabel.text = 0+"";
		} else if(level1TechNodeList.Count == 2 && 
		          level2TechNodeList.Count > 3){
			SetLevelTechNode(2);
			level2AvaliableLabel.text = level2TechNodeList.Count - 3 + "";

		} else if(level1TechNodeList.Count == 1 && 
		          level2TechNodeList.Count > 2){
			SetLevelTechNode(2);
			level2AvaliableLabel.text = level2TechNodeList.Count - 2 + "";
		} else if(level1TechNodeList.Count == 0 && 
		          level2TechNodeList.Count > 0){
			SetLevelTechNode(2);
			level2AvaliableLabel.text = level2TechNodeList.Count+"";
		} else {
			foreach(TechNode tn in level2TechNodeList){
				tn.SetNodeNotActive();
			}
			level2AvaliableLabel.text = 0+"";
		}


		//level3 technology tree
		if (level2TechNodeList.Count == 5) {
			foreach(TechNode tn in level3TechNodeList){
				tn.SetNodeNotActive();
			}
			level3AvaliableLabel.text = 0+"";
		} else if(level2TechNodeList.Count == 4 && 
		          level3TechNodeList.Count > 5){
			SetLevelTechNode(3);
			level3AvaliableLabel.text =  level3TechNodeList.Count - 5 +"";
		} else if(level2TechNodeList.Count == 3 && 
		          level3TechNodeList.Count > 4){
			SetLevelTechNode(3);
			level3AvaliableLabel.text =  level3TechNodeList.Count - 4 +"";
		} else if(level2TechNodeList.Count == 2 && 
		          level3TechNodeList.Count > 3){
			SetLevelTechNode(3);
			level3AvaliableLabel.text =  level3TechNodeList.Count - 3 +"";
		} else if(level2TechNodeList.Count == 1 && 
		          level3TechNodeList.Count > 2){
			SetLevelTechNode(3);
			level3AvaliableLabel.text =  level3TechNodeList.Count - 2 +"";
		} else if(level2TechNodeList.Count == 0 && 
		          level3TechNodeList.Count > 0){
			SetLevelTechNode(3);
			level3AvaliableLabel.text =  level3TechNodeList.Count +"";
		}else {
			foreach(TechNode tn in level3TechNodeList){
				tn.SetNodeNotActive();
			}
			level3AvaliableLabel.text = 0+"";
		}


		//level4 technology tree
		if (level3TechNodeList.Count == 6) {
			foreach(TechNode tn in level4TechNodeList){
				tn.SetNodeNotActive();
			}
			level4AvaliableLabel.text =  0 +"";
		} else if(level3TechNodeList.Count == 5 && 
		          level4TechNodeList.Count > 6){
			SetLevelTechNode(4);
			level4AvaliableLabel.text =  level4TechNodeList.Count - 6 +"";
		} else if(level3TechNodeList.Count == 4 && 
		          level4TechNodeList.Count > 4){
			SetLevelTechNode(4);
			level4AvaliableLabel.text =  level4TechNodeList.Count - 4 +"";
		} else if(level3TechNodeList.Count == 3 && 
		          level4TechNodeList.Count > 3){
			SetLevelTechNode(4);
			level4AvaliableLabel.text =  level4TechNodeList.Count - 3 +"";
		} else if(level3TechNodeList.Count == 2 && 
		          level4TechNodeList.Count > 2){
			SetLevelTechNode(4);
			level4AvaliableLabel.text =  level4TechNodeList.Count - 2 +"";
		} else if(level3TechNodeList.Count == 1 && 
		          level4TechNodeList.Count > 0){
			SetLevelTechNode(4);
			level4AvaliableLabel.text =  level4TechNodeList.Count +"";
		} else if(level3TechNodeList.Count == 0 && 
		          level4TechNodeList.Count > 0){
			SetLevelTechNode(4);
			level4AvaliableLabel.text =  level4TechNodeList.Count +"";
		} else {
			foreach(TechNode tn in level4TechNodeList){
				tn.SetNodeNotActive();
			}
			level4AvaliableLabel.text =  0 +"";
		}

		//level5 technology tree
		if (level4TechNodeList.Count == 7 ||
		    level4TechNodeList.Count == 6) {
			foreach(TechNode tn in level5TechNodeList){
				tn.SetNodeNotActive();
			}
			level5AvaliableLabel.text =  0 +"";
		} else if((level4TechNodeList.Count == 5 || level4TechNodeList.Count == 4)
		          && level5TechNodeList.Count > 3){
			SetLevelTechNode(5);
			level5AvaliableLabel.text =  level5TechNodeList.Count - 3 +"";
		} else if((level4TechNodeList.Count == 3 || level4TechNodeList.Count == 2)
		          && level5TechNodeList.Count > 2){
			SetLevelTechNode(5);
			level5AvaliableLabel.text =  level5TechNodeList.Count - 2 +"";
		} else if(level4TechNodeList.Count == 1 && 
		          level5TechNodeList.Count > 1){
			SetLevelTechNode(5);
			level5AvaliableLabel.text =  level5TechNodeList.Count - 1 +"";
		} else if(level4TechNodeList.Count == 0 && 
		          level5TechNodeList.Count > 0){
			SetLevelTechNode(5);
			level5AvaliableLabel.text =  level5TechNodeList.Count +"";
		}  else {
			foreach(TechNode tn in level5TechNodeList){
				tn.SetNodeNotActive();
			}
			level5AvaliableLabel.text = 0 +"";
		}
	}

	private void SetLevelTechNode(int level){
		if (level == 2) {
			for (int i = 0; i < level2TechNodeList.Count; i++) {
				if(level2TechNodeList[i].isTechActive){
					level2TechNodeList.RemoveAt(i);
					i--;
				} else {
					level2TechNodeList[i].SetNodeActive();
				}
			}
		} else if(level == 3){
			for (int i = 0; i < level3TechNodeList.Count; i++) {
				if(level3TechNodeList[i].isTechActive){
					level3TechNodeList.RemoveAt(i);
					i--;
				} else {
					level3TechNodeList[i].SetNodeActive();
				}
			}
		} else if(level == 4){
			for (int i = 0; i < level4TechNodeList.Count; i++) {
				if(level4TechNodeList[i].isTechActive){
					level4TechNodeList.RemoveAt(i);
					i--;
				} else {
					level4TechNodeList[i].SetNodeActive();
				}
			}
		} else if(level == 5){
			for (int i = 0; i < level5TechNodeList.Count; i++) {
				if(level5TechNodeList[i].isTechActive){
					level5TechNodeList.RemoveAt(i);
					i--;
				} else {
					level5TechNodeList[i].SetNodeActive();
				}
			}
		}
	}

	public void RandomRemoveFromList(List<TechNode> techNodeList,int number){
		int j = 0;
		for (int i = 0; i < number; i++) {
			j = Random.Range(0,techNodeList.Count-1);
			techNodeList[j].gameObject.SetActive(false);
			techNodeList.RemoveAt(j);
		}
	}
}
