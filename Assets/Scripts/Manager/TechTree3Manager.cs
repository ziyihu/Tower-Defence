using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TechTree3Manager : MonoBehaviour {

	public static TechTree3Manager instance;

	public List<TechNode> level1TechNodeList = new List<TechNode>();
	public List<TechNode> level2TechNodeList = new List<TechNode>();
	public List<TechNode> level3TechNodeList = new List<TechNode>();
	public List<TechNode> level4TechNodeList = new List<TechNode>();
	public List<TechNode> level5TechNodeList = new List<TechNode>();

	private List<TechNode> level1CopyTechNodeList = new List<TechNode>();
	private List<TechNode> level2CopyTechNodeList = new List<TechNode>();
	private List<TechNode> level3CopyTechNodeList = new List<TechNode>();
	private List<TechNode> level4CopyTechNodeList = new List<TechNode>();
	private List<TechNode> level5CopyTechNodeList = new List<TechNode>();

	private List<TechNode> level1Copy2TechNodeList = new List<TechNode>();
	private List<TechNode> level2Copy2TechNodeList = new List<TechNode>();
	private List<TechNode> level3Copy2TechNodeList = new List<TechNode>();
	private List<TechNode> level4Copy2TechNodeList = new List<TechNode>();
	private List<TechNode> level5Copy2TechNodeList = new List<TechNode>();

	void Awake(){
		instance = this;
	}


	// Use this for initialization
	void Start () {
		RandomRemoveAllLevelNodes ();
		CopyFromList ();
	//	RandomRemoveAllLevelNodes ();
		GeneatorRandomNodeTree ();
		GeneatroRandomTechTree ();
	}

	//chose the first node as the parent node
	private TechNode ChoseFirstOneParentFromList(List<TechNode> techNodeList){
		if(techNodeList.Count > 1){
			TechNode node = techNodeList [0];
			techNodeList.RemoveAt(0);
			return node;
		} else if(techNodeList.Count == 1){
			return techNodeList[0];		
		} else {
			Debug.Log("Not enough node in parent list");
			return null;
		}
	}

	//randomly chose a node as parent node
	private TechNode RandomChoseOneParentNodeFromList(List<TechNode> techNodeList){
		int i = 0;
		if (techNodeList.Count == 0) {
			return null;
		}
		if(techNodeList.Count > 1){
			i = Random.Range (0, techNodeList.Count);
			if (techNodeList [i] != null) {
				TechNode node = techNodeList[i];
				techNodeList.RemoveAt(i);
				return node;
			} else {
				return null;
			}
		} else{
			return techNodeList[0];
		}
	}

	private static int count = 0;
	private static int parentCount = 0;

	//separate node into groups
	private void SpearateNodeIntoGroups(List<TechNode> techNodeList, List<TechNode> parentTechNodeList,int level){
		TechNode parentNode = null;
		int i = 0;
		int k = 0;
		string link;
		while (techNodeList.Count != 0) {
			//have enough node to be in the sub group
			//set parent node, remove from the list
			i = GeneatorRandomNumber1To2();
			//have enough node
			if(techNodeList.Count >= i){

				//chose a random node for parent
				//TechNode parentNode = RandomChoseOneParentNodeFromList(parentTechNodeList);

				//chose the first one node as parent list
				parentNode = ChoseFirstOneParentFromList(parentTechNodeList); 
				for(int j = 0 ; j < i; j++){

					//the parent node has not been in the sub node before
					if(j == 0 && parentNode.techNodeList.Count == 0){
						parentNode.transform.localPosition = new Vector3(techNodeList[0].transform.localPosition.x,techNodeList[0].transform.localPosition.y+90,0);
					}


					//see the position between the parent node and child node
					//decide what kind of link set to use
					//TODO
					k = (int)((techNodeList[0].transform.localPosition.x - parentNode.transform.localPosition.x)/130);
//					link = "link/Up"+k.ToString();
//					if(techNodeList[0].transform.Find(link) != null)
//						techNodeList[0].transform.Find(link).gameObject.SetActive(true);
					if(k == 0){
						if(parentNode.transform.Find("link/Up1") != null){
							parentNode.transform.Find("link/Up1").gameObject.SetActive(true);
						}
					} else if(k == 1){
						if(parentNode.transform.Find("link/Up2") != null){
							parentNode.transform.Find("link/Up2").gameObject.SetActive(true);
						}
					} else if(k == 2){
						if(parentNode.transform.Find("link/Up3") != null){
							parentNode.transform.Find("link/Up3").gameObject.SetActive(true);
						}
					} else if(k == 3){
						if(parentNode.transform.Find("link/Up4") != null){
							parentNode.transform.Find("link/Up4").gameObject.SetActive(true);
						}
					} else if(k == 4){
						if(parentNode.transform.Find("link/Up5") != null){
							parentNode.transform.Find("link/Up5").gameObject.SetActive(true);
						}
					} else if(k == 5){
						if(parentNode.transform.Find("link/Up6") != null){
							parentNode.transform.Find("link/Up6").gameObject.SetActive(true);
						}
					} else if(k == 6){
						if(parentNode.transform.Find("link/Up7") != null){
							parentNode.transform.Find("link/Up7").gameObject.SetActive(true);
						}
					}

					//the parent node already have the sub node, the position will be the first one

					//chose a random node in child
					//int k = GeneatorRandomNumberInList(techNodeList);
					
					//chose the first node in the child list
					//set child and parent
					parentNode.techNodeList.Add(techNodeList[0]);

					//remove node from the child node list(already got a parent)
					techNodeList.RemoveAt(0);
					count ++;
				}
				parentCount ++;
			}
		}
		if (parentTechNodeList.Count == 1 && parentTechNodeList [0].techNodeList.Count != 0) {
			parentTechNodeList.RemoveAt(0);
		}

		while(parentTechNodeList.Count != 0){
			parentTechNodeList[0].transform.localPosition = new Vector3(parentNode.transform.localPosition.x + 130,parentNode.transform.localPosition.y,0);
			parentNode = parentTechNodeList[0];
			parentTechNodeList.RemoveAt(0);
		}
		count = 0;
		parentCount = 0;
	}

	//geneator a random number from 1 to 3
	private int GeneatorRandomNumber1To2(){
		int i = 0;
		i = Random.Range (0, 9);
		if (i >= 0 && i <= 4) {
			return 1;
		} else {
			return 2;
		} 
	}

	private int GeneatorRandomNumberInList(List<TechNode> techNodeList){
		return Random.Range (0, techNodeList.Count);
	}

	public static Vector3 WorldToUI(Vector3 point)
	{
		Vector3 pt = Camera.main.WorldToScreenPoint (point);
		Vector3 ff = UICamera.mainCamera.ScreenToWorldPoint (pt);
		ff.z = 0;
		return ff;
	}

	private static int number = 0;
	public void RandomOrderLevelTechnologyTree(List<TechNode> techNodeList,List<TechNode> techList,int level){
		techNodeList.Clear ();
		while (techList.Count > 0) {
			int i =GeneatorRandomNumberInList(techList);
			techNodeList.Add(techList[i]);
			techList[i].transform.localPosition = new Vector3(-350+number*130, 170-90*level,0);
			techList.RemoveAt(i);
			number++;
		}
		number = 0;
	}

	public void RandomRemoveFromList(List<TechNode> techNodeList,int number){
		int j = 0;
		for (int i = 0; i < number; i++) {
			j = Random.Range(0,techNodeList.Count-1);
			techNodeList[j].gameObject.SetActive(false);
			techNodeList.RemoveAt(j);
		}
	}

	private void CopyFromList(){
		foreach (TechNode node in level1TechNodeList) {
			level1CopyTechNodeList.Add(node);
		}
		foreach (TechNode node in level2TechNodeList) {
			level2CopyTechNodeList.Add(node);
		}
		foreach (TechNode node in level3TechNodeList) {
			level3CopyTechNodeList.Add(node);
		}
		foreach (TechNode node in level4TechNodeList) {
			level4CopyTechNodeList.Add(node);
		}
		foreach (TechNode node in level5TechNodeList) {
			level5CopyTechNodeList.Add(node);
		}
	}

	private void GeneatorRandomNodeTree(){
		RandomOrderLevelTechnologyTree (level1TechNodeList, level1CopyTechNodeList, 0);
		RandomOrderLevelTechnologyTree (level2TechNodeList, level2CopyTechNodeList, 1);
		RandomOrderLevelTechnologyTree (level3TechNodeList, level3CopyTechNodeList, 2);
		RandomOrderLevelTechnologyTree (level4TechNodeList, level4CopyTechNodeList, 3);
		RandomOrderLevelTechnologyTree (level5TechNodeList, level5CopyTechNodeList, 4);
		foreach (TechNode node in level1TechNodeList) {
			level1CopyTechNodeList.Add(node);
		}
		foreach (TechNode node in level2TechNodeList) {
			level2CopyTechNodeList.Add(node);
		}
		foreach (TechNode node in level3TechNodeList) {
			level3CopyTechNodeList.Add(node);
		}
		foreach (TechNode node in level4TechNodeList) {
			level4CopyTechNodeList.Add(node);
		}
		foreach (TechNode node in level5TechNodeList) {
			level5CopyTechNodeList.Add(node);
		}
	}

	private void GeneatroRandomTechTree(){
		SpearateNodeIntoGroups (level5TechNodeList, level4TechNodeList,4);
		level4TechNodeList.Clear ();
		
		foreach (TechNode node in level4CopyTechNodeList) {
			level4TechNodeList.Add(node);
		}
		SpearateNodeIntoGroups (level4TechNodeList, level3TechNodeList,3);
		level3TechNodeList.Clear ();
		
		foreach (TechNode node in level3CopyTechNodeList) {
			level3TechNodeList.Add(node);
		}
		SpearateNodeIntoGroups (level3TechNodeList, level2TechNodeList,2);
		level2TechNodeList.Clear ();
		
		foreach (TechNode node in level2CopyTechNodeList) {
			level2TechNodeList.Add(node);
		}
		SpearateNodeIntoGroups (level2TechNodeList, level1TechNodeList,1);
		level1TechNodeList.Clear ();
	}

	public void SetAllNodeNotActive(){
		foreach (TechNode node in level1CopyTechNodeList) {
			node.SetNodeActive();
		}
		foreach (TechNode node in level2CopyTechNodeList) {
			node.SetNodeNotActive();
		}
		foreach (TechNode node in level3CopyTechNodeList) {
			node.SetNodeNotActive();
		}
		foreach (TechNode node in level4CopyTechNodeList) {
			node.SetNodeNotActive();
		}
		foreach (TechNode node in level5CopyTechNodeList) {
			node.SetNodeNotActive();
		}
	}

	public void SetAllNextLevelNodeNull(){
		foreach (TechNode node in level1CopyTechNodeList) {
			node.techNodeList.Clear();
		}
		foreach (TechNode node in level2CopyTechNodeList) {
			node.techNodeList.Clear();
		}
		foreach (TechNode node in level3CopyTechNodeList) {
			node.techNodeList.Clear();
		}
		foreach (TechNode node in level4CopyTechNodeList) {
			node.techNodeList.Clear();
		}
		foreach (TechNode node in level5CopyTechNodeList) {
			node.techNodeList.Clear();
		}
	}

	private void RandomRemoveAllLevelNodes(){
		RandomRemoveFromList (level2TechNodeList, 0);
		RandomRemoveFromList (level3TechNodeList, 1);
		RandomRemoveFromList (level4TechNodeList, 2);
		RandomRemoveFromList (level5TechNodeList, 1);
	}

	private void ClearLevelLinks(List<TechNode> techNodeList){
		foreach (TechNode node in techNodeList) {
			if(node.transform.Find("link/Up1") != null)
				node.transform.Find("link/Up1").gameObject.SetActive(false);
			if(node.transform.Find("link/Up2") != null)
				node.transform.Find("link/Up2").gameObject.SetActive(false);
			if(node.transform.Find("link/Up3") != null)
				node.transform.Find("link/Up3").gameObject.SetActive(false);
			if(node.transform.Find("link/Up4") != null)
				node.transform.Find("link/Up4").gameObject.SetActive(false);
			if(node.transform.Find("link/Up5") != null)
				node.transform.Find("link/Up5").gameObject.SetActive(false);
			if(node.transform.Find("link/Up6") != null)
				node.transform.Find("link/Up6").gameObject.SetActive(false);
			if(node.transform.Find("link/Up7") != null)
				node.transform.Find("link/Up7").gameObject.SetActive(false);
		}
	}

	private void ClearAllLevelLinks(){
		ClearLevelLinks (level1TechNodeList);
		ClearLevelLinks (level2TechNodeList);
		ClearLevelLinks (level3TechNodeList);
		ClearLevelLinks (level4TechNodeList);
	}

	public void GeneatorNewTechTree(){
		SetAllNodeNotActive ();
		SetAllNextLevelNodeNull ();
		CopyFromList ();
	//	RandomRemoveAllLevelNodes ();
		GeneatorRandomNodeTree ();
		ClearAllLevelLinks ();
		GeneatroRandomTechTree ();
	}
}
