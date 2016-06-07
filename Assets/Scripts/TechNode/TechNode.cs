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


	//no 7. tech node. Small Mine
	private static bool isSmallMine = false;
	//no 8. tech node. Large Mine
	private static bool isLargeMine = false;
	//no 9. tech node. Small Generator
	private static bool isSmallGenerator = false;
	//no 10. tech node. Large Generator
	private static bool isLargeGenerator = false;
	//no 11. tech node. Research Lab
	private static bool isResearchLab = false;
	//no 12. tech node. Targeting facility
	private static bool isTargeting = false;
	//no 13. tech node. Super Capacitor
	private static bool isSuperCapacitor = false;
	//no 14. tech node. Alien Recovery
	private static bool isAlienRecovery = false;

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
	//no 27. tech node. Life Recovery
	private static bool isLifeRecovery = false;


	//TODO
	//no 6. tech node. Antenna
	public static bool isAtenna = false;
	//no 16. tech node. Over Charge
	private static bool isOverCharge = false;
	//no 18. tech node. Antenna Range
	private static bool isAtennaRange = false;
	//no 19. tech node. Antenna Power
	private static bool isAtennaPower = false;
	//no 24. tech node. Armor Piercing
	private static bool isArmorPiercing = false;
	//no 25. tech node. Extra Slow2
	private static bool isExtraSlow2 = false;

	public bool isExistParent = false;
	public bool isBeingParent = false;

	//is this tech node active or not
	public bool isTechActive = false;

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

	public bool GetSmallMine{
		get { return isSmallMine; }
	}

	public bool GetLargeMine{
		get { return isLargeMine; }
	}

	public bool GetSmallGenerator{
		get { return isSmallGenerator; }
	}

	public bool GetLargeGenerator{
		get { return isLargeGenerator; }
	}

	public bool GetResearchLab{
		get { return isResearchLab; }
	}

	public bool GetTargetingFacility{
		get { return isTargeting; }
	}

	public bool GetSuperCapacitor{
		get { return isSuperCapacitor; }
	}

	public bool GetAlienRecovery{
		get { return isAlienRecovery; }
	}

	//TODO
	public bool GetAnetnna{
		get { return isAtenna; }
	}

	public bool GetOverCharge{
		get { return isOverCharge; }
	}

	public bool GetAntennaRange{
		get { return isAtennaRange; }
	}

	public bool GetAntennaPower{
		get { return isAtennaPower; }
	}

	public bool GetArmorPiercing{
		get { return isArmorPiercing; }
	}

	public bool GetExtraSlow2{
		get { return isExtraSlow2; }
	}
	public bool GetLifeRecovery{
		get { return isLifeRecovery; }
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
		if (ableSprite != "marine_1" && ableSprite != "Antenna001" && ableSprite != "smallMine"){
			foreach (TechNode node in techNodeList) {
				node.nodeButton.GetComponent<UIButton>().enabled = false;
				if(unableSprite != null){
					node.nodeButton.normalSprite = node.unableSprite;
				}
				node.nodeButton.SetState(UIButtonColor.State.Disabled,true);
			}
		}
	}

	public void SetNodeNotActive(){
		active.gameObject.SetActive (false);
		this.nodeButton.GetComponent<UIButton> ().enabled = false;
		this.nodeButton.normalSprite = unableSprite;
		this.nodeButton.SetState (UIButtonColor.State.Disabled, true);
	}

	public void SetNodeActive(){
		active.gameObject.SetActive (false);
		this.nodeButton.GetComponent<UIButton> ().enabled = true;
		this.nodeButton.normalSprite = ableSprite;
		this.nodeButton.SetState(UIButtonColor.State.Normal,true);
	}

	public void ActiveNextNode(){
		if(Atlas != null){
			foreach (TechNode node in techNodeList) {
				node.nodeButton.GetComponent<UIButton>().enabled = true;
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

	private void UsePointGetTech(){
		ResearchPointManager._instance.UseResearchPoint ();
		ActiveNextNode ();
		nodeButton.GetComponent<UIButton> ().enabled = false;
	}

	public void OnBtnClicked(){
		nodeButton.SetState(UIButtonColor.State.Pressed,true);
		if(ResearchPointManager._instance.GetResearchPoint() > 0){
			if(active != null){
				active.gameObject.SetActive (true);
				isTechActive = true;
			}
			if (ableSprite == "bloodraven_1") {
				isTower8 = true;
				UsePointGetTech();
			}
			if (ableSprite == "marine_1") {
				isTower1 = true;
				UsePointGetTech();
			}
			if (ableSprite == "firebat_1") {
				isTower2 = true;
				UsePointGetTech();
			}
			if (ableSprite == "shining_1") {
				isTower5 = true;
				UsePointGetTech();
			}
			if (ableSprite == "rapidfire_1") {
				isTower3 = true;
				UsePointGetTech();
			}
			if (ableSprite == "tank_1") {
				isTower4 = true;
				UsePointGetTech();
			}
			if (ableSprite == "thor_1") {
				isTower6 = true;
				UsePointGetTech();
			}	
			if (ableSprite == "skyrunnerG_1") {
				isTower9 = true;
				UsePointGetTech();
			}
			if (ableSprite == "toxic_1") {
				isTower7 = true;
				UsePointGetTech();
			}
			if (ableSprite == "bismarck_1") {
				isTower10 = true;
				UsePointGetTech();
			}
			if (ableSprite == "btnActive_o") {
				isIncreasedPower = true;
				UsePointGetTech();
			}
			if (ableSprite == "towerUpgrad_o") {
				isStasisDamage = true;
				UsePointGetTech();
			}
			if (ableSprite == "towerTank_1_o") {
				isGeneratorPower = true;
				UsePointGetTech();
			}
			if (ableSprite == "towerTank_2_o") {
				isResearchSpeedup = true;
				UsePointGetTech();
			}
			if (ableSprite == "towerStinger_o") {
				isPoison = true;
				UsePointGetTech();
			}
			if (ableSprite == "btnOption_p") {
				isExtraSlow = true;
				UsePointGetTech();
			}
			if (ableSprite == "smallMine") {
				isSmallMine = true;
				UsePointGetTech();
			}
			if (ableSprite == "largeMine") {
				isLargeMine = true;
				UsePointGetTech();
			}
			if (ableSprite == "research001") {
				isResearchLab = true;
				UsePointGetTech();
			}
			if (ableSprite == "smallgenerator002") {
				isSmallGenerator = true;
				UsePointGetTech();
			}
			if (ableSprite == "largegenerator001") {
				isLargeGenerator = true;
				UsePointGetTech();
			}
			if (ableSprite == "Targeting") {
				isTargeting = true;
				UsePointGetTech();
			}
			if(ableSprite == "supercapacitor001"){
				isSuperCapacitor = true;
				UsePointGetTech();
			}
			if(ableSprite == "AlienRecovery"){
				isAlienRecovery = true;
				UsePointGetTech();
			}
			if (ableSprite == "Antenna001") {
				isAtenna = true;
				UsePointGetTech();
			}
			if (ableSprite == "btnPlay_p") {
				isOverCharge = true;
				UsePointGetTech();
			}
			if (ableSprite == "towertoxic_o") {
				isAtennaRange = true;
				UsePointGetTech();
			}
			if (ableSprite == "towerbismarck_o") {
				isAtennaPower = true;
				UsePointGetTech();
			}
			if (ableSprite == "btnSpeed_p") {
				isArmorPiercing = true;
				UsePointGetTech();
			}
			if (ableSprite == "towerskyrunner_2_o") {
				isExtraSlow2 = true;
				UsePointGetTech();
			}
			if (ableSprite == "towerskyrunner_1_o") {
				isLifeRecovery = true;
				UsePointGetTech();
			}
	}
	}

}
