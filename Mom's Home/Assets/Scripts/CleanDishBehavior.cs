using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDishBehavior : MonoBehaviour
{
    public GameObject[] cleanDishes = new GameObject[3];
    int dishCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cleanDishes.Length; i++)
        {
            cleanDishes[i].SetActive(false);
        }
        dishCount = -1;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addDish()
    {
        if (dishCount < 2)
        {
            dishCount++;
            cleanDishes[dishCount].SetActive(true);
        }
    }

    public void removeDish()
    {
        cleanDishes[dishCount].SetActive(false);
        dishCount--;
    }

    public int cleanDishCount()
    {
        return dishCount + 1;
    }
}
