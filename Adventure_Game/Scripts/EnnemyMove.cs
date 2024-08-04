using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMove : MonoBehaviour {

	public GameObject ThePlayer;
	public GameObject TheEnemy;
	public float EnemySpeed = 1.0f; // düşmanın hareket hızı

    public bool MoveTrigger; // düşmanın hareket etmesini tetiklemek için

    // Use this for initialization
    void Start () {
		
	}

    // düşmanın hareketini kontrol eder.
    //Bu, düşmanın oyuncuya doğru hareket etmesini sağlar.
    void Update () {
		if (MoveTrigger) {
			transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed);
		}
	}
}
