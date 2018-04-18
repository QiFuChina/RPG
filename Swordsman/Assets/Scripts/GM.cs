using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GM : MonoBehaviour {
	private MyData mydata;
	public GameObject Player;
	// Use this for initialization
	void Start () {
		// mydata=new MyData();
		// //JsonUtility.ToJson(mydata);
		// File.WriteAllText(Application.dataPath+"\\mydata.json",JsonUtility.ToJson(mydata));
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.U)){
			mydata=new MyData(Player.transform.position.x,Player.transform.position.z);
			File.WriteAllText(Application.dataPath+"\\mydata.json",JsonUtility.ToJson(mydata));
		}
		if(Input.GetKeyDown(KeyCode.Y)){
			mydata=JsonUtility.FromJson<MyData>(File.ReadAllText(Application.dataPath+"\\mydata.json"));
			Player.transform.position=new Vector3(mydata.MyPosX,0,mydata.MyPosY);
			File.WriteAllText(Application.dataPath+"\\mydata.json",JsonUtility.ToJson(mydata));
		}
	}
}
