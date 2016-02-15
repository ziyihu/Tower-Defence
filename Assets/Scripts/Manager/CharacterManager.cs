using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour,IMessageObject {

	List<Character> chars = new List<Character>();
	public List<Character> building = new List<Character>();
	List<Character> allCharacter = new List<Character> ();
	List<Vector3> position = new List<Vector3>();
	private static int tower1AttackNumber = 1;
	private static int tower2AttackNumber = 1;
	private static int tower7AttackNumber = 1;
	private static int tower10AttackNumber = 1;

	public void SetTower1AttackNumber(int number) { tower1AttackNumber = number; }
	public int GetTower1AttackNumber(){ return tower1AttackNumber; }

	public void SetTower2AttackNumber(int number) { tower2AttackNumber = number; }
	public int GetTower2AttackNumber(){ return tower2AttackNumber; }

	public void SetTower7AttackNumber(int number) { tower7AttackNumber = number; }
	public int GetTower7AttackNumber(){ return tower7AttackNumber; }

	public void SetTower10AttackNumber(int number) { tower10AttackNumber = number; }
	public int GetTower10AttackNumber(){ return tower10AttackNumber; }
	
	Character chara = new Character();

	private void SetEnemy(Character chara,Vector3 pos,Vector3 dir,int camp,CharacterStatus.Pose pose,float speed,int life){
		chara.SetPos(pos);
		chara.SetDir(dir);
		chara.SetPose(pose);
		chara.SetCamp(camp);
		chara.SetSpeed(speed);
		//set bowman max life
		chara.SetLife(life);
	}

	public Character SpawnCharacter(CharacterData.CharacterClassType classType, int charModeType, int camp, int level, Vector3 pos, Vector3 dir, CharacterStatus.Pose pose){
		this.START_METHOD("SpawnCharacter");
		Character tempChar = null;
		//create the enemies
		if (classType == CharacterData.CharacterClassType.CHARACTER) {
			//create the enemy
			if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.BOWMAN){
				Bowman chara = new Bowman();
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.GIANT){
				Gaint chara = new Gaint("giant");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,20);
				tempChar = chara;
			} else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.VIKING){
				Viking chara = new Viking();
				SetEnemy(chara,pos,dir,camp,pose,0.02f,30);
				tempChar = chara;
			}
			//create enemy2
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY2){
				Gaint chara = new Gaint("enemy2");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			//enemy3
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY3){
				Gaint chara = new Gaint("enemy3");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			//enemy4
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY4){
				Gaint chara = new Gaint("enemy4");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY5){
				Gaint chara = new Gaint("enemy5");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY6){
				Gaint chara = new Gaint("enemy6");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY7){
				Gaint chara = new Gaint("enemy7");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY8){
				Gaint chara = new Gaint("enemy8");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY9){
				Gaint chara = new Gaint("enemy9");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY10){
				Gaint chara = new Gaint("enemy10");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY11){
				Gaint chara = new Gaint("enemy11");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY12){
				Gaint chara = new Gaint("enemy12");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY13){
				Gaint chara = new Gaint("enemy13");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY14){
				Gaint chara = new Gaint("enemy14");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY15){
				Gaint chara = new Gaint("enemy15");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY16){
				Gaint chara = new Gaint("enemy16");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY17){
				Gaint chara = new Gaint("enemy17");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY18){
				Gaint chara = new Gaint("enemy18");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY19){
				Gaint chara = new Gaint("enemy19");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY20){
				Gaint chara = new Gaint("enemy20");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY21){
				Gaint chara = new Gaint("enemy21");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY22){
				Gaint chara = new Gaint("enemy22");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY23){
				Gaint chara = new Gaint("enemy23");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY24){
				Gaint chara = new Gaint("enemy24");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY25){
				Gaint chara = new Gaint("enemy25");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY26){
				Gaint chara = new Gaint("enemy26");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY27){
				Gaint chara = new Gaint("enemy27");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY28){
				Gaint chara = new Gaint("enemy28");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY29){
				Gaint chara = new Gaint("enemy29");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY30){
				Gaint chara = new Gaint("enemy30");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY31){
				Gaint chara = new Gaint("enemy31");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY32){
				Gaint chara = new Gaint("enemy32");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY33){
				Gaint chara = new Gaint("enemy33");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY34){
				Gaint chara = new Gaint("enemy34");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY35){
				Gaint chara = new Gaint("enemy35");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY36){
				Gaint chara = new Gaint("enemy36");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY37){
				Gaint chara = new Gaint("enemy37");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY38){
				Gaint chara = new Gaint("enemy38");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY39){
				Gaint chara = new Gaint("enemy39");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY40){
				Gaint chara = new Gaint("enemy40");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY41){
				Gaint chara = new Gaint("enemy41");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY42){
				Gaint chara = new Gaint("enemy42");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY43){
				Gaint chara = new Gaint("enemy43");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY44){
				Gaint chara = new Gaint("enemy44");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY45){
				Gaint chara = new Gaint("enemy45");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.ENEMY46){
				Gaint chara = new Gaint("enemy46");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.BOSS1){
				Gaint chara = new Gaint("boss1");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			else if((CharacterData.CharacterModel)charModeType == CharacterData.CharacterModel.BOSS2){
				Gaint chara = new Gaint("boss2");
				SetEnemy(chara,pos,dir,camp,pose,0.02f,10);
				tempChar = chara;
			} 
			if(tempChar != null){
				chars.Add(tempChar);
			} else {
				throw new UnityException("no current char type to spawn!");
			}
		}
		//create the building
		else if (classType == CharacterData.CharacterClassType.BUILDING) {
			//create the barrack to gather resources
			if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.BARRACK){
				TowerBarrack character = new TowerBarrack();
				character.SetPos(pos);
				character.SetDir(dir);
				character.SetCamp(camp);
				tempChar = character;
			} else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.CANNON){
				Cannon character = new Cannon();
				character.SetPos(pos);
				character.SetDir(dir);
				character.SetPose (pose);
				character.SetCamp(camp);
				//set attack power
				character.SetAttackPower(50);
				tempChar = character;
			}
			//Tower01
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.TOWER1){
				Tower1 character = new Tower1();
				character.SetAttackRange(3);
				character.SetLevel(1);
				character.SetPos(pos);
				character.SetDir(dir);
				character.SetPose (pose);
				character.SetCamp(camp);
				character.SetAttackRate(2f);
				//set attack power
				character.SetAttackPower(tower1AttackNumber);
				tempChar = character;
			}
			//Tower02
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.TOWER2){
				Tower2 character = new Tower2();
				character.SetAttackRange(3);
				character.SetLevel(1);
				character.SetPos(pos);
				character.SetDir(dir);
				character.SetPose (pose);
				character.SetCamp(camp);
				character.SetAttackRate(1f);
				//set attack power
				character.SetAttackPower(tower2AttackNumber);
				tempChar = character;
			}
			//Tower4
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.TOWER4){
				Tower4 character = new Tower4();
				character.SetAttackRange(2);
				character.SetLevel(1);
				character.SetPos(pos);
				character.SetDir(dir);
				character.SetPose(pose);
				character.SetCamp(camp);
				tempChar = character;
			}
			//Tower7
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.TOWER7){
				Tower7 character = new Tower7();
				character.SetAttackRange(2);
				character.SetLevel(1);
				character.SetPos(pos);
				character.SetDir(dir);
				character.SetPose(pose);
				character.SetCamp(camp);
				character.SetAttackPower(tower7AttackNumber);
				character.SetAttackRate(1f);
				tempChar = character;
			}
			//Tower10
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.TOWER10){
				Tower10 character = new Tower10();
				character.SetAttackRange(4);
				character.SetLevel(1);
				character.SetPos(pos);
				character.SetDir(dir);
				character.SetPose(pose);
				character.SetCamp(camp);
				character.SetAttackPower(tower10AttackNumber);
				character.SetAttackRate(1f);
				tempChar = character;
			}
			//Research
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.LAB){
				Research character = new Research();
				character.SetLevel(1);
				character.SetPos(pos);
				character.SetPose(pose);
				character.SetCamp(camp);
				tempChar = character;
			}
			//Diamond Resource
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.DIAMOND){
				DiamondResource character = new DiamondResource();
				character.SetPos(pos);
				character.SetPose(pose);
				character.SetCamp(camp);
				tempChar = character;
			}
			//Small Mine
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.MINE1){
				SmallMine character = new SmallMine();
				character.SetPos(pos);
				character.SetPose(pose);
				character.SetCamp(camp);
				tempChar = character;
			}
			//Large Mine
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.MINE2){
				LargeMine character = new LargeMine();
				character.SetPos(pos);
				character.SetPose(pose);
				character.SetCamp(camp);
				tempChar = character;
			}
			//Small Geneator
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.GENERATOR1){
				SmallGeneator character = new SmallGeneator();
				character.SetPos(pos);
				character.SetPose(pose);
				character.SetCamp(camp);
				tempChar = character;
			}
			//Large Geneator
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.GENERATOR2){
				LargeGeneator character = new LargeGeneator();
				character.SetPos(pos);
				character.SetPose(pose);
				character.SetCamp(camp);
				tempChar = character;
			}
			//Targeting Facility
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.TARGETING){
				TargetingFacility character = new TargetingFacility();
				character.SetPos(pos);
				character.SetPose(pose);
				character.SetCamp(camp);
				character.SetAttackRange(2);
				tempChar = character;
			}
			//Super Capacitor
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.CAPACITOR){
				SuperCapacitor character = new SuperCapacitor();
				character.SetPos(pos);
				character.SetPose(pose);
				character.SetCamp(camp);
				character.SetAttackRange(2);
				tempChar = character;
			}
			//Alien Recovery
			else if((CharacterData.buildingMode)charModeType == CharacterData.buildingMode.ALIEN){
				AlienRecovery character = new AlienRecovery();
				character.SetPos(pos);
				character.SetPose(pose);
				character.SetCamp(camp);
				character.SetAttackRange(2);
				tempChar = character;
			}
			//created the tower, add to the building list
			if(tempChar != null){
				building.Add(tempChar);
			} else { 
				throw new UnityException("no current building type to spawn!");
			}
		}
		//add to the all character list
		allCharacter.Add (tempChar);
		this.END_METHOD("SpawnCharacter");
		return tempChar;
	}
	

	//delete all the character
	public void DestoryAll(){
		this.START_METHOD("DestoryAll");
		allCharacter.Clear ();
		for (int i = chars.Count - 1; i >= 0; i--) {
			chars[i].Destroy();
			chars.RemoveAt(i);
		}
		for (int i = building.Count - 1; i >= 0; i--) {
			building[i].Destroy();
			building.RemoveAt(i);
		}
		Resources.UnloadUnusedAssets ();
		System.GC.Collect ();
		this.END_METHOD("DestoryAll");
	}

	//delete one character
	//using ID to find the character need to be destoryed
	public void DestoryChar(long id){
		this.START_METHOD("DestoryChar");
		for (int i = chars.Count - 1; i >= 0; i--) {
			if(chars[i].ID == id){
				chars[i].Destroy();
				chars.RemoveAt(i);
				break;
			}
		}
		for (int i = allCharacter.Count - 1; i >= 0; i--) {
			if(allCharacter[i].ID == id){
				allCharacter[i].Destroy();
				allCharacter.RemoveAt(i);
				break;
			}
		}
		this.END_METHOD("DestoryChar");
	}

	IEnumerator WaitAni(){
		yield return new WaitForSeconds (2);
	}

	//delete one building
	//using ID to find the building need to be destoryed
	public void DestoryBuilding(long id){
		this.START_METHOD("DestoryBuilding");
		for (int i = building.Count - 1; i >= 0; i--) {
			if(building[i].ID == id){
				building[i].Destroy();
				building.RemoveAt(i);
				break;
			}
		}
		for (int i = allCharacter.Count - 1; i >= 0; i--) {
			if(allCharacter[i].ID == id){
				allCharacter[i].Destroy();
				allCharacter.RemoveAt(i);
				break;
			}
		}
		this.END_METHOD("DestoryBuilding");
	}


	//get the building info
	public Building GetBuildingById(long id){
		for (int i = 0; i < building.Count; i++) {
			if(building[i].ID == id){
				return building[i] as Building;
			}
		}
		return null;
	}

	//get the closest enemy
	public Character FindEnemyByDistance(Building building){

		float shorestDis = 3f;
		//get all the ememy in the list
		for (int i = 0; i < EnemySpawnManager._instance.enemyList.Count; i++) {
			Vector3 dir = building.GetTransform().position - EnemySpawnManager._instance.enemyList[i].GetPos();
			dir.y = 0;
			float targetDist = dir.magnitude;
			//if the target is in the attack range
			if(targetDist <= building.GetAttackRange()){
				//must be the closetest target
				if(targetDist < shorestDis){
					shorestDis = targetDist;
					chara = EnemySpawnManager._instance.enemyList[i];
				}
			}
		}
		if (EnemySpawnManager._instance.enemyList.Count == 0) {
			return null;
		}
		return chara;
	}
	
}
