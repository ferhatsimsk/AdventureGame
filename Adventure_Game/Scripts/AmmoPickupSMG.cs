using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupSMG : MonoBehaviour {

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
			GlobalAmmo.LoadedAmmo += 30;
		} else {
			GlobalAmmo.CurrentAmmo += 30;
		}
		this.gameObject.SetActive (false);
	}
}
