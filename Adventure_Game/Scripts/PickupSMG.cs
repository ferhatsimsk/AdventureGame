using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupSMG : MonoBehaviour {
	
	public static float DistanceFromTarget; //oyuncunun hedefe olan mesafesini saklar. Bu değer PlayerCasting betiği tarafından güncellenir.

    public GameObject Mechanics; //alınan nesneye ilişkin mekanikleri içerir.

    public GameObject AmmoDisplay; //Bu nesne, mermi ekranını gösteren bir arayüz nesnesidir.
    public Text InstructionDisplay; //kullanıcıya talimatları gösterir.
    public AudioSource PickupAudio; //nesneyi alırken çalacak sesi temsil eder.

    // sahte silah ve gerçek silahı temsil eder.
    public GameObject FakeGun;
	public GameObject RealGun;
    //hedefin tamamlandığını belirten bir işarettir.
    public GameObject ObjectiveComplete;

	private float ToTarget;

	// Use this for initialization
	void Start () {		
	}

    //  hedefe olan mesafeyi günceller.
    void Update () {

		DistanceFromTarget = PlayerCasting.DistanceFromTarget;
	}

    //fare imleci hedef nesnenin üzerine geldiğinde çalışır. Eğer hedefe olan mesafe 2 birimden azsa, kullanıcıya "Take SMG" talimatını gösterir.
    //"Action" adlı bir düğmeye basıldığında true değeri döndürür. Bu durumda, eğer hedefe olan mesafe 2 birimden azsa, Take9mm işlevini çağırarak nesneyi alır, mekanikleri etkinleştirir ve hedefin tamamlandığına dair işareti etkinleştirir.
    void OnMouseOver() {
		if (DistanceFromTarget <= 2) {
			InstructionDisplay.text = "Take SMG";
		}
		if (Input.GetButtonDown ("Action")) {
			if (DistanceFromTarget <= 2) {
				Take9mm ();
				Mechanics.SetActive (true);
				//ObjectiveComplete.SetActive (true);
			}
		}
	}

    //OnMouseExit fonksiyonu, fare imleci hedef nesnenin üzerinden ayrıldığında çalışır. Talimatları temizler.
    void OnMouseExit() {
		InstructionDisplay.text = "";
	}

    //nesneyi alırken yapılması gereken işlemleri gerçekleştirir. Alınan sesi çalar, nesneyi sahneden uzaklaştırır, sahte silahı devre dışı bırakır, gerçek silahı etkinleştirir ve mermi ekranını etkinle
    void Take9mm() {
		PickupAudio.Play ();
		transform.position = new Vector3 (0.0f, -1000.0f, 0.0f);
		FakeGun.SetActive(false);
		RealGun.SetActive (true);
		AmmoDisplay.SetActive (true);
	}
}
