using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAnimate : MonoBehaviour {

	public GameObject UpCurs, DownCurs, RightCurs, LeftCurs;

	Animator UpCursAnim, DownCursAnim, RightCursAnim, LeftCursAnim;

	WaitForSeconds CursAnimWait;


	// Use this for initialization
	void Start () {
		UpCursAnim = UpCurs.GetComponent<Animator> ();
		DownCursAnim = DownCurs.GetComponent<Animator> ();
		RightCursAnim = RightCurs.GetComponent<Animator> ();
		LeftCursAnim = LeftCurs.GetComponent<Animator> ();

		CursAnimWait = new WaitForSeconds (0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalAmmo.LoadedAmmo >= 1) {
			if (Input.GetButtonDown ("Fire1")) {
				UpCursAnim.enabled = true;
				DownCursAnim.enabled = true;
				RightCursAnim.enabled = true;
				LeftCursAnim.enabled = true;

				StartCoroutine ("AnimCursor");
			}
		}
	}


	IEnumerator AnimCursor()    {
		yield return CursAnimWait;

		UpCursAnim.enabled = false;
		DownCursAnim.enabled = false;
		RightCursAnim.enabled = false;
		LeftCursAnim.enabled = false;
	}
}
