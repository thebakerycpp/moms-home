using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDishBehavior : MonoBehaviour
{
    public GameObject[] dirtyDishes = new GameObject[3];
    int dishCount;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < dirtyDishes.Length; i++)
        {
            dirtyDishes[i].SetActive(false);
        }
        dishCount = -1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDish()
    {
        if(dishCount < 2)
        {
            dishCount++;
            dirtyDishes[dishCount].SetActive(true);
        }
    }

    public void removeDish()
    {
        dirtyDishes[dishCount].SetActive(false);
        dishCount--;
    }

    public int dirtyDishCount()
    {
        return dishCount + 1;
    }
}
