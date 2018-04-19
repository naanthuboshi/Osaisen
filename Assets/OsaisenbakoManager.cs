using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsaisenbakoManager : MonoBehaviour {

	//オブジェクト参照
	private GameObject okaneManager;//お金マネージャー

	// Use this for initialization
	void Start () {
		okaneManager = GameObject.Find ("OkaneManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//お金の取得
	public void TouchOkane(){
		if (Input.GetMouseButton (0) == false) {
			return;
		}

		okaneManager.GetComponent<OkaneManager> ().GetOkane ();
		Destroy (this.gameObject);
		
	}
}
