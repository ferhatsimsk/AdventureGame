using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Inventory inventory;
    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory.CurrentItem(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory.CurrentItem(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventory.CurrentItem(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            inventory.CurrentItem(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            inventory.CurrentItem(4);
        }

    }


    public GameObject blueTick;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FrontDoor"))
        {
            blueTick.SetActive(true);
        }
    }

   


}
