using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateInventory : MonoBehaviour
{
    public GameObject plateItem;
    public GameObject setTable1;
    public GameObject setTable2;
    public int tableSet;
    public bool fullPlate;

    void Start()
    {
        setTable1.SetActive(false);
        setTable2.SetActive(false);
        tableSet = 0;
    }

    public void AddItem(GameObject item)
    {
        plateItem = item;
    }
    public int inventoryCount()
    {
        if (plateItem != null)
            return 1;
        else
            return 0;
    }
    public void deleteItem()
    {
        plateItem = null;
    }

    public void serve()
    {
        fullPlate = true;
    }

    public bool served()
    {
        return fullPlate;
    }

    public void serveTable()
    {
        if(tableSet == 0)
        {
            deleteItem();
            setTable1.SetActive(true);
            tableSet++;
        }
        else if(tableSet == 1)
        {
            deleteItem();
            setTable2.SetActive(true);
            tableSet++;
        }
        else
        {
            Debug.Log("Table is already set.");
        }
    }
}
