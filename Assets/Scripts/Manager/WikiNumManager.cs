using UnityEngine;
using System.Collections;

public class WikiNumManager : MonoBehaviour {

	private UILabel enemy1Label;
	private UILabel enemy2Label;
	private UILabel enemy3Label;
	private UILabel enemy4Label;
	private UILabel enemy5Label;
	private UILabel enemy6Label;
	CharacterManager cManager;

	// Use this for initialization
	void Start () {
		cManager = new CharacterManager ();
		enemy1Label = this.transform.Find("bg/WikiPanel/Enemy1/Enemy1Des").GetComponent<UILabel>();
		enemy2Label = this.transform.Find("bg/WikiPanel/Enemy2/Enemy2Des").GetComponent<UILabel>();
		enemy3Label = this.transform.Find("bg/WikiPanel/Enemy3/Enemy3Des").GetComponent<UILabel>();
		enemy4Label = this.transform.Find("bg/WikiPanel/Enemy4/Enemy4Des").GetComponent<UILabel>();
		enemy5Label = this.transform.Find("bg/WikiPanel/Enemy5/Enemy5Des").GetComponent<UILabel>();
		enemy6Label = this.transform.Find("bg/WikiPanel/Enemy6/Enemy6Des").GetComponent<UILabel>();

		enemy1Label.text = "HP: " + cManager.hpList [0] + "\n" + "ARMOR: " + cManager.armorList [0];
		enemy2Label.text = "HP: " + cManager.hpList [1] + "\n" + "ARMOR: " + cManager.armorList [1];
		enemy3Label.text = "HP: " + cManager.hpList [2] + "\n" + "ARMOR: " + cManager.armorList [2];
		enemy4Label.text = "HP: " + cManager.hpList [3] + "\n" + "ARMOR: " + cManager.armorList [3];
		enemy5Label.text = "HP: " + cManager.hpList [4] + "\n" + "ARMOR: " + cManager.armorList [4];
		enemy6Label.text = "HP: " + cManager.hpList [5] + "\n" + "ARMOR: " + cManager.armorList [5];
	}

}
