using UnityEngine;
using System.Collections;

public class TargetingFacilityAttack : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
		if (TowerBuildManager._instance.gManager.targetingFacList.Count > 0 && Time.timeScale == 1) {
			foreach(TargetingFacility t in TowerBuildManager._instance.gManager.targetingFacList){
				if(t.GetPowerProvider()!=null){
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
					t.FindTowers();
					t.IncreaseAttack();
				} else {
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
				}
			}
		}
	}
}
