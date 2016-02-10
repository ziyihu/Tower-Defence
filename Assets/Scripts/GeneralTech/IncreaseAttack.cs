using UnityEngine;
using System.Collections;

public class IncreaseAttack : MonoBehaviour {

	private bool isIncreased = false;
	CharacterManager cManager;
	private TechNode node;
	private bool hasIncreased = false;
	// Use this for initialization
	void Start () {
		cManager = new CharacterManager ();
		node = new TechNode ();
	}
	// Update is called once per frame
	void Update () {
		if (node.GetIncreasedPower && hasIncreased == false) {
			isIncreased = true;
		}
		if (isIncreased) {
			cManager.SetTower1AttackNumber(cManager.GetTower1AttackNumber() + 10);
			cManager.SetTower2AttackNumber(cManager.GetTower2AttackNumber() + 10);
			cManager.SetTower7AttackNumber(cManager.GetTower7AttackNumber() + 10);
			cManager.SetTower10AttackNumber(cManager.GetTower10AttackNumber() + 10);
			TowerBuildManager._instance.SetTower10UpgradeNumber(TowerBuildManager._instance.GetTower10UpgradeNumber() + 10);
			foreach(Character chara in TowerBuildManager._instance.getAllAttackBuilding()){
				chara.SetAttackPower(chara.GetLevel()*10+chara.GetAttackPower());
			}
			isIncreased = false;
			hasIncreased = true;
		}
	}
}
