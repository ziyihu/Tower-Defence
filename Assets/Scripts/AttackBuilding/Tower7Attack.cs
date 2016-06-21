using UnityEngine;
using System.Collections;

public class Tower7Attack : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (TowerBuildManager._instance.gManager.tower7List.Count > 0 && Time.timeScale == 1) {
			foreach (Tower7 t in TowerBuildManager._instance.gManager.tower7List) {
				if(t.GetPowerProvider()!=null){
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
					t.CheckEnemy();
					t.HitEnemy();
				} else {
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
				}
			}
		}
	}
}
