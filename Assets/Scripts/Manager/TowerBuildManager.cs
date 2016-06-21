using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerBuildManager : MonoBehaviour {
	public static TowerBuildManager _instance;

	protected GameObject go1;

	public UILabel upgradeDiamondNum;
	void Awake(){
		go1 = (GameObject)GameObject.Instantiate(Resources.Load("Circle"));
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
	//can put the antenna or not
	public static bool antenna = false;

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
	private static int powerNum = 8;

	private static int smallMineNum = 0;
	private static int largeMineNum = 0;

	private static int smallGenNum = 0;
	private static int largeGenNum = 0;

	public int GetSmallGenNum(){
		return smallGenNum;
	}

	public int GetLargeGenNum(){
		return largeGenNum;
	}

	//cost of towers
	//basic tower : 10	shotgun : 30	stasis field : 40	Howiztzer : 50	Laser : 100
	//research : 40		smallmine : 30	largemine : 100		smallpow : 30	largepow : 100
	//targeting : 50	supercapacitor : 50		alien : 50	antenna : 30
	private List<int> towerCostList = new List<int>(){10,30,40,50,100,40,30,100,30,100,50,50,50,30};

	//get all the attack towers 
	private List<Character> allAttakBuilding = new List<Character> ();
	//has increase attack towers
	private List<Character> hasIncreasedBuilding = new List<Character>();
	//has increase attack rate towers
	private List<Character> hasIncreasedRateBuilding = new List<Character>();

	//all towers need power to work
	private List<Character> needPowerTowers = new List<Character>();
	//all antenna tower, when add power to the antenna, delete it from the list and
	private List<Character> antennaList = new List<Character>();

	public List<AlienRecovery> GetAlienBuilding(){
		return gManager.alienRecList;
	}

	public List<Character> getAllAttackBuilding(){
		return allAttakBuilding;
	}

	public List<Tower4> GetStasisBuilding(){
		return gManager.tower4List;
	}

	public List<Character> GetNeedPowerTowers(){
		return needPowerTowers;
	}

	public List<Character> GetAntennaList(){
		return antennaList;
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
	public GameManager gManager;

	public UIButton upgrade;

	public int GetResearchTowerNum(){
		return researchTowerNum;
	}

	public int GetDiamondCollectionSpeedNum(){
		diamondColNum = smallMineNum * 1 + largeMineNum * 2;
		return diamondColNum;
	}

	TechNode techNode = new TechNode();

	public int PowerGenerated(){
		if (techNode.GetGeneratorPower) {
			return gManager.smallGenList.Count*7+gManager.largeGenList.Count*10;
		} else {
			return gManager.smallGenList.Count*5+gManager.largeGenList.Count*7;
		}
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
		return powerNum;
	}
	public void UseCurrentPowerNum(int number){
		powerNum -= number;
	}
	public void AddPower(int number){
		powerNum += number;
	}

	public int AttackBuildingNum(){
		return getAllAttackBuilding ().Count;
	}

	public int AllBuildingNum(){
		return AttackBuildingNum () + gManager.tower4List.Count + gManager.antennaList.Count +
						gManager.superCapList.Count + gManager.targetingFacList.Count + gManager.alienRecList.Count +
						gManager.largeGenList.Count + gManager.largeMineList.Count + gManager.researchList.Count +
						gManager.smallGenList.Count + gManager.smallMineList.Count;
	}

	TechNode node;

	// Use this for initialization
	void Start () {
		node = new TechNode ();
		cManager = new CharacterManager ();
		gManager = new GameManager ();
		//add the diamond resource to the game manager.
		Vector3 obstaclePos = new Vector3 (17.15f, 1.0f, 23.8f);
		DiamondResource diamond = (DiamondResource)cManager.SpawnCharacter (CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.DIAMOND, 1,
		                                                                    1, obstaclePos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
		diamond.SetPosition (obstaclePos);
		gManager.diamondList.Add (diamond);
		
		//tower2
		Vector3 obstacle1Pos = new Vector3 (21.15f, 1.0f, 17.8f);
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




	private static GameObject go = null;

	//decide whether can set tower or not
	private void PreSetTower(string name,RaycastHit hit){
		if(go==null){
			go = (GameObject)GameObject.Instantiate (Resources.Load (name));
			go.transform.position = Vector3.zero;
		}
		if(go!=null && hit.point!=null){
			go.gameObject.GetComponent<BoxCollider>().enabled = false;
			go.transform.position = hit.point;
		}
		
		if(hit.collider != null){
			if(hit.collider.tag == "Map"){
				go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
			} else {
				go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
			}
		}
		
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
			go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
		}
		//first path
		if(x == 15.65f && z >= 18.3f && z <= 24.8f){
			go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
		}
		//second path
		if(x >= 16.15f && x <= 20.15f && (z == 18.3f || z == 18.8f)){
			go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
		}
		//third path
		if((x == 19.65f || x == 20.15f) && z >= 18.8f && z <= 23.8f){
			go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
		}
		//forth path
		if((z == 23.3f || z == 23.8f) && x >= 20.65f && x <= 22.65f){
			go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
		}
		//fifth path
		if((x == 22.15f || x == 22.65f) && z >= 19.3f && z <= 22.8f){
			go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
		}
		if(x == 23.15f && (z == 19.8f || z == 19.3f)){
			go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
		}


	 	if(name == "smallmine"){
			Vector3 obstacle3Pos = new Vector3(hit.point.x,1,hit.point.z);
			go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
			foreach(DiamondResource dr in gManager.diamondList){
				if(Vector3.Distance(dr.GetPos() ,obstacle3Pos) <= 0.8f && hit.collider.tag == "Map" && x > 14.65f){
					go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
				}
			}
		}
		else if(name == "largemine"){
			Vector3 obstacle3Pos = new Vector3(hit.point.x,1,hit.point.z);
			go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
			foreach(DiamondResource dr in gManager.diamondList){
				if(Vector3.Distance(dr.GetPos() ,obstacle3Pos) <= 0.8f && hit.collider.tag == "Map" && x > 14.65f){
					go.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
				}
			}
		}
		
	}

	private bool InSlowTowerRange = false;
	private float extraSlowNum = 1.0f;
	public void SetExtraSlowNum(float number){
		extraSlowNum = number;
	}
	public float GetExtraSlowNum(){
		return extraSlowNum;
	}

	private void SetAttackRangeShow(Building building){
		circleObj.gameObject.transform.GetComponent<DrawCircle>().m_Radius = building.GetAttackRange();
		circleObj.SetActive(true);
		circleObj.transform.position = building.GetPos();
	}
	
	private void SetAttackRangeHide(){
		circleObj.SetActive (false);
	}

	private void ShowRangeBeforePuttingTower(float range,RaycastHit hit){
		if(hit.transform != null){
			if(hit.transform.tag == "Map"){
				circleObj.gameObject.transform.GetComponent<DrawCircle>().m_Radius = range;
				circleObj.SetActive(true);
				circleObj.transform.position = hit.point;
			} else {
				circleObj.SetActive(false);
			}
		} else 
			circleObj.SetActive(false);
	}

	private void ShowRangeBeforePuttingTowerUsingSprite(float range, RaycastHit hit){
				if (hit.transform != null) {
						if (hit.transform.tag == "Map") {
								go1.transform.FindChild ("Quad").transform.localScale = new Vector3 (range, range, 0.5f);
								//go1.gameObject.transform.localScale = new Vector3(range,range,0.5f);
								go1.SetActive (true);
								go1.transform.position = hit.point;
						} 
						else {
								go1.SetActive(false);
						}
						} else 
							go1.SetActive(false);
		}

	private void SetSpriteRangeShow(Building building){
		go1.transform.FindChild ("Quad").transform.localScale = new Vector3 (building.GetAttackRange()*4, building.GetAttackRange()*4, 0.5f);
		go1.SetActive (true);
		go1.transform.position = building.GetPos ();
	}

	private void SetSpriteRangeHide(){
		go1.SetActive (false);
	}

	private RaycastHit Raycast(){
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit, 100);
		return hit;
	}

	RaycastHit hit;

	// Update is called once per frame
	void Update () {
		if (tower01) {
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("tower1");
				tower01 = false;
			}
			hit = Raycast();
			//show the range before putting the tower
			ShowRangeBeforePuttingTower(2.25f,hit);
			ShowRangeBeforePuttingTowerUsingSprite(9f,hit);
			PreSetTower("tower1",hit);
		} else if (tower02) {
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("tower2");
				tower02 = false;
			}
			hit = Raycast();
			ShowRangeBeforePuttingTower(2f,hit);
			ShowRangeBeforePuttingTowerUsingSprite(8f,hit);
			PreSetTower("tower2",hit);
		} else if(tower04){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("tower4");
				tower04 = false;
			}
			hit = Raycast();
			ShowRangeBeforePuttingTower(2f,hit);
			ShowRangeBeforePuttingTowerUsingSprite(8f,hit);
			PreSetTower("tower4",hit);
		} else if(tower07){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("tower7");
				tower07 = false;
			}
			hit = Raycast();
			ShowRangeBeforePuttingTower(2.5f,hit);
			ShowRangeBeforePuttingTowerUsingSprite(10f,hit);
			PreSetTower("tower7",hit);
		} else if(tower10){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("tower10");
				tower10 = false;
			}
			hit = Raycast();
			ShowRangeBeforePuttingTower(2.5f,hit);
			ShowRangeBeforePuttingTowerUsingSprite(10f,hit);
			PreSetTower("tower10",hit);
		} else if(research){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("research");
				research = false;
			}
			hit = Raycast();
			PreSetTower("research",hit);
		} else if(smallMine){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("smallmine");
				smallMine = false;
			}
			hit = Raycast();
			//small mine is a little different, need to do some modify
			//TODO
			PreSetTower("smallmine",hit);
		} else if(largeMine){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("largemine");
				largeMine = false;
			}
			hit = Raycast();
			//large mine is the same as small mine, need to do some modify
			//TODO
			PreSetTower("largemine",hit);

		} else if(smallGeneator){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("smallgeneator");
				smallGeneator = false;
			}
			hit = Raycast();
			PreSetTower("smallgeneator",hit);
		} else if(largeGeneator){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("largegeneator");
				largeGeneator = false;
			}
			hit = Raycast();
			PreSetTower("largegeneator",hit);
		} else if(targetingFacility) {
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("targetingfacility");
				targetingFacility = false;
			}
			hit = Raycast();
			ShowRangeBeforePuttingTower(1f,hit);
			ShowRangeBeforePuttingTowerUsingSprite(4f,hit);
			PreSetTower("targeting",hit);
		} else if(superCapacitor) {
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("supercapacitor");
				superCapacitor = false;
			}
			hit = Raycast();
			ShowRangeBeforePuttingTower(1f,hit);
			ShowRangeBeforePuttingTowerUsingSprite(4f,hit);
			PreSetTower("supercapacitor",hit);
		} else if(alienRecovery){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("alienrecovery");
				alienRecovery = false;
			}
			hit = Raycast();
			ShowRangeBeforePuttingTower(2f,hit);
			ShowRangeBeforePuttingTowerUsingSprite(8f,hit);
			PreSetTower("alienrecovery",hit);
		} else if(antenna){
			if(Input.GetMouseButtonDown(0)){
				Destroy(go);
				SetTower("antenna");
				antenna = false;
			}
			hit = Raycast();
			if(techNode.GetAntennaRange){
				ShowRangeBeforePuttingTower(1.5f,hit);
				ShowRangeBeforePuttingTowerUsingSprite(6f,hit);
			} else {
				ShowRangeBeforePuttingTower(0.5f,hit);
				ShowRangeBeforePuttingTowerUsingSprite(2f,hit);
			}
			PreSetTower("antenna",hit);
		}
		//if(time > tower1AttackRate){
//		if (gManager.tower1List.Count > 0 && Time.timeScale == 1) {
//			foreach (Tower1 t in gManager.tower1List) {
//				if(t.GetPowerProvider()!=null){
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
//					t.CheckEnemy ();
//					t.HitEnemy ();
//				} else {
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
//				}
//			}
//		}
		//	time = 0;
		//}
//		if (gManager.tower2List.Count > 0 && Time.timeScale == 1) {
//			foreach (Tower2 t in gManager.tower2List) {
//				if(t.GetPowerProvider()!= null){
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
//					t.CheckEnemy ();
//					t.HitEnemy();
//				} else {
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
//				}
//			}
//		}
//		if (gManager.tower4List.Count > 0 && Time.timeScale == 1) {
//			for(int i = 0 ; i < EnemySpawnManager._instance.enemyList.Count ; i++){
//				foreach (Tower4 t in gManager.tower4List) {
//					if(t.GetPowerProvider()!= null){
//						t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
//						//in the range
//						if(t.InRange(i)){
//							//slow the enemy
//							EnemySpawnManager._instance.enemyList[i].SetSpeed(0.015f * extraSlowNum);
//							EnemySpawnManager._instance.enemyList[i].isSlow = true;
//							InSlowTowerRange = true;
//						}
//					} else {
//						t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
//					}
//					if(InSlowTowerRange == false){
//						if(node.GetExtraSlow2){
//							EnemySpawnManager._instance.enemyList[i].SetSpeed(0.018f * extraSlowNum);
//						} else {
//							EnemySpawnManager._instance.enemyList[i].SetSpeed(0.02f * extraSlowNum);
//						}
//					}
//					InSlowTowerRange = false;
//				}
//				}
//
//		}
//		if (gManager.tower7List.Count > 0 && Time.timeScale == 1) {
//			foreach (Tower7 t in gManager.tower7List) {
//				if(t.GetPowerProvider()!=null){
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
//					t.CheckEnemy();
//					t.HitEnemy();
//				} else {
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
//				}
//			}
//		}
//		if (gManager.tower10List.Count > 0 && Time.timeScale == 1) {
//			foreach (Tower10 t in gManager.tower10List){
//				if(t.GetPowerProvider()!=null){
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
//					t.CheckEnemy();
//					t.HitEnemy();
//				} else {
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
//				}
//			}
//		}
//		if (gManager.targetingFacList.Count > 0 && Time.timeScale == 1) {
//			foreach(TargetingFacility t in gManager.targetingFacList){
//				if(t.GetPowerProvider()!=null){
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
//					t.FindTowers();
//					t.IncreaseAttack();
//				} else {
//					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
//				}
//			}
//		}
		if (gManager.superCapList.Count > 0 && Time.timeScale == 1) {
			foreach(SuperCapacitor t in gManager.superCapList){
				if(t.GetPowerProvider()!=null){
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
					t.FindTowers();
					t.IncreaseAttackRate();
				} else {
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
				}
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
				description = "This tower has middle attack range, medium rate of fire\n\n"+"Need 1 power to function";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = building.GetAttackPower()+"";
				levelNumber = building.GetLevel()+"";
				//show the attack range
				SetAttackRangeShow(building);
				//show the attack range using sprite
				SetSpriteRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Tower2"){
				name = "Shotgun Tower";
				description = "This tower has low range, medium rate of fire, can shoot four enemies\n\n"+"Need 2 power to function";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = building.GetAttackPower()+"";
				levelNumber = building.GetLevel()+"";
				SetAttackRangeShow(building);
				//show the attack range using sprite
				SetSpriteRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Tower4"){
				name = "Stasis Tower";
				description = "This tower slows the near enemies\n\n"+"Need 1 power to function";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0 + "";
				levelNumber = building.GetLevel()+"";
				SetAttackRangeShow(building);
				//show the attack range using sprite
				SetSpriteRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Tower7"){
				name = "Missile Tower";
				description = "This tower attack the area enemies\n\n"+"Need 2 power to function";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = building.GetAttackPower()+"";
				levelNumber = building.GetLevel()+"";
				SetAttackRangeShow(building);
				//show the attack range using sprite
				SetSpriteRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Tower10"){
				name = "Laser Tower";
				description = "This tower is the most powerful tower\n\n"+"Need 3 power to function";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = building.GetAttackPower()+"";
				levelNumber = building.GetLevel()+"";
				SetAttackRangeShow(building);
				//show the attack range using sprite
				SetSpriteRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Research"){
				name = "Research Lab";
				description = "This tower will allow you to generate research point to be used in tech tree";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0 + "";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "SmallMine"){
				name = "Small Mine";
				description = "This tower collection diamond from nearby resource 1 per second";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0 +"";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "LargeMine"){
				name = "Large Mine";
				description = "This tower collection diamond from nearby resource 2 per second";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0 +"";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "SmallGeneator"){
				name = "Small Power";
				description = "This tower will provide: "+ GetSmallGenPower() +" power";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "LargeGeneator"){
				name = "Large Power";
				description = "This tower will provide: "+ GetBigGenPower() + " power";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0 + "";
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Targeting"){
				name = "Targeting Facility";
				description = "This tower will increase 2 attack number for nearby towers\n\n"+"Need 2 power to function";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0 + "";
				SetAttackRangeShow(building);
				//show the attack range using sprite
				SetSpriteRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "SuperCapacitor"){
				name = "Super Capacitor";
				description = "This tower will increase the attack rate for nearby towers\n\n"+"Need 2 power to function";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0+"";
				SetAttackRangeShow(building);
				//show the attack range using sprite
				SetSpriteRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "AlienRecovery"){
				name = "Alien Recovery";
				description = "This tower will collect diamond when killing enemies in the range";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				attackNumber = 0+"";
				levelNumber = 0+"";
				SetAttackRangeShow(building);
				//show the attack range using sprite
				SetSpriteRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			} else if(hit.transform.tag == "Antenna"){
				name = "Antenna";
				building = cManager.GetBuildingById(int.Parse(hit.collider.transform.name));
				description = "This tower supply power to nearby towers\n"+"Current Power: "+((Antenna)building).GetCurrentPower()+"/"+((Antenna)building).GetMaxPower();
				attackNumber = 0+"";
				levelNumber = 0+"";
				SetAttackRangeShow(building);
				//show the attack range using sprite
				SetSpriteRangeShow(building);
				SetPanel(name,description,attackNumber,levelNumber);
			}


			else {
				SetAttackRangeHide();
				SetSpriteRangeHide();
			}
		}
	}
	

	public UILabel costLabel;
	public UILabel attackLabel;

	private void SetPanel(string nameText, string desText, string attackNumText, string levelNumText){
		if (building.GetLevel() <= 2) {
			//set upgrade label visible
			costLabel.gameObject.SetActive(true);
			attackLabel.gameObject.SetActive(true);
			//set the upgrade button visible
			upgrade.normalSprite = "btn_red1";
			upgrade.enabled = true;
		}else if (building.GetLevel() == 3) {
			//set upgrade label invisible
			costLabel.gameObject.SetActive(false);
			attackLabel.gameObject.SetActive(false);
			//set the upgrade button not able
			upgrade.normalSprite = "btn_red4";
			upgrade.enabled = false;
		}

		if (building.buildingType == CharacterData.buildingMode.TOWER1) {
			upgradeDiamondCost = 20;
			upgradeDiamondNum.text = "cost:"+upgradeDiamondCost;
		} else if(building.buildingType == CharacterData.buildingMode.TOWER2){
			upgradeDiamondCost = 30;
			upgradeDiamondNum.text = "cost:"+upgradeDiamondCost;
		} else if(building.buildingType == CharacterData.buildingMode.TOWER7){
			upgradeDiamondCost = 50;
			upgradeDiamondNum.text = "cost:"+upgradeDiamondCost;
		} else if(building.buildingType == CharacterData.buildingMode.TOWER10){
			upgradeDiamondCost = 100;
			upgradeDiamondNum.text = "cost:"+upgradeDiamondCost;
		}

		if(building.buildingType == CharacterData.buildingMode.TOWER4 || building.buildingType == CharacterData.buildingMode.LAB
		   || building.buildingType == CharacterData.buildingMode.MINE1 || building.buildingType == CharacterData.buildingMode.MINE2
		   || building.buildingType == CharacterData.buildingMode.GENERATOR1 || building.buildingType == CharacterData.buildingMode.GENERATOR2
		   || building.buildingType == CharacterData.buildingMode.TARGETING || building.buildingType == CharacterData.buildingMode.CAPACITOR
		   || building.buildingType == CharacterData.buildingMode.ALIEN || building.buildingType == CharacterData.buildingMode.ANTENNA){
			//set upgrade label invisible
			costLabel.gameObject.SetActive(false);
			attackLabel.gameObject.SetActive(false);
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

	public void SetPanel(string desText){
		UILabel description = towerInfo.transform.Find ("Panel/DesLabel").GetComponent<UILabel> ();
		description.text = desText;
	}
	

	private static int tower1UpgradeAttackNumber = 1;
	private static int tower2UpgradeAttackNumber = 1;
	private static int tower7UpgradeAttackNumber = 1;
	private static int tower10UpgradeAttackNumber = 1;
	private static int upgradeDiamondCost = 20;

	public void SetTower1UpgradeNumber(int number){	tower1UpgradeAttackNumber = number;}
	public int GetTower1UpgradeNumber() { return tower1UpgradeAttackNumber; }

	public void SetTower2UpgradeNumber(int number){ tower2UpgradeAttackNumber = number; }
	public int GetTower2UpgradeNumber() { return tower2UpgradeAttackNumber; }

	public void SetTower7UpgradeNumber(int number){ tower7UpgradeAttackNumber = number; }
	public int GetTower7UpgradeNumber() { return tower7UpgradeAttackNumber; }

	public void SetTower10UpgradeNumber(int number){ tower10UpgradeAttackNumber = number; }
	public int GetTower10UpgradeNumber() { return tower10UpgradeAttackNumber; }

	public void UpGradeBtnClick(){
		//use 20 diamond to upgrade
		if (building.buildingType == CharacterData.buildingMode.TOWER1) {
			upgradeDiamondCost = 20;
			upgradeDiamondNum.text = "cost:"+upgradeDiamondCost;
		} else if(building.buildingType == CharacterData.buildingMode.TOWER2){
			upgradeDiamondCost = 30;
			upgradeDiamondNum.text = "cost:"+upgradeDiamondCost;
		} else if(building.buildingType == CharacterData.buildingMode.TOWER7){
			upgradeDiamondCost = 50;
			upgradeDiamondNum.text = "cost:"+upgradeDiamondCost;
		} else if(building.buildingType == CharacterData.buildingMode.TOWER10){
			upgradeDiamondCost = 100;
			upgradeDiamondNum.text = "cost:"+upgradeDiamondCost;
		}
		if(DiamondManager._instance.GetCurrentDiamond() >= upgradeDiamondCost){
		if (building.GetLevel() <= 1) {
			upgrade.normalSprite = "btn_red1";
			upgrade.enabled = true;
		}else if (building.GetLevel() > 1) {
				costLabel.gameObject.SetActive(false);
				attackLabel.gameObject.SetActive(false);
			upgrade.normalSprite = "btn_red4";
			upgrade.enabled = false;
		}
		level = building.GetLevel ();
		//increase the attack power
		attackNum = building.GetAttackPower ();
		building.SetAttackPower (attackNum + tower10UpgradeAttackNumber);
			DiamondManager._instance.UseDiamond(upgradeDiamondCost);
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
		SetSpriteRangeHide ();
		for (int i = allAttakBuilding.Count - 1; i >= 0; i--) {
			if(allAttakBuilding[i].ID == id){
				allAttakBuilding[i].Destroy();
				allAttakBuilding.RemoveAt(i);
			}
		}
		for (int i = needPowerTowers.Count - 1; i >= 0; i--) {
			if(needPowerTowers[i].ID == id){
				//check if the tower has been powered before
				//if yes, return the power
				if(needPowerTowers[i].GetPowerProvider() != null){
					//return power to the generator
					AddPower(needPowerTowers[i].GetNeedPower());
					//delete the tower from the antenna power list
					needPowerTowers[i].GetPowerProvider().RemoveFromProvidePowerTowerList(needPowerTowers[i]);
					//return power to the antenna
					needPowerTowers[i].GetPowerProvider().AddPower(needPowerTowers[i].GetNeedPower());
					//set the parent null
					needPowerTowers[i].SetPowerProvider(null);
				}
				//if no, do nothing
				needPowerTowers[i].Destroy();
				needPowerTowers.RemoveAt(i);
			}
		}
		for (int i = antennaList.Count - 1; i >= 0; i--) {
			if(antennaList[i].ID == id){
				//remove all the tower in the already powered list
				foreach(Character building in ((Antenna)antennaList[i]).GetProvidePowerTowerList()){
					//remove the tower provider
					building.SetPowerProvider(null);
					//return power
					AddPower(building.GetNeedPower());
				}
				antennaList[i].Destroy();
				antennaList.RemoveAt(i);
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
				powerNum -= smallGenPower;
				if(powerNum < 0){
					AntennaAndPower._instance.ReturnPowerWhenGeneratorDestoryed(smallGenPower);
				}
				smallGenNum = gManager.smallGenList.Count;
				break;
			}
		}
		for (int i = gManager.largeGenList.Count - 1; i >= 0; i--) {
			if(gManager.largeGenList[i].ID == id){
				gManager.largeGenList[i].Destroy();
				gManager.largeGenList.RemoveAt(i);
				powerNum -= bigGenPower;
				if(powerNum < 0){
					AntennaAndPower._instance.ReturnPowerWhenGeneratorDestoryed(bigGenPower);
				}
				largeGenNum = gManager.largeGenList.Count;
				break;
			}
		}
		for (int i = gManager.antennaList.Count - 1; i >= 0; i--) {
			if(gManager.antennaList[i].ID == id){
				for(int j = AntennaAndPower._instance.hasPoweredAntenna.Count - 1 ; j >= 0 ; j--){
					if(id == AntennaAndPower._instance.hasPoweredAntenna[j].ID){
						powerNum += gManager.antennaList[j].GetMaxPower();
						AntennaAndPower._instance.hasPoweredAntenna[j].Destroy();
						AntennaAndPower._instance.hasPoweredAntenna.RemoveAt(j);
					}
				}
				gManager.antennaList[i].Destroy();
				gManager.antennaList.RemoveAt(i);
				break;
			}
		}
		//delete the targeting tower, need to reset the attack number has been increased to normal
		for (int i = gManager.targetingFacList.Count - 1; i >= 0; i--) {
			if(gManager.targetingFacList[i].ID == id){
				//decrease all the tower attack power
				foreach(Character chara in gManager.targetingFacList[i].hasIncreasedList){
					chara.SetAttackPower(chara.GetAttackPower()-2);
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
				if(tower == "tower1" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[0]){
					Tower1 tower1 = (Tower1)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER1, 1,
				                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower1.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[0]);
					allAttakBuilding.Add(tower1);
					//need power1
					needPowerTowers.Add(tower1);
					gManager.tower1List.Add(tower1);
				} else if(tower == "tower2" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[1]){
					Tower2 tower2 = (Tower2)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER2, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower2.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[1]);
					allAttakBuilding.Add(tower2);
					//need power1
					needPowerTowers.Add(tower2);
					gManager.tower2List.Add(tower2);
				} else if(tower == "tower4" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[2]){
					Tower4 tower4 = (Tower4)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER4, 1,
					                                                   1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower4.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[2]);
					//need power1
					needPowerTowers.Add(tower4);
					allAttakBuilding.Add(tower4);
					gManager.tower4List.Add(tower4);   
				} else if(tower == "tower7" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[3]){
					Tower7 tower7 = (Tower7)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER7, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower7.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[3]);
					//need power1
					needPowerTowers.Add(tower7);
					allAttakBuilding.Add(tower7);
					gManager.tower7List.Add(tower7);   
				} else if(tower == "tower10" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[4]){
					Tower10 tower10 = (Tower10)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TOWER10, 1,
					                                                   1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tower10.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[4]);
					//need power2
					needPowerTowers.Add(tower10);
					allAttakBuilding.Add(tower10);
					gManager.tower10List.Add(tower10);
				} else if(tower == "research" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[5]){
					Research research = (Research)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.LAB, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					research.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[5]);
					gManager.researchList.Add(research);
					researchTowerNum = gManager.researchList.Count;
				} else if(tower == "smallmine" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[6]){
					foreach(DiamondResource dr in gManager.diamondList){
						if(Vector3.Distance(dr.GetPos() ,obstacle3Pos) <= 0.8f){
							SmallMine sm = (SmallMine)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.MINE1, 1,
							                                                  1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
							sm.SetPosition (obstacle3Pos);
							//cost diamond
							DiamondManager._instance.UseDiamond(towerCostList[6]);
							sm.nearestDiamond = dr;
							gManager.smallMineList.Add(sm);
							smallMineNum = gManager.smallMineList.Count;
						}
					}
				}
				else if(tower == "largemine" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[7]){
					foreach(DiamondResource dr in gManager.diamondList){
						if(Vector3.Distance(dr.GetPos() ,obstacle3Pos) <= 0.8f){
							LargeMine lm = (LargeMine)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.MINE2, 1,
							                                                  1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
							lm.SetPosition (obstacle3Pos);
							//cost diamond
							DiamondManager._instance.UseDiamond(towerCostList[7]);
							lm.nearestDiamond = dr;
							gManager.largeMineList.Add(lm);
							largeMineNum = gManager.largeMineList.Count;
						}
					}
				}
				else if(tower == "smallgeneator" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[8]){
					SmallGeneator sg = (SmallGeneator)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.GENERATOR1, 1,
							                                                  1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					sg.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[8]);
					gManager.smallGenList.Add(sg);
					powerNum += smallGenPower;
					smallGenNum = gManager.smallGenList.Count;
				}
				else if(tower == "largegeneator" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[9]){
					LargeGeneator lg = (LargeGeneator)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.GENERATOR2, 1,
					                                                          1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					lg.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[9]);
					gManager.largeGenList.Add(lg);
					powerNum += bigGenPower;
					largeGenNum = gManager.largeGenList.Count;
				}
				else if(tower == "targetingfacility" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[10]){
					TargetingFacility tf = (TargetingFacility)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.TARGETING, 1,
					                                                1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					tf.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[10]);
					//need power1
					needPowerTowers.Add(tf);
					gManager.targetingFacList.Add(tf);   
				}
				else if(tower == "supercapacitor" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[11]){
					SuperCapacitor sc = (SuperCapacitor)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.CAPACITOR, 1,
					                                                                  1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					sc.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[11]);
					//need power1
					needPowerTowers.Add(sc);
					gManager.superCapList.Add(sc);   
				}
				else if(tower == "alienrecovery" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[12]){
					AlienRecovery ar = (AlienRecovery)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.ALIEN, 1,
					                                                            1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					ar.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[12]);
					gManager.alienRecList.Add(ar);   
				}
				else if(tower == "antenna" && DiamondManager._instance.GetCurrentDiamond() >= towerCostList[13]){
					Antenna ant = (Antenna)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.ANTENNA, 1,
					                                                          1, obstacle3Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
					ant.SetPosition (obstacle3Pos);
					//cost diamond
					DiamondManager._instance.UseDiamond(towerCostList[13]);
					gManager.antennaList.Add(ant); 
					antennaList.Add(ant);
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

	public void OnAtennaClicked(){
		antenna = true;
	}
}
