using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoPlayerDie : MonoBehaviour
{
    public GlobalHealth globalHealth;
    public GameObject ScreenFlash;
    public AudioSource Hurt01, Hurt02, Hurt03; //d��man�n oyuncuyu vurdu�unda �al�nacak ac� seslerini referans al�r.
    public int PainSound; //rastgele se�ilen bir ac� sesinin indeksini tutar.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Volcano"))
        {
            globalHealth.PlayerHealth = 0;
        }
        //else if (other.CompareTag("Fish"))
        //{
        //    PainSound = Random.Range(1, 4);
        //    ScreenFlash.SetActive(true);
        //    globalHealth.PlayerHealth -= 2;
        //    ScreenFlash.SetActive(false);
        //}
    }
}
