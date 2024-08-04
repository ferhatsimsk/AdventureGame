using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Runtime.InteropServices.Expando;

public class OpenDoor001 : MonoBehaviour {

	public Text TextDisplay; // kapının üzerinde görünen metin
    public Animation TheDoorAnim; //kapının animasyonu

    public GameObject ObjectiveComplete; //kapının açılmasıyla ilişkili olarak gösterilecek bir hedef tamamlandı efekti

    private float TheDistance; //PlayerCasting betiğindeki DistanceFromTarget değişkeninin değerini tutar. Bu değişken, oyuncunun kapıya olan mesafesini temsil eder.
    /*
      sırasıyla 1 ve 5 saniye süren WaitForSeconds nesnelerini temsil eder. Bu nesneler, belirli süreler boyunca bekleme işlemlerini gerçekleştirmek için kullanılır.
     */
    private WaitForSeconds Wf1s, Wf5s;

    // WaitForSeconds nesneleri oluşturulur.
    void Start () {
		Wf1s = new WaitForSeconds (1);
		Wf5s = new WaitForSeconds (5);
	}

    // oyuncunun kapıya olan mesafeyi günceller.
    void Update () {
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

    //fare kapının üzerine geldiğinde çalışır. Eğer oyuncu kapıya olan mesafe 2 birim veya daha azsa, metni "Open door" olarak günceller.
    //Input.GetButtonDown("Action") ifadesi, "Action" adlı bir düğmeye basıldığında true değeri döndürür. Bu durumda, eğer oyuncu kapıya olan mesafe 2 birim veya daha azsa, ObjectiveComplete nesnesini etkinleştirir ve "OpenTheDoor" adlı işlevi başlatır.
    void OnMouseOver() {
		if (TheDistance <= 2) {
			TextDisplay.text = "Open door";
		}
		if (Input.GetButtonDown("Action")) {
			if (TheDistance <= 2) {
				//ObjectiveComplete.SetActive (true);
				StartCoroutine ("OpenTheDoor");
			}
		}
	}

    //fare kapının üzerinden ayrıldığında çalışır ve metni temizler.
    void OnMouseExit() {
		TextDisplay.text = "";
	}

    // kapının açılma animasyonunu
    //TheDoorAnim bileşenini devre dışı bırakır ve 5 saniye bekler. Son olarak, TheDoorAnim bileşenini tekrar etkinleştirir ve 1 saniye bekler. Bu süreç, kapının açılma ve kapanma animasyonunu simüle eder.
    IEnumerator OpenTheDoor() {		
		TheDoorAnim.enabled = true;
		yield return Wf1s;
		TheDoorAnim.enabled = false;
		yield return Wf5s;
		TheDoorAnim.enabled = true;
		yield return Wf1s;
		TheDoorAnim.enabled = false;
	}
}
