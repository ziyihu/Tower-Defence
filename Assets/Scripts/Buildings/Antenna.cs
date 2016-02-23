using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Antenna : Building {

	public List<Character> providePowerTowers = new List<Character> ();

	public void AddToProvidePowerTowerList(Character building){
		providePowerTowers.Add (building);
	}

	public void RemoveFromProvidePowerTowerList(Character building){
		providePowerTowers.Remove (building);
	}

	public List<Character> GetProvidePowerTowerList(){
		return providePowerTowers;
	}

	//current power of the antenna
	private int currentPower = 0;
	//max power of the antenna
	private int maxPower = AntennaAndPower._instance.GetAntennaNeedPower();
	
	public int GetMaxPower() { return maxPower; }
	public int GetCurrentPower(){ return currentPower; }

	public void SetCurrentPower(int power){
		currentPower = power;
	}

	public void SetMaxPower(int power){
		maxPower = power;
	}

	public void UsePower(int power){
		if (currentPower + power <= maxPower) {
			currentPower += power;
		} else {
			currentPower = maxPower;
		}
	}

	public void AddPower(int power){
		if (currentPower - power >= 0) {
			currentPower -= power;
		} else {
			Debug.Log("error, not enough power");
		}
	}

	public Antenna(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("antenna"));
		model.name = "" + ID;
		status = model.GetComponent<CharacterStatus> ();
		status.rotateWeapon = true;
		status.CurPose = CharacterStatus.Pose.None;
		//get the building
		Transform house = model.transform.GetChild (0);
		house.gameObject.GetComponent<Renderer>().sortingOrder = layerOrder = LAYER_BASE + 1;
		buildingType = CharacterData.buildingMode.ALIEN;
		model.transform.Find ("Quad").GetComponent<QuadTextureNgui> ().spriteName = "Antenna001";
		model.transform.Find ("Quad").GetComponent<QuadTextureAni> ().enabled = false;
	}
	
	public void SetPosition(Vector3 pos){
		if (model != null) {
			model.transform.position = pos;
		}
	}
	
	public void SetDirection(Vector3 dir){
		if (model != null) {
			model.transform.localRotation = Quaternion.Euler (dir);
		}
	}
	
	public Vector3 GetPosition(){
		return model.transform.position;
	}

	//if the antenna is active, set the animation work
	public void SetAniActive(){
		model.transform.Find ("Quad").GetComponent<QuadTextureAni> ().enabled = true;
	}

	//if the antenna is not active, set the animation not work
	public void SetAniNotActive(){
		model.transform.Find ("Quad").GetComponent<QuadTextureAni> ().enabled = false;
	}
}
