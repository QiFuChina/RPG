using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterAI : MonoBehaviour {

	public int hp;
	[Range(0,10)]
	public int hpMax=10; 

	public Text hpText;
	public Slider hpSlider;

	private Animator anim;
	// Use this for initialization
	void Awake () {
		hp=hpMax;
		anim=GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		hp=Mathf.Clamp(hp,0,10);
		hpText.text=hp+"/"+hpMax;
		hpSlider.value=(float)hp/(float)hpMax;
		if(hp<=0){
			Die();
		}
	}
	void OnTriggerEnter(Collider col){
		hp-=1;
	}
	void Die(){
		anim.SetTrigger("die");
		Destroy(gameObject);
	}
}
