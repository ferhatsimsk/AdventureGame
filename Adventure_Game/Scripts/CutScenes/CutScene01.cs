using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene01 : MonoBehaviour {

	public GameObject ThePlayer, Cam1, Cam2, TheUI;

	private WaitForSeconds wfcamanim;

	// Use this for initialization
	void Start () {
		wfcamanim = new WaitForSeconds (4.5f);
		StartCoroutine ("CutSceneBegin");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator CutSceneBegin() {
		yield return wfcamanim;
		Cam2.SetActive (true);
		Cam1.SetActive (false);
		yield return wfcamanim;
		ThePlayer.SetActive (true);
		TheUI.SetActive (true);
		Cam2.SetActive (false);
	}
}
