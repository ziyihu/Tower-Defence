using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AtennaEffectPool : MonoBehaviour {

	public static AtennaEffectPool instance;
	
	public List<GameObject> antennaEffectList = new List<GameObject>();
	public List<GameObject> UsingList = new List<GameObject>();
	
	void Awake(){
		instance = this;
	}
	
	// Use this for initialization
	void Start () {
		antennaEffectList.Clear ();
		UsingList.Clear ();
		for (int i = 0; i < 3; i ++) {
			GameObject bulletgo = (GameObject)GameObject.Instantiate(Resources.Load("antennaeffect"),Vector3.zero,Quaternion.identity);

			bulletgo.gameObject.transform.parent = this.gameObject.transform;
			bulletgo.gameObject.SetActive(false);
			antennaEffectList.Add(bulletgo);
		}
	}
	
	public bool Push(GameObject pushObj){
		if (UsingList.Find(x => x==pushObj)) {
			pushObj.gameObject.SetActive(false);
			antennaEffectList.Add(pushObj);
			UsingList.Remove(pushObj);
			return true;
		} else {
			pushObj.gameObject.SetActive(false);
			antennaEffectList.Add(pushObj);
			return true;
		}
	}

	GameObject bulletgo = null;

	public GameObject Pop(){
		if (antennaEffectList.Count <= 0) {
			bulletgo = (GameObject)GameObject.Instantiate(Resources.Load("antennaeffect"),Vector3.zero,Quaternion.identity);
			bulletgo.gameObject.transform.parent = this.gameObject.transform;
			return bulletgo;
		}
		else {
			GameObject item = antennaEffectList[0];
			item.gameObject.SetActive(true);
			UsingList.Add(item);
			antennaEffectList.Remove(item);
			return item;
		} 
	}

}
