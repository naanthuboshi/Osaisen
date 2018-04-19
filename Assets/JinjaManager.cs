using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JinjaManager : MonoBehaviour {
	
	public Sprite[] jinjaPicture=new Sprite[5];//神社の絵

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //神社の絵を設定
	public void SetJinjaPicture(long level){
		GetComponent<Image> ().sprite = jinjaPicture [level];
	}
	//神社の大きさを設定
	public void SetJinjaScale(long score,long nextScore){
		float scale = 0.5f + (((float)score / (float)nextScore) / 2.0f);
		transform.localScale = new Vector3 (scale, scale, 1.0f);
	}
}