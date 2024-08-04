using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTrigger : MonoBehaviour
{
    //public GameObject inventoryArea;
    public GameObject shoppingUI;
    public Collider triggerCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //inventoryArea.SetActive(true);
            shoppingUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //inventoryArea.SetActive(false);
            shoppingUI.SetActive(false);
        }
    }
}
