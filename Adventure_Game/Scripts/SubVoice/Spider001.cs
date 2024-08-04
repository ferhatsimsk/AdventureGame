using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door002 : MonoBehaviour {

	public Text theSubs;
	public AudioSource doorVoice;
	public BoxCollider TrigSub;

	private WaitForSeconds wfsub;

	// Use this for initialization
	void Start () {
		wfsub = new WaitForSeconds (2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter() {
		StartCoroutine ("SpiderSub");
		TrigSub.enabled = false;
	}

	IEnumerator SpiderSub() {
		doorVoice.Play ();
		theSubs.text = "Looks like there is a cave over there";
		yield return wfsub;
		theSubs.text = "";
		yield return wfsub;
		TrigSub.enabled = true;
	}
}
