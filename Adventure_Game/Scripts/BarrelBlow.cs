using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarrelBlow : MonoBehaviour {

	public int EnemyHealth = 5;
	public GameObject TheBarrel, FakeBarrel;

	private WaitForSeconds wfsZombieDieAnim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyHealth <= 0) {
			TheBarrel.SetActive (false);
			FakeBarrel.SetActive (true);
			//StartCoroutine ("EndZombie");
		}
	}

	public void DeductPoints (int DamageAmount) {
		EnemyHealth -= DamageAmount;
	}

	IEnumerator EndZombie() {
		yield return wfsZombieDieAnim;
		Destroy (gameObject);
	}

}
