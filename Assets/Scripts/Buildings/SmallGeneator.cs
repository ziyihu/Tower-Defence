using UnityEngine;
using System.Collections;

public class SmallGeneator : Building {
	//timer
	private float timer = 2f;
	private float time = 0;
	
	public SmallGeneator(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("smallgeneator"));
		model.name = "" + ID;
		status = model.GetComponent<CharacterStatus> ();
		status.CurPose = CharacterStatus.Pose.None;
		//get the building
		Transform house = model.transform.GetChild (0);
		house.gameObject.GetComponent<Renderer>().sortingOrder = layerOrder = LAYER_BASE + 1;
		buildingType = CharacterData.buildingMode.GENERATOR1;
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
