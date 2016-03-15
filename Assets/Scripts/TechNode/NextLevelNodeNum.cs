using UnityEngine;
using System.Collections;

public class NextLevelNodeNum : MonoBehaviour {

	public UILabel label;
	public TechNode node;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		label.text = "Next Node: " + node.techNodeList.Count;
	}
}
