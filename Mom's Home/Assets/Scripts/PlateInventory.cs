using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateInventory : MonoBehaviour
{
    public GameObject[] dirtyDishes;
    public GameObject[] cleanDishes;
    public int dirtyCount;
    public int cleanCount;
    public GameObject setTable1;
    public GameObject setTable2;
    public int tableSet;
    public int fullPlate;

    void Start()
    {
        dirtyDishes = new GameObject[3];
        cleanDishes = new GameObject[3];
        dirtyCount = 0;
        cleanCount = 0;
        setTable1.SetActive(false);
        setTable2.SetActive(false);
        tableSet = 0;
        fullPlate = 0;
    }

    public void AddItem(GameObject item)
    {
        if (item.GetComponent<PlateBehavior>().isClean())
        {
            if(cleanCount < 3)
            {
                cleanDishes[cleanCount] = item;
                cleanCount++;
            }
        }
        else
        {
            if(dirtyCount < 3)
            {
                dirtyDishes[dirtyCount] = item;
                dirtyCount++;
            }
        }
    }
    public void AddCleanPlate()
    {
        GameObject cleanPlate = new GameObject();
        cleanPlate.tag = "plate";
        cleanPlate.AddComponent<PlateBehavior>();
        cleanPlate.GetComponent<PlateBehavior>().setClean();
        AddItem(cleanPlate);
    }
    public int cleanDishCount()
    {
        return cleanCount;
    }
    public int dirtyDishCount()
    {
        return dirtyCount;
    }
    public void deleteDirty()
    {
        if(dirtyCount > 0)
        {
            dirtyCount--;
            dirtyDishes[dirtyCount] = null;
        }
    }
    public void deleteClean()
    {
        if(cleanCount > 0)
        {
            cleanCount--;
            cleanDishes[cleanCount] = null;
        }
    }

    public void serve()
    {
        fullPlate++;
        deleteClean();
    }

    public bool served()
    {
        if (fullPlate > 0)
            return true;
        else
            return false;
    }

    public void serveTable()
    {
        if(tableSet == 0)
        {
            deleteClean();
            setTable1.SetActive(true);
            tableSet++;
            fullPlate--;
        }
        else if(tableSet == 1)
        {
            deleteClean();
            setTable2.SetActive(true);
            tableSet++;
            fullPlate--;
        }
        else
        {
            Debug.Log("Table is already set.");
        }
    }
}
