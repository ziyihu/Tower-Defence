using UnityEngine;
using System.Collections;

public struct CharacterData{
	public enum CharacterClassType{
		CHARACTER = 1,
		BUILDING,
	}
	public enum CharacterModel{
		NONE = -1,
		SOLDIER,
		BOWMAN,
		GIANT,
		VIKING,
		ENEMY2,
		ENEMY3,
		ENEMY4,
		ENEMY5,
		ENEMY6,
		ENEMY7,
		ENEMY8,
		ENEMY9,
		ENEMY10,
		ENEMY11,
		ENEMY12,
		ENEMY13,
		ENEMY14,
		ENEMY15,
		ENEMY16,
		ENEMY17,
		ENEMY18,
		ENEMY19,
		ENEMY20,
		ENEMY21,
		ENEMY22,
		ENEMY23,
		ENEMY24,
		ENEMY25,
		ENEMY26,
		ENEMY27,
		ENEMY28,
		ENEMY29,
		ENEMY30,
		ENEMY31,
		ENEMY32,
		ENEMY33,
		ENEMY34,
		ENEMY35,
		ENEMY36,
		ENEMY37,
		ENEMY38,
		ENEMY39,
		ENEMY40,
		ENEMY41,
		ENEMY42,
		ENEMY43,
		ENEMY44,
		ENEMY45,
		ENEMY46,
		BOSS1,
		BOSS2
	}
	public enum buildingMode{
		BARRACK = 1,
		DIAMOND,
		CANNON,
		TOWER1,
		TOWER2,
		TOWER3,
		TOWER4,
		TOWER5,
		TOWER6,
		TOWER7,
		TOWER8,
		TOWER9,
		TOWER10,
		MINE1,
		MINE2,
		GENERATOR1,
		GENERATOR2,
		ANTENNA,
		LAB,
		CAPACITOR,
		TARGETING,
		ALIEN
	}
	public void Reset(){
		isDirty = true;
	}

	public bool isDirty;

	//all the info for the enemy
	public long modelID;
	public int classType;
	public int modeltype;
	public int level;
	public Vector3 pos;
	public float speed;
	public int camp;
	public Vector3 rotation;
	public CharacterStatus.Pose pose;
	public float life;
	public float maxLife;
	public int attackPower;
	public float attackRange;
	public float searchInterval;
	public float attackInterval;
	public float attackRate;
	public int currentUseSkillId;

}
