using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spider001 : MonoBehaviour {

	public Text theSubs;
	public AudioSource spiderVoice;
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
		spiderVoice.Play ();
		theSubs.text = "Looks like there are some spiders over there";
		yield return wfsub;
		theSubs.text = "";
	}
}
