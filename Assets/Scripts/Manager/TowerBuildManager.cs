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

	public int GetCurrentPowerNum(){
		powerNum = smallGenNum * 5 + largeGenNum * 10;
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
				description = "this tower will provide 5 power";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "LargeGeneator"){
				name = "Large Power";
				description = "this tower will provide 10 power";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0 + "";
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
		   || building.buildingType == CharacterData.buildingMode.GENERATOR1 || building.buildingType == CharacterData.buildingMode.GENERATOR2){
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
		building.SetAttackPower (attackNum + 50);
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
					gManager.tower1List.Add(tower1);
				} else if(tower == "tower2"){
					Tower2 tower2 = (Tower2)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER2, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower2.SetPosition (obstacle3Pos);
					gManager.tower2List.Add(tower2);
				}else if(tower == "tower10"){
					Tower10 tower10 = (Tower10)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER10, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower10.SetPosition (obstacle3Pos);
					gManager.tower10List.Add(tower10);
				} else if(tower == "tower4"){
					Tower4 tower4 = (Tower4)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER4, 1,
					                                                   1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower4.SetPosition (obstacle3Pos);
					gManager.tower4List.Add(tower4);   
				} else if(tower == "tower7"){
					Tower7 tower7 = (Tower7)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER7, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower7.SetPosition (obstacle3Pos);
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
}
