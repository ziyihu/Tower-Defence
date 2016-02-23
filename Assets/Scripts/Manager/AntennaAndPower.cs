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

	//find the near antenna with has provided least power
	private int currentProviderRemain;
	private static int largestPowerProvider = -1;
	private Antenna currentAntenna;

	//return power to the generator number
	private int returnPowerToGenNum;
	private int count = 0;

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

		//if destory a generator
		//need to get power from the already powered towers
			for(int i = 0; i < TowerBuildManager._instance.GetNeedPowerTowers().Count ; i++){
				if(TowerBuildManager._instance.GetNeedPowerTowers()[i].GetPowerProvider() != null){
					if(returnPowerToGenNum < number){
						returnPowerToGenNum += TowerBuildManager._instance.GetNeedPowerTowers()[i].GetNeedPower();
						//return power to the antenna
						TowerBuildManager._instance.GetNeedPowerTowers()[i].GetPowerProvider().AddPower(TowerBuildManager._instance.GetNeedPowerTowers()[count].GetNeedPower());
						//remove from the antenna provide power list
						TowerBuildManager._instance.GetNeedPowerTowers()[i].GetPowerProvider().RemoveFromProvidePowerTowerList(TowerBuildManager._instance.GetNeedPowerTowers()[count]);
						//set provider null
						TowerBuildManager._instance.GetNeedPowerTowers()[i].SetPowerProvider(null);
					} 
				}
			}
			TowerBuildManager._instance.AddPower(returnPowerToGenNum);
			returnPowerToGenNum = 0;


	}

	void Update(){
		//have power and have tower need power
		if (TowerBuildManager._instance.GetCurrentPowerNum () >= 0) {
			foreach(Character chara in TowerBuildManager._instance.GetNeedPowerTowers()){
				//find the provider power tower in the range
				foreach(Antenna ant in TowerBuildManager._instance.GetAntennaList()){
					//in the range and the antenna have enough power to translate
					if(Vector3.Distance(ant.GetPos(),chara.GetPos()) <= ant.GetAttackRange()
				  	 && ((ant.GetMaxPower() - ant.GetCurrentPower()) >= chara.GetNeedPower() 
					    || chara.GetPowerProvider() != null)){
						currentProviderRemain = ant.GetMaxPower() - ant.GetCurrentPower();
						if(largestPowerProvider == -1){
							largestPowerProvider = currentProviderRemain;
							currentAntenna = ant;
						}
						//if equal, do not change current provider
						if(largestPowerProvider == currentProviderRemain && chara.GetPowerProvider() != null){
							currentAntenna = chara.GetPowerProvider();
						}
						//find the antenna with the most power
						if(largestPowerProvider < currentProviderRemain){
							largestPowerProvider = currentProviderRemain;
							currentAntenna = ant;
						}
					}
				}
				//see if there is a antenna can provider power
				if(currentAntenna != null && largestPowerProvider != -1){
					//have not been powered before
					if(chara.GetPowerProvider() == null){
						//use the power
						if(TowerBuildManager._instance.GetCurrentPowerNum () - chara.GetNeedPower() >= 0){
							//provide power to the tower
							//set to the antenna provide tower list
							currentAntenna.AddToProvidePowerTowerList(chara);
							TowerBuildManager._instance.UseCurrentPowerNum(chara.GetNeedPower());
							//antenna number decrease
							currentAntenna.UsePower(chara.GetNeedPower());
							//set the provider antenna
							chara.SetPowerProvider(currentAntenna);
						}
					}
					//have powered before
					else if(chara.GetPowerProvider() != null){
						//already powered before
						//just change the parent, no need to use power again
						//origin provider and current provider
					
							//give back the power to the original provider
							chara.GetPowerProvider().AddPower(chara.GetNeedPower());
							//remove from the original antenna provide power tower list
							chara.GetPowerProvider().RemoveFromProvidePowerTowerList(chara);
							//use the power in the new antenna
							currentAntenna.UsePower(chara.GetNeedPower());
							//set the provider to the new antenna
							chara.SetPowerProvider(currentAntenna);
							//set to the new antenna provide power tower list
							currentAntenna.AddToProvidePowerTowerList(chara);

					}
				}
				//no antenna in the range and if already powered need to return the power
				else if(currentAntenna == null && largestPowerProvider != -1){
					//if already powered need to return the power, set the provider null
					if(chara.GetPowerProvider() != null){
						//return the power to the generator
						TowerBuildManager._instance.AddPower(chara.GetNeedPower());
						//return power to the antenna
						chara.GetPowerProvider().AddPower(chara.GetNeedPower());
						//set the provider null
						chara.SetPowerProvider(null);
					} 
					//if not powered before and not antenna in the range, do nothing
					else if(chara.GetPowerProvider() == null){

					}
				}
				currentAntenna = null;
				largestPowerProvider = -1;
		}
//		if(TowerBuildManager._instance.GetAntennaList().Count > 0){
//			 TowerBuildManager._instance.GetCurrentPowerNum ();
//			//has enough power and the current antenna has got no power before
//			if( TowerBuildManager._instance.GetCurrentPowerNum () >= antennaNeedPower ){
//				((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).SetCurrentPower(antennaNeedPower);
//				((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).SetAniActive();
//				description = "this tower supply power to nearby towers\n"+"Current Power: "+((Antenna)TowerBuildManager._instance.GetAntennaList()[0]).GetCurrentPower();
//				//TowerBuildManager._instance.GetAntennaList()[0].Destroy();
//				hasPoweredAntenna.Add((TowerBuildManager._instance.GetAntennaList()[0]));
//				TowerBuildManager._instance.GetAntennaList().RemoveAt(0);
//				TowerBuildManager._instance.UseCurrentPowerNum (antennaNeedPower);
//				TowerBuildManager._instance.SetPanel(description);
//			} 
//		}
	}
}
}
