using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunReload : MonoBehaviour {

	public AudioSource ReloadSound; //yeniden yükleme sesini çalmak için
    //silahın nişangahı ve mekaniklerini temsil eden 
    public GameObject CrossObject;
	public GameObject MechanicsObject;
    //"ClipCount" ve "ReserveCount" değişkenleri, yüklü mermi sayısı ve rezerv mermi sayısını tutar.
    //"ReloadAvailable" değişkeni, yeniden yükleme yapabilme durumunu belirtir.
    private int ClipCount, ReserveCount, ReloadAvailable;
	private Gunfire ThisGunfire;
	private Animation HandgunReloadAnim; //silahın yeniden yükleme animasyonu
    private WaitForSeconds Wf1d1s; // 1.1 saniye süreyle bekleme yapmak için

    // Use this for initialization
    void Start () {
		ThisGunfire = GetComponent<Gunfire> ();
		HandgunReloadAnim = GetComponent<Animation> ();
		Wf1d1s = new WaitForSeconds (1.1f);
	}

    // yeniden doldurma işlemini kontrol eder.
    void Update () {
		ClipCount = GlobalAmmo.LoadedAmmo;
		ReserveCount = GlobalAmmo.CurrentAmmo;

		if (ReserveCount == 0) {
			ReloadAvailable = 0;
		} else {
			ReloadAvailable = 10 - ClipCount;
		}

		if (Input.GetButtonDown("Reload")) {
			if (ReloadAvailable >= 1) {
				if (ReserveCount <= ReloadAvailable) {
					GlobalAmmo.LoadedAmmo += ReserveCount;
					GlobalAmmo.CurrentAmmo -= ReserveCount;
				} else {
					GlobalAmmo.LoadedAmmo += ReloadAvailable;
					GlobalAmmo.CurrentAmmo -= ReloadAvailable;
				}
				ActionReload();
			}
			StartCoroutine ("EnableScripts");
		}
	}

    
    //yeniden doldurma işlemi tamamlandıktan sonra diğer betikleri etkinleştirir.
    //yield return ifadesiyle birlikte IEnumerator kullanarak belirli süreler boyunca beklemeyi sağlar.
    private IEnumerator EnableScripts() {
		yield return Wf1d1s;
		ThisGunfire.enabled = true;
		CrossObject.SetActive (true);
		MechanicsObject.SetActive (true);
	}

    //"Reload" adlı bir tuşa basıldığında çalışır.
    //yeniden doldurma işlemi sırasında yapılması gereken eylemleri gerçekleştirir.
    void ActionReload() {
		ThisGunfire.enabled = false;
		CrossObject.SetActive (false);
		MechanicsObject.SetActive (false);
		ReloadSound.Play ();
		HandgunReloadAnim.Play ("HandGunReload");
	}
}
