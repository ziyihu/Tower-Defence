using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DieAniPool : MonoBehaviour {

	public static DieAniPool instance;
	
	public List<GameObject> dieAniList = new List<GameObject>();
	public List<GameObject> UsingList = new List<GameObject>();
	
	void Awake(){
		instance = this;
	}
	
	// Use this for initialization
	void Start () {
		dieAniList.Clear ();
		UsingList.Clear ();
		for (int i = 0; i < 3; i ++) {
			GameObject dieAni = (GameObject)GameObject.Instantiate(Resources.Load("die"));
			dieAni.transform.parent = this.gameObject.transform;
			dieAni.gameObject.SetActive(false);
			dieAniList.Add(dieAni);
		}
	}
	
	public bool Push(GameObject pushObj){
		if (UsingList.Find(x => x==pushObj)) {
			pushObj.gameObject.SetActive(false);
			dieAniList.Add(pushObj);
			UsingList.Remove(pushObj);
			return true;
		} else {
			pushObj.gameObject.SetActive(false);
			dieAniList.Add(pushObj);
			return true;
		}
	}
	
	GameObject dieAni;
	
	public GameObject Pop(){
		if (dieAniList.Count <= 0) {
			dieAni = (GameObject)GameObject.Instantiate(Resources.Load("die"));
			dieAni.gameObject.transform.parent = this.gameObject.transform;
			return dieAni;
		}
		else {
			GameObject item = dieAniList[0];
			item.gameObject.SetActive(true);
			UsingList.Add(item);
			dieAniList.Remove(item);
			return item;
		} 
	}
}
