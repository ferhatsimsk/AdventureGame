using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrelbang : MonoBehaviour {

	public AudioSource BangSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.relativeVelocity.magnitude > 1) {
			BangSound.Play ();
		}
	}
}
