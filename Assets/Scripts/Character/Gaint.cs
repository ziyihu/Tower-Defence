using UnityEngine;
using System.Collections;

public class Gaint : Enemy {
	
	HeroConf conf;
	
	public Gaint(string enemy):base(enemy){
		this.START_METHOD ("Gaint");
		if(enemy == "giant"){
			characterType = CharacterData.CharacterModel.GIANT;
		} else if(enemy == "enemy2"){
			characterType = CharacterData.CharacterModel.ENEMY2;
		} else if(enemy == "enemy3"){
			characterType = CharacterData.CharacterModel.ENEMY3;
		} else if(enemy == "enemy4"){
			characterType = CharacterData.CharacterModel.ENEMY4;
		} else if(enemy == "enemy5"){
			characterType = CharacterData.CharacterModel.ENEMY5;
		} else if(enemy == "enemy6"){
			characterType = CharacterData.CharacterModel.ENEMY6;
		} else if(enemy == "enemy7"){
			characterType = CharacterData.CharacterModel.ENEMY7;
		} else if(enemy == "enemy8"){
			characterType = CharacterData.CharacterModel.ENEMY8;
		} else if(enemy == "enemy9"){
			characterType = CharacterData.CharacterModel.ENEMY9;
		} else if(enemy == "enemy10"){
			characterType = CharacterData.CharacterModel.ENEMY10;
		} else if(enemy == "enemy11"){
			characterType = CharacterData.CharacterModel.ENEMY11;
		} else if(enemy == "enemy12"){
			characterType = CharacterData.CharacterModel.ENEMY12;
		} else if(enemy == "enemy13"){
			characterType = CharacterData.CharacterModel.ENEMY13;
		} else if(enemy == "enemy14"){
			characterType = CharacterData.CharacterModel.ENEMY14;
		} else if(enemy == "enemy15"){
			characterType = CharacterData.CharacterModel.ENEMY15;
		} else if(enemy == "enemy16"){
			characterType = CharacterData.CharacterModel.ENEMY16;
		} else if(enemy == "enemy17"){
			characterType = CharacterData.CharacterModel.ENEMY17;
		} else if(enemy == "enemy18"){
			characterType = CharacterData.CharacterModel.ENEMY18;
		} else if(enemy == "enemy19"){
			characterType = CharacterData.CharacterModel.ENEMY19;
		} else if(enemy == "enemy20"){
			characterType = CharacterData.CharacterModel.ENEMY20;
		} else if(enemy == "enemy21"){
			characterType = CharacterData.CharacterModel.ENEMY21;
		} else if(enemy == "enemy22"){
			characterType = CharacterData.CharacterModel.ENEMY22;
		} else if(enemy == "enemy23"){
			characterType = CharacterData.CharacterModel.ENEMY23;
		} else if(enemy == "enemy24"){
			characterType = CharacterData.CharacterModel.ENEMY24;
		} else if(enemy == "enemy25"){
			characterType = CharacterData.CharacterModel.ENEMY25;
		} else if(enemy == "enemy26"){
			characterType = CharacterData.CharacterModel.ENEMY26;
		} else if(enemy == "enemy27"){
			characterType = CharacterData.CharacterModel.ENEMY27;
		} else if(enemy == "enemy28"){
			characterType = CharacterData.CharacterModel.ENEMY28;
		} else if(enemy == "enemy29"){
			characterType = CharacterData.CharacterModel.ENEMY29;
		} else if(enemy == "enemy30"){
			characterType = CharacterData.CharacterModel.ENEMY30;
		} else if(enemy == "enemy31"){
			characterType = CharacterData.CharacterModel.ENEMY31;
		} else if(enemy == "enemy32"){
			characterType = CharacterData.CharacterModel.ENEMY32;
		} else if(enemy == "enemy33"){
			characterType = CharacterData.CharacterModel.ENEMY33;
		} else if(enemy == "enemy34"){
			characterType = CharacterData.CharacterModel.ENEMY34;
		} else if(enemy == "enemy35"){
			characterType = CharacterData.CharacterModel.ENEMY35;
		} else if(enemy == "enemy36"){
			characterType = CharacterData.CharacterModel.ENEMY36;
		} else if(enemy == "enemy37"){
			characterType = CharacterData.CharacterModel.ENEMY37;
		} else if(enemy == "enemy38"){
			characterType = CharacterData.CharacterModel.ENEMY38;
		} else if(enemy == "enemy39"){
			characterType = CharacterData.CharacterModel.ENEMY39;
		} else if(enemy == "enemy40"){
			characterType = CharacterData.CharacterModel.ENEMY40;
		} else if(enemy == "enemy41"){
			characterType = CharacterData.CharacterModel.ENEMY41;
		} else if(enemy == "enemy42"){
			characterType = CharacterData.CharacterModel.ENEMY42;
		} else if(enemy == "enemy43"){
			characterType = CharacterData.CharacterModel.ENEMY43;
		} else if(enemy == "enemy44"){
			characterType = CharacterData.CharacterModel.ENEMY44;
		} else if(enemy == "enemy45"){
			characterType = CharacterData.CharacterModel.ENEMY45;
		} else if(enemy == "enemy46"){
			characterType = CharacterData.CharacterModel.ENEMY46;
		} else if(enemy == "boss1"){
			characterType = CharacterData.CharacterModel.BOSS1;
		} else if(enemy == "boss2"){
			characterType = CharacterData.CharacterModel.BOSS2;
		} 
		conf = HeroConfManager.Instance.GetHeroConfById (1);
		if (conf != null) {
			data.life = conf.hitPoint;
			data.maxLife = conf.hitPoint;
		}
		this.END_METHOD ("Gaint");
	}
	
	public void Destory(){
		base.Destory ();
	}
	
	// Use this for initialization
	public void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public void Update () {
		base.Update ();
	}
}

