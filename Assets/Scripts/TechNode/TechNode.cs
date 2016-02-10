using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TechNode : MonoBehaviour {
	//the node has been unlocked or not
	private static bool isTower1 = false;
	private static bool isTower2 = false;
	private static bool isTower3 = false;
	private static bool isTower4 = false;
	private static bool isTower5 = false;
	private static bool isTower6 = false;
	private static bool isTower7 = false;
	private static bool isTower8 = false;
	private static bool isTower9 = false;
	private static bool isTower10 = false;
	//no 15. tech node. Extra Damage
	private static bool isIncreasedPower = false;
	//no 17. tech node. Stasis field does damage
	private static bool isStasisDamage = false;
	//no 20. tech node. Generator provide more power
	private static bool isGeneratorPower = false;
	//no 22. tech node. Research Speed Up
	private static bool isResearchSpeedup = false;
	//no 23. tech node. Napalm
	private static bool isPoison = false;
	//no 26. tech node. Extra slow effect on all enemy
	private static bool isExtraSlow = false;
	
	public bool GetTower1{
		get { return isTower1; }
	}

	public bool GetTower2{
		get { return isTower2; }
	}

	public bool GetTower3{
		get { return isTower3; }
	}

	public bool GetTower4{
		get { return isTower4; }
	}

	public bool GetTower5{
		get { return isTower5; }
	}

	public bool GetTower6{
		get { return isTower6; }
	}

	public bool GetTower7{
		get { return isTower7; }
	}

	public bool GetTower8{
		get { return isTower8; }
	}

	public bool GetTower9{
		get { return isTower9; }
	}

	public bool GetTower10{
		get { return isTower10; }
	}

	public bool GetIncreasedPower{
		get { return isIncreasedPower; }
	}

	public bool GetStasisDamage{
		get { return isStasisDamage; }
	}

	public bool GetGeneratorPower{
		get { return isGeneratorPower; }
	}

	public bool GetResearchSpeedup{
		get { return isResearchSpeedup; }
	}

	public bool GetPosion{
		get { return isPoison; }
	}

	public bool GetExtraSlow{
		get { return isExtraSlow; }
	}

	public UIAtlas Atlas;
	public List<TechNode> techNodeList = new List<TechNode>();
	public string ableSprite;
	public string unableSprite;
	//active sprite, if the tech is loaded, set this active
	public UISprite active;
	private bool isActive = false;
	public UIButton nodeButton;

	void Start(){
		foreach (TechNode node in techNodeList) {
			node.nodeButton.isEnabled = false;
			if(unableSprite != null){
				node.nodeButton.normalSprite = node.unableSprite;
			}
			node.nodeButton.SetState(UIButtonColor.State.Disabled,true);
		}
	}

	public void ActiveNextNode(){
		if(Atlas != null){
			foreach (TechNode node in techNodeList) {
				node.nodeButton.isEnabled = true;
				if(ableSprite != null){
					node.nodeButton.normalSprite = node.ableSprite;
				}
				node.nodeButton.SetState(UIButtonColor.State.Normal,true);
//				node.nodeButton.hoverSprite = "btn_2";
//				node.nodeButton.pressedSprite = "btn_3";
//				node.nodeButton.disabledSprite = "btn_4";
			}
		}
	}

	public void OnBtnClicked(){
		isActive = true;
		nodeButton.SetState(UIButtonColor.State.Pressed,true);
		nodeButton.isEnabled = false;
		if(active != null)
			active.gameObject.SetActive (true);
		if (ableSprite == "bloodraven_1") {
			isTower8 = true;
		}
		if (ableSprite == "marine_1") {
			isTower1 = true;
		}
		if (ableSprite == "firebat_1") {
			isTower2 = true;
		}
		if (ableSprite == "shining_1") {
			isTower5 = true;
		}
		if (ableSprite == "rapidfire_1") {
			isTower3 = true;
		}
		if (ableSprite == "tank_1") {
			isTower4 = true;
		}
		if (ableSprite == "thor_1") {
			isTower6 = true;
		}
		if (ableSprite == "skyrunnerG_1") {
			isTower9 = true;
		}
		if (ableSprite == "toxic_1") {
			isTower7 = true;
		}
		if (ableSprite == "bismarck_1") {
			isTower10 = true;
		}
		if (ableSprite == "btnActive_o") {
			isIncreasedPower = true;
		}
		if (ableSprite == "towerUpgrad_o") {
			isStasisDamage = true;
		}
		if (ableSprite == "towerTank_1_o") {
			isGeneratorPower = true;
		}
		if (ableSprite == "towerTank_2_o") {
			isResearchSpeedup = true;
		}
		if (ableSprite == "towerStinger_o") {
			isPoison = true;
		}
		if (ableSprite == "towerskyrunner_2_o") {
			isExtraSlow = true;
		}
	}

	void Update(){
		if (isActive) {
			ActiveNextNode();
			isActive = false;
		}
	}
}
