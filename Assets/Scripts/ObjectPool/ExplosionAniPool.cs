using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionAniPool : MonoBehaviour {

	public static ExplosionAniPool instance;
	
	public List<GameObject> explosionAniList = new List<GameObject>();
	public List<GameObject> UsingList = new List<GameObject>();
	
	void Awake(){
		instance = this;
	}
	
	// Use this for initialization
	void Start () {
		explosionAniList.Clear ();
		UsingList.Clear ();
		for (int i = 0; i < 3; i ++) {
			GameObject explosionAni = (GameObject)GameObject.Instantiate(Resources.Load("explosion"));
			explosionAni.transform.parent = this.gameObject.transform;
			explosionAni.gameObject.SetActive(false);
			explosionAniList.Add(explosionAni);
		}
	}
	
	public bool Push(GameObject pushObj){
		if (UsingList.Find(x => x==pushObj)) {
			pushObj.gameObject.SetActive(false);
			explosionAniList.Add(pushObj);
			UsingList.Remove(pushObj);
			return true;
		} else {
			pushObj.gameObject.SetActive(false);
			explosionAniList.Add(pushObj);
			return true;
		}
	}
	
	GameObject explosionAni;
	
	public GameObject Pop(){
		if (explosionAniList.Count <= 0) {
			explosionAni = (GameObject)GameObject.Instantiate(Resources.Load("explosion"));
			explosionAni.gameObject.transform.parent = this.gameObject.transform;
			return explosionAni;
		}
		else {
			GameObject item = explosionAniList[0];
			item.gameObject.SetActive(true);
			UsingList.Add(item);
			explosionAniList.Remove(item);
			return item;
		} 
	}
}
