using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour {

	public static int CurrentAmmo; //mevcut mermi miktarı
    public Text AmmoDisplay; //mevcut mermi miktarını kullanıcıya göstermek için 

    private int InternalAmmo;

	public static int LoadedAmmo; //yüklenmiş mermi miktarı
    public Text LoadedAmmoDisplay; //yüklenmiş mermi miktarını kullanıcıya göstermek için

    private int InternalLoadedAmmo; 


	// Use this for initialization
	void Start () {
		
	}

    // mermi miktarı bilgilerini günceller
    //"InternalAmmo" değerini kullanarak mevcut mermi miktarını metin olarak günceller
    //"InternalLoadedAmmo" değerini kullanarak yüklenmiş mermi miktarını metin olarak günceller.
    void Update () {
		InternalAmmo = CurrentAmmo;
		InternalLoadedAmmo = LoadedAmmo;

		AmmoDisplay.text = "" + InternalAmmo;
		LoadedAmmoDisplay.text = "" + InternalLoadedAmmo;
	}
}
