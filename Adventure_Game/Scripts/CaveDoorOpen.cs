using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaveDoorOpen : MonoBehaviour {

	public Text ActionDisplay;
	public AudioSource CreakSound;
	public GameObject FadeOut;

	private float TheDistance;
	private WaitForSeconds wffadeout;

	// Use this for initialization
	void Start () {
		wffadeout = new WaitForSeconds (1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver() {
		if ((TheDistance <= 3) && (GunHandling.PickedUpGun)) {
			ActionDisplay.text = "Enter Cave";
			if (Input.GetButtonDown ("Action")) {
				GetComponent<BoxCollider> ().enabled = false;
				ActionDisplay.text = "";
				CreakSound.Play ();
				StartCoroutine ("EnterTheCave");
			}
		}
	}

	void OnMouseExit() {
		ActionDisplay.text = "";
	}

	IEnumerator EnterTheCave() {
		FadeOut.SetActive(true);
		yield return wffadeout;
		SceneManager.LoadScene (7);
	}
}
