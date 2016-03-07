using UnityEngine;
using System.Collections;

public class InGame : MonoBehaviour {

	public TweenPosition techTween;
	public TweenPosition techTween2;
	public TweenPosition techTween3;
	public TweenPosition wikiTween;

	public GameObject objTechTree1;
	public GameObject objTechTree2;
	public GameObject objTechTree3;
	
	public UIButton tower01;
	public UIButton tower02;
	public UIButton tower03;
	public UIButton tower04;
	public UIButton tower05;
	public UIButton tower06;
	public UIButton tower07;
	public UIButton tower08;
	public UIButton tower09;
	public UIButton tower10;

	public GameObject smallMine;
	public GameObject largeMine;

	public GameObject smallGenerator;
	public GameObject largeGenerator;

	public GameObject researchLab;
	public GameObject targetingFacility;
	public GameObject superCapacitor;
	public GameObject alienRecovery;

	public GameObject antenna;
	
	public UIButton stop;
	public UIButton start;
	public UIButton techTree;
	public UIButton wiki;
	public UIButton closeBtn;
	public UIButton closeBtn2;
	public UIButton closeBtn3;
	public UIButton closewiki;
	public UIButton techTree2;
	public UIButton techTree3;

	private TechNode node;
	
	void Start(){
		node = new TechNode ();

		//get the tower01 button
		UIEventListener.Get (tower01.gameObject).onClick += OnCreateTower01;
		
		UIEventListener.Get (stop.gameObject).onClick += OnStop;
		UIEventListener.Get (start.gameObject).onClick += OnStart;
		UIEventListener.Get (techTree.gameObject).onClick += OnShowTechTree;
		UIEventListener.Get (techTree2.gameObject).onClick += OnShowTechTree2;
		UIEventListener.Get (techTree3.gameObject).onClick += OnShowTechTree3;
		UIEventListener.Get (closeBtn.gameObject).onClick += OnHideTechTree;
		UIEventListener.Get (closeBtn2.gameObject).onClick += OnHideTechTree2;
		UIEventListener.Get (closeBtn3.gameObject).onClick += OnHideTechTree3;
		UIEventListener.Get (wiki.gameObject).onClick += OnShowWiki;
		UIEventListener.Get (closewiki.gameObject).onClick += OnHideWiki;
		Time.timeScale = 0;
	}
	
	void OnEnable(){
		
	}
	void OnDisable(){
		
	}
	
	void OnCreateTower01(GameObject obj){
		
	}
	
	public void OnStop(GameObject obj){
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} else if(Time.timeScale == 0){
			Time.timeScale = 1;
		}
	}
	public void OnStart(GameObject obj){
		Time.timeScale = 1;
	}

	public void OnShowTechTree(GameObject obj){
		objTechTree1.SetActive (true);
		techTween.PlayForward ();
		Time.timeScale = 0;
	}

	public void OnHideTechTree(GameObject obj){
		techTween.PlayReverse ();
		//objTechTree1.SetActive (false);
	}

	public void OnShowTechTree2(GameObject obj){
		objTechTree2.SetActive (true);
		techTween2.PlayForward ();
		Time.timeScale = 0;
	}
	
	public void OnHideTechTree2(GameObject obj){
		techTween2.PlayReverse ();
		//objTechTree2.SetActive (false);
	}

	public void OnShowTechTree3(GameObject obj){
		objTechTree3.SetActive (true);
		techTween3.PlayForward ();
		Time.timeScale = 0;
	}
	
	public void OnHideTechTree3(GameObject obj){
		techTween3.PlayReverse ();
		//objTechTree3.SetActive (false);
	}

	public void OnShowWiki(GameObject obj){
		wikiTween.PlayForward ();
		Time.timeScale = 0;
	}

	public void OnHideWiki(GameObject obj){
		wikiTween.PlayReverse ();
	}

	void OnDestory(){
		UIEventListener.Get (tower01.gameObject).onClick -= OnCreateTower01;
		
		UIEventListener.Get (stop.gameObject).onClick -= OnStop;
		UIEventListener.Get (start.gameObject).onClick -= OnStart;
		UIEventListener.Get (techTree.gameObject).onClick -= OnShowTechTree;
		UIEventListener.Get (closeBtn.gameObject).onClick -= OnHideTechTree;
		UIEventListener.Get (closeBtn2.gameObject).onClick -= OnHideTechTree2;
		UIEventListener.Get (closeBtn3.gameObject).onClick -= OnHideTechTree3;
		UIEventListener.Get (wiki.gameObject).onClick -= OnShowWiki;
		UIEventListener.Get (closewiki.gameObject).onClick -= OnHideWiki;
		UIEventListener.Get (techTree2.gameObject).onClick -= OnShowTechTree2;
		UIEventListener.Get (techTree3.gameObject).onClick -= OnShowTechTree3;
	}

	void Update(){
		if (node.GetTower8) {
			tower08.transform.GetChild(0).gameObject.SetActive(false);
		} 
		if (node.GetTower1) {
			tower01.transform.GetChild(0).gameObject.SetActive(false);
		} 
		if (node.GetTower2) {
			tower02.transform.GetChild(0).gameObject.SetActive(false);
		} 
		if (node.GetTower3) {
			tower03.transform.GetChild(0).gameObject.SetActive(false);
		} 
		if (node.GetTower4) {
			tower04.transform.GetChild(0).gameObject.SetActive(false);
		} 
		if (node.GetTower5) {
			tower05.transform.GetChild(0).gameObject.SetActive(false);
		} 	
		if (node.GetTower6) {
			tower06.transform.GetChild(0).gameObject.SetActive(false);
		} 	
		if (node.GetTower7) {
			tower07.transform.GetChild(0).gameObject.SetActive(false);
		} 
		if (node.GetTower9) {
			tower09.transform.GetChild(0).gameObject.SetActive(false);
		} 
		if (node.GetTower10) {
			tower10.transform.GetChild(0).gameObject.SetActive(false);
		} 
		if (node.GetSmallMine) {
			smallMine.transform.GetChild(0).gameObject.SetActive(false);
		}
		if (node.GetLargeMine) {
			largeMine.transform.GetChild(0).gameObject.SetActive(false);
		}
		if (node.GetSmallGenerator) {
			smallGenerator.transform.GetChild(0).gameObject.SetActive(false);
		}
		if (node.GetLargeGenerator) {
			largeGenerator.transform.GetChild(0).gameObject.SetActive(false);
		}
		if (node.GetResearchLab) {
			researchLab.transform.GetChild(0).gameObject.SetActive(false);
		}
		if (node.GetTargetingFacility) {
			targetingFacility.transform.GetChild(0).gameObject.SetActive(false);
		}
		if (node.GetSuperCapacitor) {
			superCapacitor.transform.GetChild(0).gameObject.SetActive(false);
		}
		if (node.GetAlienRecovery) {
			alienRecovery.transform.GetChild(0).gameObject.SetActive(false);
		}
		if (node.GetAnetnna) {
			antenna.transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}
