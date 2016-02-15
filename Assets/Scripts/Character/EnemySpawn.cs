using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public string Type = null;

	public Character EnemyBorn(string enemyName){
		GameObject startPoint = GameObject.Find ("StartPoint");
		if (enemyName == "bowman") {
			return GameManager.Instance.SpawnCharacter (CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.BOWMAN, 0, 1, startPoint.transform.position,
			                                            startPoint.transform.eulerAngles, CharacterStatus.Pose.Run);
		} else if(enemyName == "gaint") {
			return GameManager.Instance.SpawnCharacter (CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.GIANT, 0, 1, startPoint.transform.position,
			                                            startPoint.transform.eulerAngles, CharacterStatus.Pose.Run);
		}else if(enemyName == "viking") {
			return GameManager.Instance.SpawnCharacter (CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.VIKING, 0, 1, startPoint.transform.position,
			                                            startPoint.transform.eulerAngles, CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy2"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY2,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy3"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY3,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy4"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY4,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy5"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY5,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy6"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY6,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy7"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY7,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy8"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY8,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy9"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY9,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy10"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY10,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy11"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY11,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy12"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY12,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy13"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY13,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy14"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY14,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy15"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY15,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy16"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY16,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy17"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY17,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy18"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY18,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy19"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY19,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy20"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY20,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy21"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY21,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy22"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY22,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy23"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY23,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy24"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY24,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy25"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY25,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy26"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY26,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy27"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY27,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy28"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY28,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy29"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY29,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy30"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY30,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy31"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY31,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy32"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY32,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy33"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY33,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy34"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY34,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy35"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY35,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy36"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY36,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy37"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY37,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy38"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY38,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy39"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY39,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy40"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY40,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy41"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY41,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy42"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY42,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy43"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY43,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy44"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY44,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy45"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY45,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "enemy46"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.ENEMY46,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "boss1"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.BOSS1,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}else if(enemyName == "boss2"){
			return GameManager.Instance.SpawnCharacter(CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.BOSS2,0,1,startPoint.transform.position,
			                                           startPoint.transform.eulerAngles,CharacterStatus.Pose.Run);
		}
		return null;
	}

	public Character Born(){
			GameObject startPoint = GameObject.Find ("StartPoint");
		if (Type == "bowman") {
			return GameManager.Instance.SpawnCharacter (CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.BOWMAN, 0, 1, startPoint.transform.position,
		                                    startPoint.transform.eulerAngles, CharacterStatus.Pose.Run);
		} else if(Type == "gaint") {
			return GameManager.Instance.SpawnCharacter (CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.GIANT, 0, 1, startPoint.transform.position,
			                                     startPoint.transform.eulerAngles, CharacterStatus.Pose.Run);
		}else if(Type == "viking") {
			return GameManager.Instance.SpawnCharacter (CharacterData.CharacterClassType.CHARACTER, CharacterData.CharacterModel.VIKING, 0, 1, startPoint.transform.position,
			                                     startPoint.transform.eulerAngles, CharacterStatus.Pose.Run);
		}
		return null;
	}
}
