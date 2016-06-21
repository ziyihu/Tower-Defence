using UnityEngine;
using System.Collections;

public class Tower1Attack : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (TowerBuildManager._instance.gManager.tower1List.Count > 0 && Time.timeScale == 1) {
			foreach (Tower1 t in TowerBuildManager._instance.gManager.tower1List) {
				if(t.GetPowerProvider()!=null){
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Unlit/Transparent Colored");
					t.CheckEnemy ();
					t.HitEnemy ();
				} else {
					t.GetTransform().GetComponentInChildren<Renderer>().material.shader = Shader.Find("Transparent/Bumped Specular");
				}
			}
		}
	}
}
