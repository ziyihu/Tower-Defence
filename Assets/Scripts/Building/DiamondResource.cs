using UnityEngine;
using System.Collections;

public class DiamondResource : Building {
	public GameObject barrack;
	public DiamondResource(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("Diamond"));
		model.name = "" + ID;
		//get the building
		Transform house = model.transform.GetChild (0);
		house.gameObject.GetComponent<Renderer>().sortingOrder = layerOrder = LAYER_BASE + 1;

		//status: idle attack
		status = model.GetComponent<CharacterStatus> ();
		buildingType = CharacterData.buildingMode.DIAMOND;
	}

	public override void Start(){
		base.Start ();
	}

	public void SetPosition(Vector3 pos){
		model.transform.localPosition = pos;
	}

	public void SetDirection(Vector3 dir){
		model.transform.localRotation = Quaternion.Euler(dir);
		}

	public override void Update(){
		base.Update ();
	}
}
