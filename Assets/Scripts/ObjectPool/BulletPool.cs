using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour {

	public static BulletPool instance;

	public List<GameObject> bulletList = new List<GameObject>();
	public List<GameObject> UsingList = new List<GameObject>();

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		bulletList.Clear ();
		UsingList.Clear ();
		for (int i = 0; i < 3; i ++) {
			GameObject bulletgo = (GameObject)GameObject.Instantiate(Resources.Load("cannonbullet"),Vector3.zero,Quaternion.identity);
			bulletgo.transform.parent = this.gameObject.transform;
			bulletgo.gameObject.SetActive(false);
			bulletList.Add(bulletgo);
		}
	}

	public bool Push(GameObject pushObj){
		if (UsingList.Find(x => x==pushObj)) {
			pushObj.gameObject.SetActive(false);
			bulletList.Add(pushObj);
			UsingList.Remove(pushObj);
			return true;
		} else {
			pushObj.gameObject.SetActive(false);
			bulletList.Add(pushObj);
			return true;
		}
	}

	GameObject bulletgo;

	public GameObject Pop(){
		if (bulletList.Count <= 0) {
			bulletgo = (GameObject)GameObject.Instantiate(Resources.Load("cannonbullet"),Vector3.zero,Quaternion.identity);
			bulletgo.gameObject.transform.parent = this.gameObject.transform;
			return bulletgo;
		}
		else {
			GameObject item = bulletList[0];
			item.gameObject.SetActive(true);
			UsingList.Add(item);
			bulletList.Remove(item);
			return item;
		} 
	}

}
