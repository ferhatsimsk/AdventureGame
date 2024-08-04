using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

	public static float DistanceFromTarget; //oyuncunun hedefe olan mesafesini saklar

    private float ToTarget;//oyuncunun hedefe olan mesafesini geçici olarak saklamak için 

    // Use this for initialization
    void Start () {
		
	}

    // oyuncunun hedefe olan mesafesini günceller.
    //bir ışının (ray) belirli bir yönde fırlatılmasını sağlar ve çarpışma noktasını ve mesafesini döndürür. Bu durumda, transform.position oyuncunun pozisyonunu, transform.forward ise oyuncunun ileri yöndeki vektörünü temsil eder.
    //out hit parametresi, çarpışma noktasının ve bilgilerinin atanacağı bir RaycastHit nesnesini temsil eder.
    //ToTarget = hit.distance ifadesi, ışının hedefe olan mesafesini ToTarget değişkenine atar.
    //DistanceFromTarget = ToTarget ifadesi, ToTarget değerini DistanceFromTarget değişkenine atar. Bu sayede diğer betikler tarafından hedefe olan mesafe bilgisine erişilebilir.

    void Update () {
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			ToTarget = hit.distance;
			DistanceFromTarget = ToTarget;
		}
	}
}
