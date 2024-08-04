using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kodun işlevi, düşman karakterin hedef oyuncuyu takip etmesini, yakınlık mesafesi sınırını aşmadığı sürece ona doğru hareket etmesini ve oyuncuya saldırdığında zarar vermesini sağlamaktır. Saldırı sırasında ekran yanıp sönerek oyuncunun zarar aldığını gösterir.
public class SpiderFollow : MonoBehaviour {

	public GlobalHealth globalHealth;
	public GameObject ThePlayer; //düşmanın takip etmesi gereken hedef oyuncu
    public float TargetDistance; //düşmanın hedef oyuncuya olan mesafesi
    public float AllowedRange = 20.0f; //düşmanın hedef oyuncuya ne kadar yaklaşabileceğini belirten bir mesafe sınırıdır.

    public Animation TheEnemyAnim; //düşman karakterin animasyon bileşeni
    public float EnemySpeed; //düşmanın hareket hızı
    public bool AttackTrigger; //düşmanın saldırı durumunu tetikler

    public bool IsAttacking = false; //düşmanın saldırı durumunda olup olmadığını kontrol eder.
    public GameObject ScreenFlash; //, ekranın yanıp sönmesi için bir oyun nesnesi
    public AudioSource Hurt01, Hurt02, Hurt03; //düşmanın oyuncuyu vurduğunda çalınacak acı seslerini referans alır.
    public int PainSound; //rastgele seçilen bir acı sesinin indeksini tutar.

    private RaycastHit Shot;
	private WaitForSeconds wfsAtatckAnim, wfsFlash, wfsNextAttack;

	// Use this for initialization
	void Start () {
		wfsAtatckAnim = new WaitForSeconds (0.4f); // zombie attack animation length
		wfsFlash = new WaitForSeconds(0.05f);
		wfsNextAttack = new WaitForSeconds(.75f);
	}

    //  düşman karakter oyuncuya doğru hareket eder ve hedefe yaklaştıkça saldırmaya başlar. Hedef oyuncunun belirli bir mesafeden uzaklaştığında düşman hareketsiz kalır ve saldırı durumu sona erer.
    //transform.LookAt(ThePlayer.transform) ifadesi, düşman karakterin hedef oyuncuya doğru yönelmesini sağlar. 
    //Physics.Raycast(transform.position, transform.forward, out Shot) ifadesi, düşmanın önünde bir ışın göndererek çarptığı nesneleri kontrol eder. Eğer bir çarpışma gerçekleşirse, çarpışmanın detaylarını Shot değişkenine kaydeder.
    //TargetDistance = Shot.distance ifadesi, düşmanın hedefe olan mesafesini TargetDistance değişkenine kaydeder. Bu değer, düşmanın hedefe olan uzaklığını temsil eder.
    //if (TargetDistance < AllowedRange) ifadesi, hedefe olan mesafenin belirli bir sınırdan küçük olduğunu kontrol eder. Eğer hedefe olan mesafe AllowedRange değerinden küçükse, düşman hareket etmeye ve saldırmaya devam eder.
    //EnemySpeed = 0.03f ifadesi, düşmanın hareket hızını belirler. 
    //if (!AttackTrigger) ifadesi, saldırı tetikleyicisinin etkin olup olmadığını kontrol eder. Eğer saldırı tetikleyici etkin değilse, düşman yürüme animasyonunu oynatır ve transform.position yardımıyla düşmanı hedef oyuncuya doğru hareket ettirir.
    //else ifadesi, hedefe olan mesafenin AllowedRange değerinden büyük olduğunu ifade eder. Bu durumda düşman hareketsiz kalır ve idle animasyonunu oynatır.
    //if (AttackTrigger) ifadesi, saldırı tetikleyicisinin etkin olup olmadığını kontrol eder. Eğer saldırı tetikleyici etkinse, düşman saldırıya geçer ve zarar vermeye başlar.
    //StartCoroutine("EnemyDamage") ifadesi, EnemyDamage adlı işlevin yineleyici olarak çalışmasını başlatır. Bu işlev, düşmanın oyuncuya saldırmasını ve ona zarar vermesini kontrol eder.
    void Update () {
		transform.LookAt (ThePlayer.transform);
		if (Physics.Raycast (transform.position, transform.forward, out Shot)) {
			TargetDistance = Shot.distance;
			if (TargetDistance < AllowedRange) {
				EnemySpeed = 0.03f;
				if (!AttackTrigger) {
					TheEnemyAnim.Play ("walk");
					transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, Time.deltaTime);
				}
			} else {
				EnemySpeed = 0.0f;
				TheEnemyAnim.Play ("idle");
			}
		}

		if (AttackTrigger) {
			if (!IsAttacking) {
				StartCoroutine ("EnemyDamage");
			}
			EnemySpeed = 0.0f;
			TheEnemyAnim.Play ("attack");
		}
	}

    //düşmanın saldırı durumunu tetikleyen bir mesafe sınırlayıcısı ile ilgili olayları işler. 
    // Eğer hedef oyuncu düşmanın bu mesafe sınırlayıcısına girdiyse, AttackTrigger bayrağı etkinleştirilir ve düşman saldırıya geçer. Oyuncu mesafe sınırlayıcısından çıktığında ise AttackTrigger bayrağı devre dışı bırakılır ve düşman saldırmayı durdurur.
    void OnTriggerEnter() {
		AttackTrigger = true;
	}

	void OnTriggerExit() {
		AttackTrigger = false;
	}

    //düşmanın oyuncuya saldırma ve ona zarar verme işlemini kontrol eder.
    //IsAttacking bayrağı etkinleştirilir ve düşmanın saldırı durumunda olduğu belirtilir.
    //PainSound değişkeni rastgele bir değer alır ve bu değere göre bir acı sesi çalınır.
    //wfsAtatckAnim bekleme süresi kadar beklenir (düşmanın saldırı animasyonunun süresi).
    //ScreenFlash oyun nesnesi aktifleştirilerek ekranın yanıp sönmesi efekti oluşturulur.
    //GlobalHealth.PlayerHealth değişkeninden oyuncunun sağlığından 2 puan düşülür.
    //Bir sonraki saldırı için bir süre beklenir (wfsNextAttack bekleme süresi kadar).
    //IsAttacking bayrağı devre dışı bırakılır ve düşmanın saldırı durumu sona erer.
    IEnumerator EnemyDamage() {
		IsAttacking = true;

		PainSound = Random.Range (1, 4);
		yield return wfsAtatckAnim;
		ScreenFlash.SetActive (true);
        globalHealth.PlayerHealth -= 2;
		switch (PainSound) {
		case 1:
				Hurt01.Play();
				break;
			case 2:
				Hurt02.Play();
				break;
			case 3:
				Hurt03.Play();
				break;
		}
		yield return wfsFlash;
		ScreenFlash.SetActive (false);
		yield return wfsNextAttack;

		IsAttacking = false;
	}
}
