using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu kod, düşman karakterin oyuncuya doğru hareket etmesini, saldırmasını ve oyuncuya zarar vermesini sağlar.
public class ZombieFollow : MonoBehaviour
{

    public GlobalHealth globalHealth;
    public GameObject ThePlayer; //düşmanın takip etmesi gereken oyuncu
    public float TargetDistance; //düşmanın oyuncuya olan mesafesi
    public float AllowedRange = 10.0f; //düşmanın oyuncuya saldırmaya başlaması için izin verilen maksimum mesafeyi belirler.

    public Animation TheEnemyAnim; //düşman karakterin animasyon bileşeni
    public float EnemySpeed; //düşmanın hareket hızı
    public bool AttackTrigger; //düşmanın saldırmak için tetiklenip tetiklenmediğini belirler.

    public bool IsAttacking = false; //düşmanın saldırıda bulunup bulunmadığını belirler.
    public GameObject ScreenFlash; //oyuncuya saldırı sırasında ekranın titremesini sağlar
    public AudioSource Hurt01, Hurt02, Hurt03; //düşmanın oyuncuya saldırırken çıkartacağı acı sesleri
    public int PainSound; //çalınacak acı sesinin rastgele bir seçimini tutar.

    private RaycastHit Shot; //düşmanın önünde bir isabet tespiti için kullanılır.
    private WaitForSeconds wfsAtatckAnim, wfsFlash, wfs1sec; //WaitForSeconds sınıfından beklenmesi gereken süreleri temsil eder.

    // Use this for initialization
    void Start()
    {
        wfsAtatckAnim = new WaitForSeconds(0.9f); // zombie attack animation length
        wfsFlash = new WaitForSeconds(0.05f);
        wfs1sec = new WaitForSeconds(1.0f);
    }

    // düşmanın davranışını günceller.
    // Öncelikle düşmanın oyuncuya doğru dönmesini sağlar (transform.LookAt(ThePlayer.transform))
    //Ardından, Physics.Raycast fonksiyonu kullanılarak düşmanın oyuncuya olan mesafesi ölçülür. 
    // Eğer mesafe, AllowedRange değerinden küçükse, düşman oyuncuya doğru hareket etmeye başlar ve animasyonunu oynatır (TheEnemyAnim.Play("Walking")).
    //Mesafe AllowedRange değerinden büyükse, düşman durur ve idle animasyonunu oynatır (TheEnemyAnim.Play("Idle")).
    //Eğer AttackTrigger değişkeni tetiklenirse (OnTriggerEnter veya OnTriggerExit fonksiyonları tarafından kontrol edilir), düşman saldırıya geçer.
    //IsAttacking değişkeni ile saldırma durumu kontrol edilir. 
    //Eğer düşman henüz saldırmıyorsa, EnemyDamage adlı bir yineleyici işlev başlatılır (StartCoroutine("EnemyDamage")).
    // Düşmanın hareketi durdurulur (EnemySpeed = 0.0f) ve saldırı animasyonu oynatılır (TheEnemyAnim.Play("Attacking")).
    //EnemyDamage adlı yineleyici işlevde, düşmanın saldırı süresi kadar beklenir (yield return wfsAtatckAnim).
    //Ardından, ScreenFlash aktifleştirilir ve oyuncunun canı azaltılır. Rastgele bir acı sesi seçilir ve çalınır.
    //Daha sonra bir süre boyunca ekran titremesi efekti gösterilir (yield return wfsFlash). 
    //Son olarak, bir saniye beklenir (yield return wfs1sec), IsAttacking değişkeni sıfırlanır ve düşmanın bir sonraki saldırıya hazır olması sağlanır.


    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.forward, out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance < AllowedRange)
            {
                EnemySpeed = 0.02f;
                if (!AttackTrigger)
                {
                    TheEnemyAnim.Play("Walking");
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, Time.deltaTime);
                }
            }
            else
            {
                EnemySpeed = 0.0f;
                TheEnemyAnim.Play("Idle");
            }
        }

        if (AttackTrigger)
        {
            if (!IsAttacking)
            {
                StartCoroutine("EnemyDamage");
            }
            EnemySpeed = 0.0f;
            TheEnemyAnim.Play("Attacking");
        }
    }

    void OnTriggerEnter()
    {
        AttackTrigger = true;
    }

    void OnTriggerExit()
    {
        AttackTrigger = false;
    }

    IEnumerator EnemyDamage()
    {
        IsAttacking = true;

        PainSound = Random.Range(1, 4);
        yield return wfsAtatckAnim;
        ScreenFlash.SetActive(true);
        globalHealth.PlayerHealth -= 2;
        switch (PainSound)
        {
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
        ScreenFlash.SetActive(false);
        yield return wfs1sec;

        IsAttacking = false;
    }
}
