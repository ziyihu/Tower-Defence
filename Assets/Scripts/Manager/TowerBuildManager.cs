using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerBuildManager : MonoBehaviour {
	public static TowerBuildManager _instance;

	void Awake(){
		_instance = this;
	}

	//can put the basic tower or not
	public static bool tower01 = false;
	//can put the shotgun tower or not
	public static bool tower02 = false;
	//can put the laser tower or not
	public static bool tower10 = false;
	//can put the slow tower or not
	public static bool tower04 = false;
	//can put the missile tower or not
	public static bool tower07 = false;
	//can put the research tower or not
	public static bool research = false;
	//can put the small mine tower or not
	public static bool smallMine = false;
	//can put the large mine tower or not
	public static bool largeMine = false;
	//can put the small geneator or not
	public static bool smallGeneator = false;
	//can put the large geneator or not
	public static bool largeGeneator = false;
	//can put the targeting facility or not
	public static bool targetingFacility = false;
	//can put the super capacitor or not
	public static bool superCapacitor = false;
	//can put the alien recovery or not
	public static bool alienRecovery = false;

	public static bool tower03 = false;
	public static bool tower05 = false;
	public static bool tower06 = false;

	public static float tower1AttackRate = 1f;
	public static float tower2AttackRate = 2f;
	public static float tower4AttackRate = 2f;
	public static float tower7AttackRate = 2f;
	public static float tower10AttackRate = 2f;

	public static float time = 0;
	//the number of the current research tower(depending on how many research towers you have)
	private static int researchTowerNum = 0;
	//the number of the collection speed of diamond(depending on how many collection towers you have)
	private static int diamondColNum = 0;
	//the number of the current power you have(depending on the number of the power towers)
	private static int powerNum = 0;

	private static int smallMineNum = 0;
	private static int largeMineNum = 0;

	private static int smallGenNum = 0;
	private static int largeGenNum = 0;

	//get all the attack towers 
	private List<Character> allAttakBuilding = new List<Character> ();
	//has increase attack towers
	private List<Character> hasIncreasedBuilding = new List<Character>();
	//has increase attack rate towers
	private List<Character> hasIncreasedRateBuilding = new List<Character>();

	public List<AlienRecovery> GetAlienBuilding(){
		return gManager.alienRecList;
	}

	public List<Character> getAllAttackBuilding(){
		return allAttakBuilding;
	}

	public List<Tower4> GetStasisBuilding(){
		return gManager.tower4List;
	}

	//circle to show the attack range
	public GameObject circleObj;

	//tower info panel
	public TweenPosition towerInfoTween;
	private int level;
	private int attackNum;
	public GameObject towerInfo;
	Building building;
	CharacterManager cManager;
	GameManager gManager;

	public UIButton upgrade;

	public int GetResearchTowerNum(){
		return researchTowerNum;
	}

	public int GetDiamondCollectionSpeedNum(){
		diamondColNum = smallMineNum * 1 + largeMineNum * 2;
		return diamondColNum;
	}

	//one samll geneator can provide 5 power
	private static int smallGenPower = 5;
	//one big geneator can provide 10 power
	private static int bigGenPower = 10;

	public void SetSmallGenPower(int number){ smallGenPower = number; }
	public int GetSmallGenPower() { return smallGenPower; }

	public void SetBigGenPower(int number) { bigGenPower = number; }
	public int GetBigGenPower() { return bigGenPower; }

	public int GetCurrentPowerNum(){
		powerNum = smallGenNum * smallGenPower + largeGenNum * bigGenPower;
		return powerNum;
	}

	// Use this for initialization
	void Start () {
		cManager = new CharacterManager ();
		gManager = new GameManager ();
		//add the diamond resource to the game manager.
		Vector3 obstaclePos = new Vector3 (17.15f, 1.0f, 19.3f);
		DiamondResource diamond = (DiamondResource)cManager.SpawnCharacter (CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.DIAMOND, 1,
		                                                                    1, obstaclePos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
		diamond.SetPosition (obstaclePos);
		gManager.diamondList.Add (diamond);
		
		//tower2
		Vector3 obstacle1Pos = new Vector3 (21.15f, 1.0f, 19.3f);
		diamond = (DiamondResource)cManager.SpawnCharacter (CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.DIAMOND, 1,
		                                                    1, obstacle1Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
		diamond.SetPosition (obstacle1Pos);
		gManager.diamondList.Add (diamond);
		
		//tower3
		Vector3 obstacle2Pos = new Vector3 (15.15f, 1.0f, 17.3f);
		diamond = (DiamondResource)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.DIAMOND, 1,
		                                                   1, obstacle2Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
		diamond.SetPosition (obstacle2Pos);
		gManager.diamondList.Add (diamond);
	}
	
	// Update is called once per frame
	void Update () {
//		RaycastHit hit = new RaycastHit();
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		Physics.Raycast(ray, out hit, 100);
//		if (hit.collider.tag == "Map") {
//			Debug.Log("x:"+hit.point.x + "\t\ty:"+hit.point.y+"\t\tz:"+hit.point.z);
//		}
		time = time + Time.deltaTime;
		if (tower01) {
			if(Input.GetMouseButtonDown(0)){
				SetTower("tower1");
				tower01 = false;
			}
		} else if (tower02) {
			if(Input.GetMouseButtonDown(0)){
				SetTower("tower2");
				tower02 = false;
			}
		} else if(tower04){
			if(Input.GetMouseButtonDown(0)){
				SetTower("tower4");
				tower04 = false;
			}
		} else if(tower07){
			if(Input.GetMouseButtonDown(0)){
				SetTower("tower7");
				tower07 = false;
			}
		} else if(tower10){
			if(Input.GetMouseButtonDown(0)){
				SetTower("tower10");
				tower10 = false;
			}
		} else if(research){
			if(Input.GetMouseButtonDown(0)){
				SetTower("research");
				research = false;
			}
		} else if(smallMine){
			if(Input.GetMouseButtonDown(0)){
				SetTower("smallmine");
				smallMine = false;
			}
		} else if(largeMine){
			if(Input.GetMouseButtonDown(0)){
				SetTower("largemine");
				largeMine = false;
			}
		} else if(smallGeneator){
			if(Input.GetMouseButtonDown(0)){
				SetTower("smallgeneator");
				smallGeneator = false;
			}
		} else if(largeGeneator){
			if(Input.GetMouseButtonDown(0)){
				SetTower("largegeneator");
				largeGeneator = false;
			}
		} else if(targetingFacility) {
			if(Input.GetMouseButtonDown(0)){
				SetTower("targetingfacility");
				targetingFacility = false;
			}
		} else if(superCapacitor) {
			if(Input.GetMouseButtonDown(0)){
				SetTower("supercapacitor");
				superCapacitor = false;
			}
		} else if(alienRecovery){
			if(Input.GetMouseButtonDown(0)){
				SetTower("alienrecovery");
				alienRecovery = false;
			}
		}
		//if(time > tower1AttackRate){
			if (gManager.tower1List.Count > 0 && Time.timeScale == 1) {
				foreach (Tower1 t in gManager.tower1List) {
					t.CheckEnemy ();
					t.HitEnemy ();
				}
			}
		//	time = 0;
		//}
		if (gManager.tower2List.Count > 0 && Time.timeScale == 1) {
			foreach (Tower2 t in gManager.tower2List) {
				t.CheckEnemy ();
				t.HitEnemy();
			}
		}
		if (gManager.tower4List.Count > 0 && Time.timeScale == 1) {
			foreach (Tower4 t in gManager.tower4List) {
				t.SlowEnemy();
			}
		}
		if (gManager.tower7List.Count > 0 && Time.timeScale == 1) {
			foreach (Tower7 t in gManager.tower7List) {
				t.CheckEnemy();
				t.HitEnemy();
			}
		}
		if (gManager.tower10List.Count > 0 && Time.timeScale == 1) {
			foreach (Tower10 t in gManager.tower10List){
				t.CheckEnemy();
				t.HitEnemy();
			}
		}
		if (gManager.targetingFacList.Count > 0 && Time.timeScale == 1) {
			foreach(TargetingFacility t in gManager.targetingFacList){
				t.FindTowers();
				t.IncreaseAttack();
			}
		}
		if (gManager.superCapList.Count > 0 && Time.timeScale == 1) {
			foreach(SuperCapacitor t in gManager.superCapList){
				t.FindTowers();
				t.IncreaseAttackRate();
			}
		}
//		if (gManager.alienRecList.Count > 0 && Time.timeScale == 1) {
//			foreach(Character chara in gManager.alienRecList){
//				foreach(Character chara1 in EnemySpawnManager._instance.enemyList){
//					if(chara1.Life <= 0){
//						if(Vector3.Distance(chara.GetPos(),chara1.GetPos())< chara.GetAttackRange()){
//							//for every enemy, add 10 diamond when killing them
//							DiamondManager._instance.AddDiamond(10);
//						}
//					}
//				}
//			}
//		}
		//check if the enemy die in the range of the Alien Recovery Tower
		//if in the range, add diamond. else do nothing
		//TODO

		//click on the screen, if click on the tower, show the tower info
		if (Input.GetMouseButtonDown (0)) {
			GetTower();
		}
	}

	string name = null;
	string description = null;
	string attackNumber = null;
	string levelNumber = null;

	//show the tower info panel, update the info in the panel
	private void GetTower(){
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit, 100);
		if (hit.transform != null) {
			if (hit.transform.tag == "Tower1") {
				//show the current tower attack, upgrade button, destory button
				name = "Basic Tower";
				description = "this tower has middle attack range, medium rate of fire";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = building.GetAttackPower()+"";
				levelNumber = building.GetLevel()+"";
				//show the attack range
				SetAttackRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Tower2"){
				name = "Shotgun Tower";
				description = "this tower has low range, medium rate of fire, can shoot two enemies";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = building.GetAttackPower()+"";
				levelNumber = building.GetLevel()+"";
				SetAttackRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Tower4"){
				name = "Stasis Tower";
				description = "this tower slows the near enemies";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0 + "";
				levelNumber = building.GetLevel()+"";
				SetAttackRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Tower7"){
				name = "Missile Tower";
				description = "this tower attack the area enemies";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = building.GetAttackPower()+"";
				levelNumber = building.GetLevel()+"";
				SetAttackRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Tower10"){
				name = "Laser Tower";
				description = "this tower is the most powerful tower";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = building.GetAttackPower()+"";
				levelNumber = building.GetLevel()+"";
				SetAttackRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Research"){
				name = "Research Lab";
				description = "this tower will allow you to generate research point to be used in tech tree";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0 + "";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "SmallMine"){
				name = "Small Mine";
				description = "this tower collection diamond from nearby resource 1 per second";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0 +"";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "LargeMine"){
				name = "Large Mine";
				description = "this tower collection diamond from nearby resource 2 per second";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0 +"";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "SmallGeneator"){
				name = "Small Power";
				description = "this tower will provide "+ GetSmallGenPower() +" power";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "LargeGeneator"){
				name = "Large Power";
				description = "this tower will provide "+ GetBigGenPower() + " power";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Targeting"){
				name = "Targeting Facility";
				description = "this tower will increase 10 attack number for nearby towers";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0 + "";
				SetAttackRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "SuperCapacitor"){
				name = "Super Capacitor";
				description = "this tower will increase the attack rate for nearby towers";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0+"";
				SetAttackRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "AlienRecovery"){
				name = "Alien Recovery";
				description = "this tower will collect diamond when killing enemies in the range";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0+"";
				SetAttackRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			}


			else {
				SetAttackRangeHide();
			}
		}
	}

	private void SetAttackRangeShow(Building building){
		circleObj.gameObject.transform.GetComponent<DrawCircle>().m_Radius = building.GetAttackRange();
		circleObj.SetActive(true);
		circleObj.transform.position = building.GetPos();
	}

	private void SetAttackRangeHide(){
		circleObj.SetActive (false);
	}
	
	private void SetPanel(string nameText, string desText, string attackNumText, string levelNumText){
		if (building.GetLevel() <= 2) {
			upgrade.normalSprite = "btn_red1";
			upgrade.enabled = true;
		}else if (building.GetLevel() == 3) {
			upgrade.normalSprite = "btn_red4";
			upgrade.enabled = false;
		}
		if(building.buildingType == CharacterData.buildingMode.TOWER4 || building.buildingType == CharacterData.buildingMode.LAB
		   || building.buildingType == CharacterData.buildingMode.MINE1 || building.buildingType == CharacterData.buildingMode.MINE2
		   || building.buildingType == CharacterData.buildingMode.GENERATOR1 || building.buildingType == CharacterData.buildingMode.GENERATOR2
		   || building.buildingType == CharacterData.buildingMode.TARGETING || building.buildingType == CharacterData.buildingMode.CAPACITOR
		   || building.buildingType == CharacterData.buildingMode.ALIEN){
			upgrade.normalSprite = "btn_red4";
			upgrade.enabled = false;
		}
		towerInfoTween.PlayForward ();
		UILabel name = towerInfo.transform.Find ("Panel/NameLabel").GetComponent<UILabel> ();
		name.text = nameText;
		UILabel description = towerInfo.transform.Find ("Panel/DesLabel").GetComponent<UILabel> ();
		description.text = desText;
		UILabel attackNum = towerInfo.transform.Find ("Panel/AttackPanel/AttackNumber").GetComponent<UILabel> ();
		attackNum.text = attackNumText;
		UILabel levelNum = towerInfo.transform.Find("Panel/LevelPanel/LevelNumber").GetComponent<UILabel>();
		levelNum.text = levelNumText;
	}

	private static int tower1UpgradeAttackNumber = 10;
	private static int tower2UpgradeAttackNumber = 15;
	private static int tower7UpgradeAttackNumber = 20;
	private static int tower10UpgradeAttackNumber = 25;

	public void SetTower1UpgradeNumber(int number){	tower1UpgradeAttackNumber = number;}
	public int GetTower1UpgradeNumber() { return tower1UpgradeAttackNumber; }

	public void SetTower2UpgradeNumber(int number){ tower2UpgradeAttackNumber = number; }
	public int GetTower2UpgradeNumber() { return tower2UpgradeAttackNumber; }

	public void SetTower7UpgradeNumber(int number){ tower7UpgradeAttackNumber = number; }
	public int GetTower7UpgradeNumber() { return tower7UpgradeAttackNumber; }

	public void SetTower10UpgradeNumber(int number){ tower10UpgradeAttackNumber = number; }
	public int GetTower10UpgradeNumber() { return tower10UpgradeAttackNumber; }

	public void UpGradeBtnClick(){
		if (building.GetLevel() <= 1) {
			upgrade.normalSprite = "btn_red1";
			upgrade.enabled = true;
		}else if (building.GetLevel() > 1) {
			upgrade.normalSprite = "btn_red4";
			upgrade.enabled = false;
		}
		level = building.GetLevel ();
		//increase the attack power
		attackNum = building.GetAttackPower ();
		building.SetAttackPower (attackNum + tower10UpgradeAttackNumber);
		//increase the level
		level = level + 1;
		building.SetLevel (level);
		UpdatePanel ();
		if(building.buildingType == CharacterData.buildingMode.TOWER1 || building.buildingType == CharacterData.buildingMode.TOWER10
		   || building.buildingType == CharacterData.buildingMode.TOWER7){
			UpdateTexture ();
		} else if(building.buildingType == CharacterData.buildingMode.TOWER2){
			UpdateTexture2();
		}
	}

	public void DestoryBtnClick(){
		cManager.DestoryBuilding (building.ID);
		DestoryBuildingInList (building.ID);
		towerInfoTween.PlayReverse ();
	}

	private void UpdateTexture(){
		QuadTextureNgui tex = building.GetTransform().GetChild(0).GetComponent<QuadTextureNgui>();
		tex.mSpriteName = building.GetLevel() + "0000";
		tex.InitFace();
	}

	private void UpdateTexture2(){
		QuadTextureNgui tex = building.GetTransform().GetChild(0).GetComponent<QuadTextureNgui>();
		tex.mSpriteName = building.GetLevel() + " " + "(" + 19 + ")";;
		tex.InitFace();
	}

	public void DestoryBuildingInList(long id){
		SetAttackRangeHide ();
		for (int i = allAttakBuilding.Count - 1; i >= 0; i--) {
			if(allAttakBuilding[i].ID == id){
				allAttakBuilding[i].Destroy();
				allAttakBuilding.RemoveAt(i);
			}
		}
		for (int i = gManager.tower1List.Count - 1; i >= 0; i--) {
			if(gManager.tower1List[i].ID == id){
				gManager.tower1List[i].Destroy();
				gManager.tower1List.RemoveAt(i);
				break;
			}
		}
		for (int i = gManager.tower2List.Count - 1; i >= 0; i--) {
			if(gManager.tower2List[i].ID == id){
				gManager.tower2List[i].Destroy();
				gManager.tower2List.RemoveAt(i);
				break;
			}
		}
		for (int i = gManager.tower10List.Count - 1; i >= 0; i--) {
			if(gManager.tower10List[i].ID == id){
				gManager.tower10List[i].Destroy();
				gManager.tower10List.RemoveAt(i);
				break;
			}
		}
		for (int i = gManager.tower4List.Count - 1; i >= 0; i--) {
			if(gManager.tower4List[i].ID == id){
				gManager.tower4List[i].Destroy();
				gManager.tower4List.RemoveAt(i);
				break;
			}
		}
		for (int i = gManager.tower7List.Count - 1; i >= 0; i--) {
			if(gManager.tower7List[i].ID == id){
				gManager.tower7List[i].Destroy();
				gManager.tower7List.RemoveAt(i);
				break;
			}
		}
		for (int i = gManager.researchList.Count - 1; i >= 0; i--) {
			if(gManager.researchList[i].ID == id){
				gManager.researchList[i].Destroy();
				gManager.researchList.RemoveAt(i);
				researchTowerNum = gManager.researchList.Count;
				break;
			}
		}
		for (int i = gManager.smallMineList.Count - 1; i >= 0; i--) {
			if(gManager.smallMineList[i].ID == id){
				gManager.smallMineList[i].Destroy();
				gManager.smallMineList.RemoveAt(i);
				smallMineNum = gManager.smallMineList.Count;
				break;
			}
		}
		for (int i = gManager.largeMineList.Count - 1; i >= 0; i--) {
			if(gManager.largeMineList[i].ID == id){
				gManager.largeMineList[i].Destroy();
				gManager.largeMineList.RemoveAt(i);
				largeMineNum = gManager.largeMineList.Count;
				break;
			}
		}
		for (int i = gManager.smallGenList.Count - 1; i >= 0; i--) {
			if(gManager.smallGenList[i].ID == id){
				gManager.smallGenList[i].Destroy();
				gManager.smallGenList.RemoveAt(i);
				smallGenNum = gManager.smallGenList.Count;
				break;
			}
		}
		for (int i = gManager.largeGenList.Count - 1; i >= 0; i--) {
			if(gManager.largeGenList[i].ID == id){
				gManager.largeGenList[i].Destroy();
				gManager.largeGenList.RemoveAt(i);
				largeGenNum = gManager.largeGenList.Count;
				break;
			}
		}
		//delete the targeting tower, need to reset the attack number has been increased to normal
		for (int i = gManager.targetingFacList.Count - 1; i >= 0; i--) {
			if(gManager.targetingFacList[i].ID == id){
				//decrease all the tower attack power
				foreach(Character chara in gManager.targetingFacList[i].hasIncreasedList){
					chara.SetAttackPower(chara.GetAttackPower()-10);
				}
				gManager.targetingFacList[i].Destroy();
				gManager.targetingFacList.RemoveAt(i);
				break;
			}
		}
		//delete the supercap tower, need to reset the attack rate has been increased to normal
		for (int i = gManager.superCapList.Count - 1; i >= 0; i--) {
			if(gManager.superCapList[i].ID == id){
				//decrease all the tower attack power
				foreach(Character chara in gManager.superCapList[i].hasIncreasedList){
					chara.SetAttackRate(1f);
				}
				gManager.superCapList[i].Destroy();
				gManager.superCapList.RemoveAt(i);
				break;
			}
		}
		//delete the alien recovery tower
		for (int i = gManager.alienRecList.Count - 1; i >= 0; i--) {
			if(gManager.alienRecList[i].ID == id){
				gManager.alienRecList[i].Destroy();
				gManager.alienRecList.RemoveAt(i);
				break;
			}
		}
	}

	private void UpdatePanel(){
		UILabel attackNum = towerInfo.transform.Find ("Panel/AttackPanel/AttackNumber").GetComponent<UILabel> ();
		attackNum.text = building.GetAttackPower()+"";
		UILabel levelNum = towerInfo.transform.Find ("Panel/LevelPanel/LevelNumber").GetComponent<UILabel> ();
		levelNum.text = building.GetLevel () + "";
	}

	public void OnCloseBtnClick(){
		towerInfoTween.PlayReverse ();
	}

	private void SetTower(string tower){
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit, 100);
		if(hit.transform != null){
			if(hit.transform.tag == "Map"){
				//set the tower position
				float x = 0;
				if(hit.point.x - (int)hit.point.x <= 0.8f && hit.point.x - (int)hit.point.x > 0.3f){
					x = (int)hit.point.x + 0.65f;
				} else if(hit.point.x - (int)hit.point.x <= 0.3f && hit.point.x - (int)hit.point.x >= 0){
					x = (int)hit.point.x + 0.15f;
				} else {
					x = (int)hit.point.x + 1.15f;
				}
				float y = 1.0f;
				float z = 0;
				if(hit.point.z - (int)hit.point.z <= 0.05f && hit.point.z - (int)hit.point.z >= 0){
					z = (int)hit.point.z - 0.2f;
				} else if(hit.point.z - (int)hit.point.z <= 0.55f && hit.point.z - (int)hit.point.z > 0.05f){
					z = (int)hit.point.z + 0.3f;
				} else {
					z = (int)hit.point.z + 0.8f;
				}
				//in the enemy position, can not set the tower
				//restriction
				if(x <= 14.65f || x >= 23.65f || z <= 16.55f || z >= 25.3f){
					return;
				}
				//first path
				if(x == 15.65f && z >= 18.3f && z <= 24.8f){
					return;
				}
				//second path
				if(x >= 16.15f && x <= 20.15f && (z == 18.3f || z == 18.8f)){
					return;
				}
				//third path
				if((x == 19.65f || x == 20.15f) && z >= 18.8f && z <= 23.8f){
					return;
				}
				//forth path
				if((z == 23.3f || z == 23.8f) && x >= 20.65f && x <= 22.65f){
					return;
				}
				//fifth path
				if((x == 22.15f || x == 22.65f) && z >= 19.3f && z <= 22.8f){
					return;
				}
				if(x == 23.15f && (z == 19.8f || z == 19.3f)){
					return;
				}
				Vector3 obstacle3Pos = new Vector3 (x, y, z);
				foreach(Building building in cManager.building){
					if(obstacle3Pos == building.GetPos()){
						return;
					}
				}
				if(tower == "tower1"){
					Tower1 tower1 = (Tower1)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER1, 1,
				                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower1.SetPosition (obstacle3Pos);
					allAttakBuilding.Add(tower1);
					gManager.tower1List.Add(tower1);
				} else if(tower == "tower2"){
					Tower2 tower2 = (Tower2)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER2, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower2.SetPosition (obstacle3Pos);
					allAttakBuilding.Add(tower2);
					gManager.tower2List.Add(tower2);
				}else if(tower == "tower10"){
					Tower10 tower10 = (Tower10)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER10, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower10.SetPosition (obstacle3Pos);
					allAttakBuilding.Add(tower10);
					gManager.tower10List.Add(tower10);
				} else if(tower == "tower4"){
					Tower4 tower4 = (Tower4)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER4, 1,
					                                                   1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower4.SetPosition (obstacle3Pos);
					allAttakBuilding.Add(tower4);
					gManager.tower4List.Add(tower4);   
				} else if(tower == "tower7"){
					Tower7 tower7 = (Tower7)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER7, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower7.SetPosition (obstacle3Pos);
					allAttakBuilding.Add(tower7);
					gManager.tower7List.Add(tower7);   
				} else if(tower == "research"){
					Research research = (Research)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.LAB, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					research.SetPosition (obstacle3Pos);
					gManager.researchList.Add(research);
					researchTowerNum = gManager.researchList.Count;
				} else if(tower == "smallmine"){
					foreach(DiamondResource dr in gManager.diamondList){
						if(Vector3.Distance(dr.GetPos() ,obstacle3Pos) <= 0.8f){
							SmallMine sm = (SmallMine)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.MINE1, 1,
							                                                  1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
							sm.SetPosition (obstacle3Pos);
							sm.nearestDiamond = dr;
							gManager.smallMineList.Add(sm);
							smallMineNum = gManager.smallMineList.Count;
						}
					}
				}
				else if(tower == "largemine"){
					foreach(DiamondResource dr in gManager.diamondList){
						if(Vector3.Distance(dr.GetPos() ,obstacle3Pos) <= 0.8f){
							LargeMine lm = (LargeMine)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.MINE2, 1,
							                                                  1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
							lm.SetPosition (obstacle3Pos);
							lm.nearestDiamond = dr;
							gManager.largeMineList.Add(lm);
							largeMineNum = gManager.largeMineList.Count;
						}
					}
				}
				else if(tower == "smallgeneator"){
					SmallGeneator sg = (SmallGeneator)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.GENERATOR1, 1,
							                                                  1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					sg.SetPosition (obstacle3Pos);
					gManager.smallGenList.Add(sg);
					smallGenNum = gManager.smallGenList.Count;
				}
				else if(tower == "largegeneator"){
					LargeGeneator lg = (LargeGeneator)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.GENERATOR2, 1,
					                                                          1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					lg.SetPosition (obstacle3Pos);
					gManager.largeGenList.Add(lg);
					largeGenNum = gManager.largeGenList.Count;
				}
				else if(tower == "targetingfacility"){
					TargetingFacility tf = (TargetingFacility)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TARGETING, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tf.SetPosition (obstacle3Pos);
					gManager.targetingFacList.Add(tf);   
				}
				else if(tower == "supercapacitor"){
					SuperCapacitor sc = (SuperCapacitor)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.CAPACITOR, 1,
					                                                                  1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					sc.SetPosition (obstacle3Pos);
					gManager.superCapList.Add(sc);   
				}
				else if(tower == "alienrecovery"){
					AlienRecovery ar = (AlienRecovery)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.ALIEN, 1,
					                                                            1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					ar.SetPosition (obstacle3Pos);
					gManager.alienRecList.Add(ar);   
				}
			}
		}
		}

	public static Vector3 WorldToUI(Vector3 point)
	{
		Vector3 pt = Camera.main.WorldToScreenPoint (point);
		Vector3 ff = UICamera.mainCamera.ScreenToWorldPoint (pt);
		ff.z = 0;
		return ff;
	}

	public void OnTower01Clicked(){
		tower01 = true;
	}

	public void OnTower02Clicked(){
		tower02 = true;
	}

	public void OnTower10Clicked(){
		tower10 = true;
	}

	public void OnTower04Clicked(){
		tower04 = true;
	}

	public void OnTower07Clicked(){
		tower07 = true;
	}

	public void OnResearchClicked(){
		research = true;
	}

	public void OnSmallMineClicked(){
		smallMine = true;
	}

	public void OnLargeMineClicked(){
		largeMine = true;
	}

	public void OnSmallGenClicked(){
		smallGeneator = true;
	}

	public void OnLargeGenClicked(){
		largeGeneator = true;
	}

	public void OnTargetingClicked(){
		targetingFacility = true;
	}

	public void OnCapacitorClicked(){
		superCapacitor = true;
	}

	public void OnAlienClicked(){
		alienRecovery = true;
	}
}
