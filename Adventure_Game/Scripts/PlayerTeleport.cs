using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerTeleport : MonoBehaviour
{
    public Transform teleportObject;
    public Transform volcanoTeleport;

    public GameObject teleportDoors;
    public Light directionalLight;
    public GameObject shoppingItem3;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("FrontDoor"))
        {
            teleportDoors.SetActive(true);
            
        }

        if (other.CompareTag("TeleportTrigger"))
        {
            transform.position = teleportObject.position;
            directionalLight.gameObject.SetActive(true);
            shoppingItem3.gameObject.SetActive(true);
        }
        else if (other.CompareTag("VolcanoTeleport"))
        {
            transform.position = volcanoTeleport.position;
        }

    }
}
