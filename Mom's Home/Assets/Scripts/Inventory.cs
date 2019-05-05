using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[15];

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
        for(int i = 0; i < inventory.Length; i++)
        {
            Debug.Log("In LOOP FOR " + item);
            if(inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                break;
            }
        }
        if (!itemAdded)
        {
            Debug.Log("Inventory full");
        }
    }
}
