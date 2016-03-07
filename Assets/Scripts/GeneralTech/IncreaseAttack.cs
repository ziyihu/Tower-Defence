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
			cManager.SetTower1AttackNumber(cManager.GetTower1AttackNumber() + 1);
			cManager.SetTower2AttackNumber(cManager.GetTower2AttackNumber() + 1);
			cManager.SetTower7AttackNumber(cManager.GetTower7AttackNumber() + 1);
			cManager.SetTower10AttackNumber(cManager.GetTower10AttackNumber() + 1);
			TowerBuildManager._instance.SetTower10UpgradeNumber(TowerBuildManager._instance.GetTower10UpgradeNumber() + 1);
			foreach(Character chara in TowerBuildManager._instance.getAllAttackBuilding()){
				chara.SetAttackPower(chara.GetLevel()*1+chara.GetAttackPower());
			}
			isIncreased = false;
			hasIncreased = true;
		}
	}
}
