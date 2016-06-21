using UnityEngine;
using System.Collections;

public class DestoryExplosionAnim : MonoBehaviour {

	public float timer = 0.1f;
	public float time = 0;
	
	void Update(){
		time += Time.deltaTime;
		if (time > timer) {
			time = 0;
			ExplosionAniPool.instance.Push(this.gameObject);
		}
	}
}
