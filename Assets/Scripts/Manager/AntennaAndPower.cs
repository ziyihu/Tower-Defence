using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntennaAndPower : MonoBehaviour {

	public static AntennaAndPower _instance;

	void Awake(){
		_instance = this;
	}

	private int currentPower;
	private static int antennaNeedPower = 5;

	public int GetAntennaNeedPower(){
		return antennaNeedPower;
	}

	public void SetAntennaNeedPower(int number){
		antennaNeedPower = number;
	}

	//store all the powered antenna, all the unpowered antenna are in the TowerBuildManager._instance.antennaList 
	public List<Character> hasPoweredAntenna = new List<Character>();

	string description = null;

	public void ReturnPowerWhenGeneratorDestoryed(int number){
		int count = number / antennaNeedPower;
		if (hasPoweredAntenna.Count > count) {
			count++;
		}
		for (int i = 0; i < count; i++) {
			((Antenna)hasPoweredAntenna[0]).SetCurrentPower(0);
			TowerBuildManager._instance.GetAntennaList().Add(hasPoweredAntenna[0]);
			((Antenna)hasPoweredAntenna[0]).SetAniNotActive();
			//hasPoweredAntenna[0].Destroy();
			hasPoweredAntenna.RemoveAt (0);
			TowerBuildManager._instance.AddPower(antennaNeedPower);
		}
	}

	void Update(){
		if(TowerBuildManager._instance.GetAntennaList().Count > 0){
			 TowerBuildManager._instance.GetCurrentPowerNum ();
			//has enough power and the current antenna has got no power before
			if( TowerBuildManager._instance.GetCurrentPowerNum () >= antennaNeedPower ){
				((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).SetCurrentPower(antennaNeedPower);
				((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).SetAniActive();
				description = "this tower supply power to nearby towers\n"+"Current Power: "+((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).GetCurrentPower();
				//TowerBuildManager._instance.GetAntennaList()[0].Destroy();
				hasPoweredAntenna.Add((TowerBuildManager._instance.GetAntennaList()[0]));
				TowerBuildManager._instance.GetAntennaList().RemoveAt(0);
				TowerBuildManager._instance.UseCurrentPowerNum (antennaNeedPower);
				TowerBuildManager._instance.SetPanel(description);
			} 
			//not enough power and the current antenna has got no power before
//			else if( TowerBuildManager._instance.GetCurrentPowerNum () < antennaNeedPower 
//			        &&  TowerBuildManager._instance.GetCurrentPowerNum () > 0
//			        && ((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).PowerFromGeneator() == 0){
//			//	hasPoweredAntenna.Add((Antenna)(TowerBuildManager._instance.GetAntennaList()[0]));
//				((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).GetBackPower(currentPower);
//				((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).GetPowerFromGeneator(currentPower);
//				//currently the tower is not fully powered
//				//do not remove
//
//				//TowerBuildManager._instance.GetAntennaList().RemoveAt(0);
//				TowerBuildManager._instance.UseCurrentPowerNum (currentPower);
//				description = "this tower supply power to nearby towers\n"+"Current Power:"+currentPower;
//				TowerBuildManager._instance.SetPanel(description);
//			}
			//enough power and the current antenna has got power before
//			else if(((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).PowerFromGeneator() > 0
//			        && TowerBuildManager._instance.GetCurrentPowerNum () >= antennaNeedPower - ((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).PowerFromGeneator()){
//				int morePower = antennaNeedPower - ((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).PowerFromGeneator();
//				hasPoweredAntenna.Add((Antenna)(TowerBuildManager._instance.GetAntennaList()[0]));
//				((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).GetBackPower(antennaNeedPower);
//				((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).GetPowerFromGeneator(antennaNeedPower);
//				TowerBuildManager._instance.GetAntennaList().RemoveAt(0);
//				TowerBuildManager._instance.UseCurrentPowerNum (morePower);
//				description = "this tower supply power to nearby towers\n"+"Current Power:"+antennaNeedPower;
//				TowerBuildManager._instance.SetPanel(description);
//			}
			//not enough power and the current antenna has got power before
		}
	}
}
