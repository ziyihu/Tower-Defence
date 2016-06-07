using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : UnityAllSceneSingleton<GameManager>,IMessageObject {
	//the different game status
	public enum Status{
		NONE = 1,
		LOAD_RESOURCE,
		LOAD_SCENE,
		PREPARE_SCAN,
		START_GAME,
		END_GAME,
		WIN_GAME
	}
	public List<Cannon> can = new List<Cannon> ();
	public List<Tower1> tower1List = new List<Tower1> ();
	public List<Tower2> tower2List = new List<Tower2> ();
	public List<Tower4> tower4List = new List<Tower4> ();
	public List<Tower7> tower7List = new List<Tower7> ();
	public List<Tower10> tower10List = new List<Tower10>();
	public List<Research> researchList = new List<Research> ();
	public List<DiamondResource> diamondList = new List<DiamondResource> ();
	public List<SmallMine> smallMineList = new List<SmallMine> ();
	public List<LargeMine> largeMineList = new List<LargeMine> ();
	public List<SmallGeneator> smallGenList = new List<SmallGeneator> ();
	public List<LargeGeneator> largeGenList = new List<LargeGeneator> ();
	public List<TargetingFacility> targetingFacList = new List<TargetingFacility> ();
	public List<SuperCapacitor> superCapList = new List<SuperCapacitor> ();
	public List<AlienRecovery> alienRecList = new List<AlienRecovery> ();
	public List<Antenna> antennaList = new List<Antenna> ();
	public CharacterManager cManager;
	public Status CurStatus = Status.NONE;

	public override void Awake(){
		base.Awake ();
		cManager = new CharacterManager ();
	}

	void Start(){

	}

//	public void ReloadScene(int scene){
//		this.START_METHOD ("ReloadScene");
//		//create the towers in the scene
//		//tower1
//		Vector3 obstaclePos = new Vector3 (17f, 1.0f, 19.3f);
//		DiamondResource diamond = (DiamondResource)cManager.SpawnCharacter (CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.DIAMOND, 1,
//		                                                              1, obstaclePos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
//		diamond.SetPosition (obstaclePos);
//		diamondList.Add (diamond);
//
//		//tower2
//		Vector3 obstacle1Pos = new Vector3 (18f, 1.0f, 19.3f);
//		diamond = (DiamondResource)cManager.SpawnCharacter (CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.DIAMOND, 1,
//		                                                 1, obstacle1Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
//		diamond.SetPosition (obstacle1Pos);
//		diamondList.Add (diamond);
//
//		//tower3
//		Vector3 obstacle2Pos = new Vector3 (15f, 1.0f, 17.3f);
//		diamond = (DiamondResource)cManager.SpawnCharacter(CharacterData.CharacterClassType.BUILDING, (int)CharacterData.buildingMode.DIAMOND, 1,
//		                                                1, obstacle2Pos, new Vector3 (0, 0, 0), CharacterStatus.Pose.Idle);
//		diamond.SetPosition (obstacle2Pos);
//		diamondList.Add (diamond);
//
//
//		//enemy
//		this.END_METHOD ("ReloadScene");
//	}
	//get the closest enemy
	public Character FindEnemyByDistance(Building building){
		return cManager.FindEnemyByDistance (building);
	}

	//Create an enemy perfab
	public Character SpawnCharacter(CharacterData.CharacterClassType type, CharacterData.CharacterModel model, int camp, int level, Vector3 startPos, Vector3 startDir, CharacterStatus.Pose pose){
		return cManager.SpawnCharacter (type, (int)model, camp, level, startPos, startDir, pose);
	}

	//destory an enemy
	public void DeleteById(long id){
		cManager.DestoryChar (id);
	}

	void Update(){
		if (can.Count > 0) {
			foreach (Cannon c in can) {
				c.CheckEnemy ();
				c.HitEnemy ();
			}
		}
		switch (CurStatus) {
		case Status.LOAD_RESOURCE:
			break;
		case Status.LOAD_SCENE:
			//ReloadScene(1);
			CurStatus = Status.PREPARE_SCAN;
			break;
		case Status.PREPARE_SCAN:
			//A* scan algorithm
			CurStatus = Status.START_GAME;
			break;
		case Status.START_GAME:
			break;
		case Status.END_GAME:
			break;
		}
	}
}
