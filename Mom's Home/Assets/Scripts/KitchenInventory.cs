using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenInventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[15];

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                itemAdded = true;
                break;
            }
        }
        if (!itemAdded)
        {
            Debug.Log("Inventory full");
        }
    }
    public int inventoryCount()
    {
        int inventoryCount = 0;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                inventoryCount++;
            }
        }
        return inventoryCount;
    }
    public void deleteItem()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                inventory[i] = null;
            }
        }
    }
}