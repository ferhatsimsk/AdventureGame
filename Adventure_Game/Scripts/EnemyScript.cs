using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour {

	public int EnemyHealth = 10; //zombinin sağlık durumu
    public ZombieFollow zf; //zombinin takip ettiği hedef
    public Animation ZombieDie; //zombinin ölüm animasyonunu oynatmak için

    private WaitForSeconds wfsZombieDieAnim; //zombi ölüm animasyonunun oynatılmasından önceki bekleme süresi

    // Use this for initialization
    void Start () {
		wfsZombieDieAnim = new WaitForSeconds (3); // "wfsZombieDieAnim" nesnesi 3 saniyelik bir bekleme süresiyle başlatılır.

    }

    // zombinin sağlık durumunu kontrol eder.
    //Eğer "EnemyHealth" değeri sıfıra düşerse, zombinin takip etme işlevi devre dışı bırakılır, ölüm animasyonu oynatılır ve "EndZombie" adlı bir Coroutine fonksiyonu başlatılır.
    void Update () {
		if (EnemyHealth <= 0) {
			//Destroy(gameObject);
			zf.enabled = false;
			ZombieDie.Play ("Dying");
			StartCoroutine ("EndZombie");
		}
	}

    // zombinin sağlık değerinden belirli bir hasar miktarını düşürmek için kullanılır.
    public void DeductPoints (int DamageAmount) {
		EnemyHealth -= DamageAmount;
	}

    //belirli bir süre boyunca bekler ve ardından zombi nesnesini yok eder.
    IEnumerator EndZombie() {
		yield return wfsZombieDieAnim;
		Destroy (gameObject);
	}
}
