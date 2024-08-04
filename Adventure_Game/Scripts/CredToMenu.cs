using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CredToMenu : MonoBehaviour {

	private WaitForSeconds wfendcredits;

	// Use this for initialization
	void Start () {
		wfendcredits = new WaitForSeconds (10);
		StartCoroutine ("WaitForEndCredit");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator WaitForEndCredit() {
		yield return wfendcredits;
		SceneManager.LoadScene (4);
	}
}
