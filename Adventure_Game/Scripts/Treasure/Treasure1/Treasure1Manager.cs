using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure1Manager : MonoBehaviour
{
    public GameObject treasure;
    public GameObject bluetick;
    public GameObject towerCorner;

    void Start()
    {
        treasure.SetActive(false);
        bluetick.SetActive(false);
        towerCorner.SetActive(false);
    }

    void Update()
    {
        GameObject[] spiders = GameObject.FindGameObjectsWithTag("Spider");

        bool allSpidersDead = true;

        foreach (GameObject spider in spiders)
        {
            if (spider.activeSelf)
            {
                allSpidersDead = false;
                break;
                
            }
        }

        treasure.SetActive(allSpidersDead);
        if (treasure.activeSelf)
        {
            bluetick.SetActive(true);
            towerCorner.SetActive(true);
        }
    }
}
