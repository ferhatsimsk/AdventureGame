using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bir mermi kutusu nesnesinin tetikleyiciyle etkileşimini işlemektedir.
public class AmmoPickup : MonoBehaviour {

	public AudioSource AmmoSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider col) {
		AmmoSound.Play ();

		if (GlobalAmmo.LoadedAmmo == 0) {
			GlobalAmmo.LoadedAmmo += 10;
		} else {
			GlobalAmmo.CurrentAmmo += 10;
		}
		this.gameObject.SetActive (false);
	}
}
