using UnityEngine;
using System.Collections;

public class TechInfo : MonoBehaviour {

	private GameObject techNodeInfoPanel;
	private UILabel techNodeInfoName;
	private UILabel techNodeInfoDes;

	// Use this for initialization
	void Start () {
		techNodeInfoPanel = this.transform.parent.Find ("Panel").gameObject;
		techNodeInfoName = this.transform.parent.Find("Panel/NameLabel").GetComponent<UILabel>();
		techNodeInfoDes = this.transform.parent.Find ("Panel/DesLabel").GetComponent<UILabel> ();
		techNodeInfoPanel.SetActive (false);
	}

	void OnHover(bool b){
		if(b){
			if (this.transform.tag == "basictower") {
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Basic Tower";
				techNodeInfoDes.text = "Description:\nmedium range, medium rate of fire, medium damage";
			} else if(this.transform.tag == "shotguntower"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Shotgun Tower";
				techNodeInfoDes.text = "Description:\nlow range, medium rate of fire, low damage, shoots multiple enemies";
			} else if(this.transform.tag == "laser"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Laser Tower";
				techNodeInfoDes.text = "Description:\nhigh range, medium rate of fire, high damage";
			} else if(this.transform.tag == "howitzer"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Howitzer Tower";
				techNodeInfoDes.text = "Description:\nhigh range, low rate of fire, high damage, area effect";
			} else if(this.transform.tag == "stasisfield"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Stasis Tower";
				techNodeInfoDes.text = "Description:\nslows all enemies in range";
			}
		} else {
			techNodeInfoPanel.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {

//		if((Input.mousePosition.x - transform.position.x) < 20 && (Input.mousePosition.z - transform.position.z) < 20){
//			Debug.Log(2);
//			
//				techNodeInfoPanel.SetActive(true);
//				techNodeInfoPanel.transform.position = this.transform.position;
//				techNodeInfoName.text = "Basic Tower";
//				techNodeInfoDes.text = "medium range, medium rate of fire, medium damage";
//			}
	
	}

	public static Vector3 WorldToUI(Vector3 point)
	{
		Vector3 pt = Camera.main.WorldToScreenPoint (point);
		Vector3 ff = UICamera.mainCamera.ScreenToWorldPoint (pt);
		ff.z = 0;
		return ff;
	}
}
