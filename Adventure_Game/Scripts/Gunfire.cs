using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunfire : MonoBehaviour {

	public AudioSource gunsound; //silah ateşleme sesini çalmak için
    public Animation gunshot; //silah ateşleme animasyonunu oynatmak için
    public GameObject Flash; //ateşleme flaşı

    private WaitForSeconds FireflashTempo; //ateşleme flaşının süresini belirlemek için

    // "gunsound" nesnesi, komponent olarak AudioSource'a atanan nesneye eşitlenir.
    //"gunshot" nesnesi, komponent olarak Animation'a atanan nesneye eşitlenir.
    //"FireflashTempo" değeri 0.1 saniye olarak ayarlanır.
    
    void Start () {
		gunsound = GetComponent<AudioSource> ();
		gunshot = GetComponent<Animation> ();
		FireflashTempo = new WaitForSeconds (0.1f);
	}

    //ateşleme işlemini kontrol eder.
    /*
	 Eğer "GlobalAmmo.LoadedAmmo" değişkeni 1'den büyük veya eşitse:

	a. "Fire1" düğmesine basılırsa:

	"gunsound.Play()" komutuyla ateşleme sesi çalınır.

	"StartCoroutine("FireFlash")" komutuyla ateşleme flaşını oynatan bir işlemin başlatılması sağlanır.

	"gunshot.Play("Gunshot")" komutuyla ateşleme animasyonu oynatılır.

	"GlobalAmmo.LoadedAmmo" değişkeninden 1 düşülür.
	 */
    void Update () {
		if (GlobalAmmo.LoadedAmmo >= 1) {
			if (Input.GetButtonDown ("Fire1")) {
				gunsound.Play ();
				StartCoroutine ("FireFlash");
				gunshot.Play ("Gunshot");
				GlobalAmmo.LoadedAmmo -= 1;
			}
		}
	}

    /*
	 a. "Flash.SetActive(true)" komutuyla ateşleme flaşının etkinleştirilmesi sağlanır.

	b. "yield return FireflashTempo" komutuyla belirli bir süre beklenir.

	c. "Flash.SetActive(false)" komutuyla ateşleme flaşının devre dışı bırakılması sağlanır.
	 */
    IEnumerator FireFlash() {
		Flash.SetActive (true);
		yield return FireflashTempo;
		Flash.SetActive (false);
	}
}
