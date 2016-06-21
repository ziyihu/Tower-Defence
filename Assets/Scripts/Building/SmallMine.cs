using UnityEngine;
using System.Collections;

public class SmallMine : Building {

	public DiamondResource nearestDiamond = null;
	float moveDistance = 0.5f;
	//timer
	private float timer = 2f;
	private float time = 0;

	public SmallMine(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("smallmine"));
		model.name = "" + ID;
		status = model.GetComponent<CharacterStatus> ();
		status.CurPose = CharacterStatus.Pose.None;
		//get the building
		Transform house = model.transform.GetChild (0);
		house.gameObject.GetComponent<Renderer>().sortingOrder = layerOrder = LAYER_BASE + 1;
		buildingType = CharacterData.buildingMode.MINE1;
	}

//	void CollectAnimation() {
//		time += RealTime.deltaTime;
//		if (timer < time) {
//			GameObject bulletgo = (GameObject)GameObject.Instantiate(Resources.Load("cannonbullet"));
//			DiamondCollectionEffect bullet = bulletgo.GetComponent<DiamondCollectionEffect>();
//			bulletgo.transform.position = GetTransform().position+GetTransform().forward * 0.6f;
//					
//					
//			bullet.Fire(nearestDiamond);
//						
//			Vector3 dir = Vector3.back* moveDistance;
//			GetTransform().GetChild(0).localPosition =new Vector3(dir.x , dir.y + 0.3f, dir.z) ;
//			QuadTextureNgui gui = GetTransform().GetChild(0).GetComponent<QuadTextureNgui>();
//			time = 0;
//			}
//	
//	}

	public void SetPosition(Vector3 pos){
		if (model != null) {
			model.transform.position = pos;
		}
	}
	public Vector3 GetPosition(){
		return model.transform.position;
	}
}
