using UnityEngine;
using System.Collections;

public class DestoryExplosionAni : MonoBehaviour {
		public float timer = 2;
		public float time = 0;
		
		// Use this for initialization
		//	void Start () {
		//
		//		Destroy (this.gameObject, timer);
		//	}
		
		void Update(){
			time += Time.deltaTime;
			if (time > timer) {
				time = 0;
				ExplosionAniPool.instance.Push(this.gameObject);
			}
		}
		

}
