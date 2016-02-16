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
			} else if(this.transform.tag == "smallmine"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Small Mine";
				techNodeInfoDes.text = "Description:\nslows diamond acquisition";
			} else if(this.transform.tag == "largemine"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Large Mine";
				techNodeInfoDes.text = "Description:\nfast diamond acquisition";
			} else if(this.transform.tag == "smallgenerator"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Small Generator";
				techNodeInfoDes.text = "Description:\ngenerates a little bit of power";
			} else if(this.transform.tag == "largegenerator"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Large Generator";
				techNodeInfoDes.text = "Description:\ngenerates a lot of power";
			} else if(this.transform.tag == "researchlab"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Research Lab";
				techNodeInfoDes.text = "Description:\ngenerates research point over time";
			} else if(this.transform.tag == "targetingfacility"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Targeting Facility";
				techNodeInfoDes.text = "Description:\nincreases the damage of nearby towers";
			} else if(this.transform.tag == "supercapacitor"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Super Capacitor";
				techNodeInfoDes.text = "Description:\nincreases the rate of fire of nearby towers";
			} else if(this.transform.tag == "alienrecovery"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Alien Recovery";
				techNodeInfoDes.text = "Description:\ngenerators resources from aliens killed nearby";
			} else if(this.transform.tag == "extradamage"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Extra Damage";
				techNodeInfoDes.text = "Description:\nincreases the damage of the towers";
			} else if(this.transform.tag == "stasisfielddamage"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Stasis Damage";
				techNodeInfoDes.text = "Description:\nstasis field does damage";
			} else if(this.transform.tag == "generatorspower"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Generator Power";
				techNodeInfoDes.text = "Description:\nincreaesd power production from generators";
			} else if(this.transform.tag == "researchacceleration"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Research Speedup";
				techNodeInfoDes.text = "Description:\nincreases the research speed, gets more points";
			} else if(this.transform.tag == "napalm"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Lasts Posion";
				techNodeInfoDes.text = "Description:\nadd posion effect to the shoting";
			} else if(this.transform.tag == "extraslow2"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Extra Slow";
				techNodeInfoDes.text = "Description:\nextra slow effect on all enemies";
			} else if(this.transform.tag == "liferecovery"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Life Recovery";
				techNodeInfoDes.text = "Description:\nrecovery life when no enemies reached there in a while";
			} else if(this.transform.tag == "antenna"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Antenna";
				techNodeInfoDes.text = "Description:\nsupplies power to nearby towers";
			} else if(this.transform.tag == "overcharge"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Over Charge";
				techNodeInfoDes.text = "Description:\ntowers can be set to consume more power, deal more damage";
			} else if(this.transform.tag == "antennarange"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Antenna Range";
				techNodeInfoDes.text = "Description:\nincreased antenna range";
			} else if(this.transform.tag == "antennadelivery"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Antenna Power";
				techNodeInfoDes.text = "Description:\nincreased antenna power delivery";
			} else if(this.transform.tag == "armor"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Armor Piercing";
				techNodeInfoDes.text = "Description:\nincreased armor piercing";
			} else if(this.transform.tag == "extraslow2"){
				techNodeInfoPanel.SetActive(true);
				techNodeInfoPanel.transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.3f,this.transform.position.z);
				techNodeInfoName.text = "Extra Slow";
				techNodeInfoDes.text = "Description:\nextra slow effect when enemies reach base";
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
