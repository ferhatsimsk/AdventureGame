using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScriptSpider : MonoBehaviour {

	public int EnemyHealth = 15; //örümceğin sağlık durumu
    public SpiderFollow sf; //örümceğin takip ettiği hedefi kontrol eder.
    public Animation DieAnim; //örümceğin ölüm animasyonunu oynatmak için kullanılır.

    private WaitForSeconds wfsDieAnim; //örümcek ölüm animasyonunun oynatılmasından önceki bekleme süresini sağlar. Başlangıçta 0.48 saniyelik bir süreyle oluşturulur.

    // "wfsDieAnim" nesnesi 0.48 saniyelik bir bekleme süresiyle başlatılır.
    void Start () {
		wfsDieAnim = new WaitForSeconds (0.48f);
	}

    //  örümceğin sağlık durumunu kontrol eder.
    //Eğer "EnemyHealth" değeri sıfıra düşerse, örümceğin takip etme işlevi devre dışı bırakılır, ölüm animasyonu oynatılır ve "EndSpider" adlı bir Coroutine fonksiyonu başlatılır.
    void Update () {
		if (EnemyHealth <= 0) {
			//Destroy(gameObject);
			sf.enabled = false;
			DieAnim.Play ("die");
			StartCoroutine ("EndSpider");
		}
	}

    //örümceğin sağlık değerinden belirli bir hasar miktarını düşürmek için kullanılır.
    public void DeductPoints (int DamageAmount) {
		EnemyHealth -= DamageAmount;
	}

    //belirli bir süre boyunca bekler ve ardından örümcek nesnesini yok eder.
    IEnumerator EndSpider() {
		yield return wfsDieAnim;
		Destroy (gameObject);
	}
}
