using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunfireSMG : MonoBehaviour {

	public Animator Gunshot; //ateşleme animasyonunu 

    public AudioSource SMGSound; //ateşleme sesini çalmak için 
    public GameObject Flash; // ateşleme flaşı

    public GameObject UpCurs, DownCurs, RightCurs, LeftCurs; //yön göstergeleri

    Animator UpCursAnim, DownCursAnim, RightCursAnim, LeftCursAnim; //yön göstergelerinin animasyonlarını kontrol etmek için

    private int AmmoCount; //mevcut mühimmat sayısı
    private Boolean Firing; //ateşleme durumunu kontrol etmek için
    private WaitForSeconds FireflashTempo; //ateşleme flaşının süresi

    // "FireflashTempo" değeri 0.1 saniye olarak ayarlanır.
    void Start () {
		UpCursAnim = UpCurs.GetComponent<Animator> ();
		DownCursAnim = DownCurs.GetComponent<Animator> ();
		RightCursAnim = RightCurs.GetComponent<Animator> ();
		LeftCursAnim = LeftCurs.GetComponent<Animator> ();

		FireflashTempo = new WaitForSeconds (0.1f);
	}

    // ateşleme işlemini kontrol eder.
    //"AmmoCount", "GlobalAmmo.LoadedAmmo" değişkenine eşitlenir.
    /*
	 Eğer "Fire1" düğmesine basılırsa:

	a."AmmoCount" değişkeni 1'den büyük veya eşitse:

	"Firing" değişkeni false ise:

	"SMGFire" adında bir IEnumerator işleminin başlatılması sağlanır.
	 */
    void Update () {
		AmmoCount = GlobalAmmo.LoadedAmmo;
		if (Input.GetButton ("Fire1")) {
			if (AmmoCount >= 1) {
				if (!Firing) {
					StartCoroutine ("SMGFire");
				}
			}
		}
	}

    /*
	 a. "Firing" değişkeni true olarak ayarlanır.

	b. Yön göstergeleri animasyonları aktif hale getirilir.

	c. "GlobalAmmo.LoadedAmmo" değişkeninden 1 düşülür.

	d. "Gunshot" animasyonu etkinleştirilir.

	e. "SMGSound.Play()" komutuyla SMG ateşleme sesi çalınır.

	f. Ateşleme flaşı etkinleştirilir.

	g. Belirli bir süre beklenir.

	h. Ateşleme flaşı devre dışı bırakılır.

	i. "Gunshot" animasyonu devre dışı bırakılır.

	. Yön göstergeleri animasyonları devre dışı bırakılır.

	k. "Firing" değişkeni false olarak ayarlanır.
	 */
    IEnumerator SMGFire() {
		Firing = true;

		UpCursAnim.enabled = true;
		DownCursAnim.enabled = true;
		RightCursAnim.enabled = true;
		LeftCursAnim.enabled = true;

		GlobalAmmo.LoadedAmmo--;
		Gunshot.enabled = true;
		SMGSound.Play ();
		Flash.SetActive (true);
		yield return FireflashTempo;
		Flash.SetActive (false);
		Gunshot.enabled = false;

		UpCursAnim.enabled = false;
		DownCursAnim.enabled = false;
		RightCursAnim.enabled = false;
		LeftCursAnim.enabled = false;

		Firing = false;

	}		
}
