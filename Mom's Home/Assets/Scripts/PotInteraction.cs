using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotInteraction : MonoBehaviour
{
    public int itemCount;
    public int timer;
    public int servings = 0;
    public bool cooking;
    public GameObject[] ingredients = new GameObject[5];
    public bool foodReady;
    public Sprite fullPot;
    public Sprite emptyPot;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        itemCount = 0;
        timer = 0;
        cooking = false;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer--;
        else if (timer == 0 && cooking)
        {
            //play sound
            itemCount++;
            cooking = false;
            if(itemCount < 5)
            {
                ingredients[itemCount].SetActive(true);
                sr.sprite = emptyPot;
            }
            else
            {
                foodReady = true;
                sr.sprite = fullPot;
                servings = 2;
            }
        }
        else
            cooking = false;

    }

    public void startTimer()
    {
        timer = 10;
        cooking = true;
        sr.sprite = fullPot;
    }

    public int getCount()
    {
        return itemCount;
    }

    public bool cooked()
    {
        return foodReady;
    }

    public void serve()
    {
        servings--;
        if (servings == 0)
            sr.sprite = emptyPot;
    }
}
