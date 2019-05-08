using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInventory : MonoBehaviour
{
    public GameObject foodItem;

    public void AddItem(GameObject item)
    {
        foodItem = item;
    }
    public int inventoryCount()
    {
        if (foodItem != null)
            return 1;
        else
            return 0;
    }
    public void deleteItem()
    {
        foodItem = null;
    }
}
