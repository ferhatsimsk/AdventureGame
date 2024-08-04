using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

// oyunda puan düşürme işlemi gerçekleştirmek ve hedefin tamamlandığını görsel olarak göstermek için kullanılabilir.

public class ZScore25 : MonoBehaviour {

	/*public GameObject ObjectiveComplete;*/ //hedefin tamamlandığını göstermek için kullanılır.
	public GlobalScore globalScore;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //belirli bir miktar puanı düşürmek için kullanılır.
    //İşlevin parametresi, düşürülecek puan miktarını belirtir. İşlev içinde şu işlemler gerçekleştirilir:
    //GlobalScore.CurrentScore değişkeni kullanılarak mevcut puan miktarına 25 puan eklenir.
    //ObjectiveComplete.SetActive(true) kullanılarak hedefin tamamlandığını gösteren oyun nesnesi etkinleştirilir.

    public void DeductPoints(int DamaAmount) {
		globalScore.CurrentScore += 25;
		//ObjectiveComplete.SetActive (true);
	}
}
