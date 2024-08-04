using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour {

	public int CurrentScore; //oyun skoru
    public Text ScoreText; //oyuncunun skorunu kullanıcıya göstermek için

    private int InternalScore;

	// Use this for initialization
	void Start () {
		
	}

    // skor değerini günceller.
    //"InternalScore", "CurrentScore" değerine eşitlenir.
    //skoru metin olarak günceller
    void Update () {
		InternalScore = CurrentScore;
		ScoreText.text = "" + InternalScore;
	}
}
