using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class OkaneManager : MonoBehaviour {

	private const long MAX_OKANE = 9999999999999;
	private const long RESPAWN_TIME = 1;
	private const long MAX_LEVEL = 4;


	public GameObject okanePrefab;
	public GameObject canvasGame;
	public GameObject textScore;
	public GameObject KouhakuPrefab;
	public GameObject EmaPrefab;
	public GameObject JinjaPrefab;
	public GameObject OtonosamaPrefab;
	public GameObject HimesamaPrefab;
	public GameObject imageJinja;



	private long score=0;
	private long nextScore=10000000;
	private long currentOkane=MAX_OKANE;
	private DateTime lastDateTime;
	private long jinjaLevel=0;
	private long[]nextScoreTable=new long[]{5000000,15000000,2500000000,10000000000,9999999999999};


	void Start () {

		KouhakuPrefab.SetActive (false);
		HimesamaPrefab.SetActive (false);
		EmaPrefab.SetActive (false);
		OtonosamaPrefab.SetActive (false);


	
		currentOkane = 10;
		for (long i = 0; i < currentOkane; i++) {
			CreateOkane ();
		}


		lastDateTime = DateTime.UtcNow;
		nextScore = nextScoreTable [jinjaLevel];
		imageJinja.GetComponent<JinjaManager>().SetJinjaPicture(jinjaLevel);
		imageJinja.GetComponent<JinjaManager>().SetJinjaScale(score, nextScore);
		RefreshScoreText ();
	
	}
	

	void Update () {
		if (currentOkane < MAX_OKANE) {
			TimeSpan TimeSpan = DateTime.UtcNow - lastDateTime;
			if (TimeSpan >= TimeSpan.FromSeconds (RESPAWN_TIME)) {
				while (TimeSpan >= TimeSpan.FromSeconds (RESPAWN_TIME)) {
					CreateNewOkane ();
					TimeSpan -= TimeSpan.FromSeconds (RESPAWN_TIME);
				}
			}
		}
	}

	public void CreateNewOkane(){
		lastDateTime = DateTime.UtcNow;
		if (currentOkane >= MAX_OKANE) {
			return;
		}
		CreateOkane ();
		currentOkane++;
		
	}

			public void CreateOkane(){
				GameObject okane=(GameObject)Instantiate(okanePrefab);
				okane.transform.SetParent(canvasGame.transform,false);
				okane.transform.localPosition = new Vector3 (
					UnityEngine.Random.Range(-150.0f,150.0f),
					UnityEngine.Random.Range(-200.0f,-200.0f),
					0f);	


	}
		

	public void GetOkane(){
		score += 100000;
	
		if (score > nextScore) {
			score = nextScore;
		}
		JinjaLevelUp();
		RefreshScoreText ();
		imageJinja.GetComponent<JinjaManager>().SetJinjaScale (score, nextScore);
	
		if ((score == nextScore) && (jinjaLevel == MAX_LEVEL)) {
			ClearEffect ();
		}
		currentOkane--;
	}

	void RefreshScoreText(){
		textScore.GetComponent<Text> ().text =
			"お金:" + score + " / " + nextScore;
	}
		
		public void TouchOkane(){

	
				}

void JinjaLevelUpEffect(){
		KouhakuPrefab.SetActive(true);
		HimesamaPrefab.SetActive (true);
		EmaPrefab.SetActive (true);
		OtonosamaPrefab.SetActive (true);
		Invoke("JinjaSetActiveFalse",3.0f);

}
	void JinjaSetActiveFalse(){
		KouhakuPrefab.SetActive (false);
		HimesamaPrefab.SetActive (false);
		EmaPrefab.SetActive (false);
		OtonosamaPrefab.SetActive (false);
	}

void JinjaLevelUp(){
	if (score>=nextScore){
		if(jinjaLevel<MAX_LEVEL){
			jinjaLevel++;
			score=0;
			JinjaLevelUpEffect();

			nextScore=nextScoreTable[jinjaLevel];
			imageJinja.GetComponent<JinjaManager>().SetJinjaPicture(jinjaLevel);
		}
	}
}

void ClearEffect(){
	GameObject ema=(GameObject)Instantiate(EmaPrefab);
	ema.transform.SetParent(canvasGame.transform,false);
}
}
