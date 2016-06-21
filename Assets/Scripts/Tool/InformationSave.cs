using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class InformationSave : MonoBehaviour {
	
	public static InformationSave instance;
	
	public int TechTree = 0;
	public float StartTime = 0;
	public float LastTime = 0;
	public float PlayTime;
	public int EarnedMoney = 0;
	public int SpendMoney = 0;
	public int LeftLife = 0;
	public int AttackingBuildingsNum = 0;
	public int BuildingsNum = 0;
	public int PowerGenerated;
	public float TotalDamage;
	
	//	public int GetSpendMoney(){
	//		return SpendMoney;
	//	}
	//
	//	public void AddSpendMoney(int number){
	//		SpendMoney += number;
	//	}
	
	char[] myChar = new char[1000];
	byte[] myByte = new byte[1000];
	
	// Use this for initialization
	void Start () {
		StartTime = Time.timeSinceLevelLoad;
		instance = this;
		//SaveInforToADoc ();
	}
	
	public void SaveInforToADoc(){
		PlayTime = LastTime - StartTime;
		string s = "Technology Tree" + TechTree + "\n"
			+"Start Time:" + StartTime + "\n" 
				+"End Time:" + LastTime + "\n"
				+"Play Time:" + PlayTime + "\n"
				+"Earned Money:" + EarnedMoney + "\n"
				+"Spend Money:" + SpendMoney + "\n"
				+"Left Life:" + LeftLife + "\n"
				+"Attacking Building Number:" + AttackingBuildingsNum + "\n"
				+"Total Building Number:" + BuildingsNum + "\n" 
				+"Power Generated:" + PowerGenerated + "\n"
				+"Total Damage:" + TotalDamage + "\n";
		CreateAndWriteDoc (s);
	}
	
	void CreateAndWriteDoc(string s){
		StreamWriter sw;
		string path = Application.dataPath+"/TechTree.txt";
		FileInfo t = new FileInfo (path);
		if (!t.Exists) {
			sw = t.CreateText();
		} else {
			sw = t.AppendText();
		}
		sw.WriteLine (s);
		sw.Close ();
		sw.Dispose ();
		//		FileStream myFileStream = new FileStream (path, FileMode.OpenOrCreate);
		//		myChar = s.ToCharArray ();
		//		Encoder myEncoder = Encoding.UTF8.GetEncoder ();
		//		myEncoder.GetBytes (myChar, 0, myChar.Length, myByte, 0, true);
		//		myFileStream.Write (myByte, 0, myByte.Length);
	}
	
}
