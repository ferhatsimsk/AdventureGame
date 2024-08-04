using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SCInventory playerInventory;
    InventoryUIController inventoryUI;
    public PlayerActions playerActions;
    public GlobalHealth globalHealth;

    bool isSwapping;
    int tempIndex;
    Slot tempSlot;

    private void Start()
    {
        inventoryUI = gameObject.GetComponent<InventoryUIController>();

    }

    public void DeleteItem()
    {
        if (isSwapping == true)
        {
            playerInventory.DeleteItem(tempIndex);
            isSwapping = false;
            inventoryUI.UpdateUI();
        }
    }

    public void DropItem()
    {
        if (isSwapping == true)
        {
            playerInventory.DropItem(tempIndex, gameObject.transform.position + 4 * Vector3.forward);
            isSwapping = false;
            inventoryUI.UpdateUI();
        }
    }
    public void CurrentItem(int index)
    {
        if (playerInventory.inventorySlots[index].item)
        {
            playerActions.SetItem(playerInventory.inventorySlots[index].item.itemPrefab);
            if (globalHealth.PlayerHealth != 10)
            {
                globalHealth.PlayerHealth += playerInventory.inventorySlots[index].item.health;
                playerInventory.DeleteItem(index);
                inventoryUI.UpdateUI();
            }
           
        }
    }

    public void SwapItem(int index)
    {
        if (isSwapping == false)
        {
            tempIndex = index;
            tempSlot = playerInventory.inventorySlots[tempIndex];
            isSwapping = true;
        }
        else if (isSwapping == true)
        {
            playerInventory.inventorySlots[tempIndex] = playerInventory.inventorySlots[index];
            playerInventory.inventorySlots[index] = tempSlot;
            isSwapping = false;
        }
        inventoryUI.UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (playerInventory.AddItem(other.gameObject.GetComponent<Item>().item))
            {
                Destroy(other.gameObject);
                inventoryUI.UpdateUI();

            }

        }
    }


}
