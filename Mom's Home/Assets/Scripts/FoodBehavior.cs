using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    public GameObject ingredient;
    public PotInteraction cookingPot;

    // Start is called before the first frame update
    void Start()
    {
        if (ingredient.name == "Fish")
            ingredient.SetActive(true);
        else
            ingredient.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
