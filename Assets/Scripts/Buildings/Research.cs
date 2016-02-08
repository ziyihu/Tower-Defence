using UnityEngine;
using System.Collections;

public class Research : Building {

	public Research(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("research"));
		model.name = "" + ID;
		status = model.GetComponent<CharacterStatus> ();
		status.rotateWeapon = true;
		status.CurPose = CharacterStatus.Pose.None;
		//get the building
		Transform house = model.transform.GetChild (0);
		house.gameObject.GetComponent<Renderer>().sortingOrder = layerOrder = LAYER_BASE + 1;
		buildingType = CharacterData.buildingMode.LAB;
	}
	public void SetPosition(Vector3 pos){
		if (model != null) {
			model.transform.position = pos;
		}
	}
	public Vector3 GetPosition(){
		return model.transform.position;
	}
	
}
