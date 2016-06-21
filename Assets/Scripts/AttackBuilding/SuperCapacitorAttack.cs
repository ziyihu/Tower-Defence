using UnityEngine;
using System.Collections;

public class SuperCapacitorAttack : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (TowerBuildManager._instance.gManager.superCapList.Count > 0 && Time.timeScale == 1) {
			foreach(SuperCapacitor t in TowerBuildManager._instance.gManager.superCapList){
				if(t.GetPowerProvider()!=null){
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
					t.FindTowers();
					t.IncreaseAttackRate();
				} else {
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
				}
			}
		}
	}
}
