using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure2 : MonoBehaviour
{
    public GameObject treasure;
    public GameObject bluetick;
    public GameObject woodStairs;

    void Start()
    {
        treasure.SetActive(false);
        bluetick.SetActive(false);
        woodStairs.SetActive(false);
    }

    void Update()
    {
        GameObject[] Zombie = GameObject.FindGameObjectsWithTag("Zombie");

        bool allZombieDead = true;

        foreach (GameObject zombie in Zombie)
        {
            if (zombie.activeSelf)
            {
                allZombieDead = false;
                break;

            }
        }

        treasure.SetActive(allZombieDead);
        if (treasure.activeSelf)
        {
            bluetick.SetActive(true);
            woodStairs.SetActive(true);
        }
    }
}
