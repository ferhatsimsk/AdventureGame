using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreakyDoorOpen : MonoBehaviour {

	public Text ActionDisplay;
	public Animation TheDoorAnim;
	public AudioSource CreakySound;

	private float TheDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver() {
		if (TheDistance <= 3) {
			ActionDisplay.text = "Open door";
			if (Input.GetButtonDown ("Action")) {
				GetComponent<BoxCollider> ().enabled = false;
				ActionDisplay.text = "";
				TheDoorAnim.Play ("OpenDoor");
				CreakySound.Play ();
			}
		}
	}

	void OnMouseExit() {
		ActionDisplay.text = "";
	}
}
