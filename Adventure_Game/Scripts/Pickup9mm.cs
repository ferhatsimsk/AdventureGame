using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup9mm : MonoBehaviour {
	
	public static float DistanceFromTarget; //hedefe olan mesafeyi saklar. Bu değişkenin değeri PlayerCasting betiği tarafından güncellenir.

    public GameObject AmmoDisplay; //mermi ekranını gösteren bir arayüz nesnesidir.
    public Text InstructionDisplay; //kullanıcıya talimatları gösterir.
    public AudioSource Pickup9mmAudio; // 9mm silahını alırken çalacak sesi temsil eder.

    //sahte silah, gerçek silah ve hedefin tamamlandığına dair bir işareti temsil eder.
    public GameObject FakeGun;
	public GameObject RealGun;
	public GameObject ObjectiveComplete;
    //mağara kapısının tetikleyici nesnesini temsil eder.
    public GameObject CaveDoorTrig;

	private float ToTarget;

	// Use this for initialization
	void Start () {		
	}

    // hedefe olan mesafeyi günceller.
    void Update () {

		DistanceFromTarget = PlayerCasting.DistanceFromTarget;
	}

    //fare imleci hedef nesnenin üzerine geldiğinde çalışır. Eğer hedefe olan mesafe 2 birimden azsa, kullanıcıya "Take 9mm" talimatını gösterir.
    //"Action" adlı bir düğmeye basıldığında true değeri döndürür. Bu durumda, eğer hedefe olan mesafe 2 birimden azsa, Take9mm işlevini çağırarak 9mm silahını alır ve hedefin tamamlandığına dair işareti etkinleştirir.
    void OnMouseOver() {
		if (DistanceFromTarget <= 2) {
			InstructionDisplay.text = "Take 9mm";
		}
		if (Input.GetButtonDown ("Action")) {
			if (DistanceFromTarget <= 2) {
				Take9mm ();
				//ObjectiveComplete.SetActive (true);
			}
		}
	}

    //OnMouseExit fonksiyonu, fare imleci hedef nesnenin üzerinden ayrıldığında çalışır.Talimatları temizler.
    void OnMouseExit() {
		InstructionDisplay.text = "";
	}

    //9mm silahını alırken yapılması gereken işlemleri gerçekleştirir. Mağara kapısı tetikleyici nesnesini devre dışı bırakır, alınan sesi çalar, hedef nesnesini sahneden uzaklaştırır, sahte silahı devre dışı bırakır, gerçek silahı etkinleştirir, mermi ekranını etkinleştirir ve GunHandling.PickedUpGun değişkenini true yapar (silahın alındığını belirtir).
    void Take9mm() {
		CaveDoorTrig.SetActive (false);
		Pickup9mmAudio.Play ();
		transform.position = new Vector3 (0.0f, -1000.0f, 0.0f);
		FakeGun.SetActive(false);
		RealGun.SetActive (true);
		AmmoDisplay.SetActive (true);
		GunHandling.PickedUpGun = true;
	}
}
