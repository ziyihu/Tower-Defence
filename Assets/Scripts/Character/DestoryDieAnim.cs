using UnityEngine;
using System.Collections;

public class DestoryDieAnim : MonoBehaviour {
	public float timer = 2;
	public float time = 0;

	void Update(){
		time += Time.deltaTime;
		if (time > timer) {
			time = 0;
			DieAniPool.instance.Push(this.gameObject);
		}
	}

}
