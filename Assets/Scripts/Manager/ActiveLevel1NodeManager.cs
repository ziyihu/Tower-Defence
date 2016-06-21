using UnityEngine;
using System.Collections;

public class ActiveLevel1NodeManager : MonoBehaviour {

	public TechNode node1;
	public TechNode node2;
	public TechNode node3;

	// Use this for initialization
	public void Active () {
		node1.OnBtnClicked ();
		node1.ActiveNextNode ();
		node2.OnBtnClicked ();
		node2.ActiveNextNode ();
		node3.OnBtnClicked ();
		node3.ActiveNextNode ();
	}

}
