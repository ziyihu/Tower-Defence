using UnityEngine;
using System.Collections;

public class AntennaPower : MonoBehaviour {

	//reset the antenna power to 7
	//set the powered antenna return all the power
	//reset the power

	private bool isIncreased = false;
	private bool hasIncreased = false;
	private TechNode node;
	CharacterManager cManage;

	private int increasedAntennaPower = 7;

	// Use this for initialization
	void Start () {
		node = new TechNode ();
		cManage = new CharacterManager ();
	}
	
	// Update is called once per frame
	void Update () {
		if (node.GetAntennaPower && hasIncreased == false) {
			isIncreased = true;
		}
		if (isIncreased) {
			//set the powered antenna return power
			while( AntennaAndPower._instance.hasPoweredAntenna.Count != 0){
				TowerBuildManager._instance.GetAntennaList().Add(AntennaAndPower._instance.hasPoweredAntenna[0]);
				((Antenna)AntennaAndPower._instance.hasPoweredAntenna[0]).SetAniNotActive();
				//hasPoweredAntenna[0].Destroy();
				TowerBuildManager._instance.AddPower(AntennaAndPower._instance.GetAntennaNeedPower());
				((Antenna)AntennaAndPower._instance.hasPoweredAntenna[0]).SetCurrentPower(0);
				AntennaAndPower._instance.hasPoweredAntenna.RemoveAt (0);
			}
			for(int i = 0 ; i < TowerBuildManager._instance.GetAntennaList().Count ; i++){
				((Antenna)(TowerBuildManager._instance.GetAntennaList()[i])).SetMaxPower(increasedAntennaPower);
			}
			AntennaAndPower._instance.SetAntennaNeedPower(increasedAntennaPower);
			hasIncreased = true;
			isIncreased = false;
		}
	}
}
