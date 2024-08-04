using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityScript.Macros;

public class HealthMonitor : MonoBehaviour
{

    public GameObject Health04, Health03, Health02, Health01, Health00; //farklı sağlık durumlarında kullanılan sağlık göstergesi 

    public int CurrentHealth; //oyuncunun mevcut sağlık puanı
    public GlobalHealth globalHealth;
    // Use this for initialization
    void Start()
    {
    }

    // sağlık göstergelerini günceller.
    /*
	 Her bir durum, sağlık durumuna göre ilgili sağlık göstergesinin ölçeğini azaltır ve gerekirse göstermeyi devre dışı bırakır (SetActive(false)).
	Sağlık göstergesi ölçeği, transform.localScale kullanılarak düşürülür. Vector3 kullanarak y ekseninde ölçeği azaltırız.
	Durumlar, sağlık durumuna göre farklı ölçek azaltma miktarları kullanır.
	Health00 durumunda, sağlık göstergesinin ölçeği sıfırın altına düştüğünde de devre dışı bırakılır.
	Kod, sağlık göstergelerini düzenli olarak günceller ve oyuncunun sağlık durumuna göre göstergeleri azaltır.
	 */
    void Update()
    {
        CurrentHealth = globalHealth.PlayerHealth;
        switch (CurrentHealth)
        {
            case 8:
                if (Health04.transform.localScale.y <= 0.0f)
                {
                    Health04.SetActive(false);
                }
                else
                {
                    Health04.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);
                }
                break;

            case 6:
                if (Health03.transform.localScale.y <= 0.0f)
                {
                    Health03.SetActive(false);
                }
                else
                {
                    Health03.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);
                }
                break;

            case 4:
                if (Health02.transform.localScale.y <= 0.0f)
                {
                    Health02.SetActive(false);
                }
                else
                {
                    Health02.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);
                }
                break;

            case 2:
                if (Health01.transform.localScale.y <= 0.0f)
                {
                    Health01.SetActive(false);
                }
                else
                {
                    Health01.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);
                }
                break;

            case 0:
                if (Health00.transform.localScale.y <= 0.0f)
                {
                    Health00.SetActive(false);
                }
                else
                {
                    Health00.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);
                }
                break;
        }
    }
}
