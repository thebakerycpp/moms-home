using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    public ClothesInventory clothesInventory;
    public KitchenInventory kitchenwareInventory;
    public FoodInventory foodInventory;
    public PotInteraction cookingPot;
    public PlateInventory plateInventory;
    public AudioSource soundSource;

    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            if (currentInterObjScript.inventory && currentInterObj.CompareTag("kitchenware"))
            {
                kitchenwareInventory.AddItem(currentInterObj);
                soundSource.Play();
                Debug.Log("Kitchenware picked up");
                currentInterObj.SendMessage("DoInteraction");
            }

            else if (currentInterObjScript.inventory && currentInterObj.CompareTag("clothes"))
            {
                clothesInventory.AddItem(currentInterObj);
                soundSource.Play();
                Debug.Log("Clothes picked up");
                currentInterObj.SendMessage("DoInteraction");
            }
            else if (currentInterObjScript.inventory && currentInterObj.CompareTag("ingredient"))
            {
                foodInventory.AddItem(currentInterObj);
                soundSource.Play();
                Debug.Log("Ingredient picked up");
                currentInterObj.SendMessage("DoInteraction");
            }
            else if (currentInterObjScript.inventory && currentInterObj.CompareTag("plate"))
            {
                plateInventory.AddItem(currentInterObj);
                soundSource.Play();
                Debug.Log("Plate picked up");
                currentInterObj.SendMessage("DoInteraction");
            }
            else if (currentInterObj.CompareTag("washingMachine"))
            {
                Debug.Log("This is a washing machine, cannot be picked up");
                int count = clothesInventory.inventoryCount();
                if (count < 5)
                {
                    Debug.Log("You need to have at least 5 pieces of clothing to be optimal");
                }
                else
                {
                    Debug.Log("Deposited clothes in washing machine, this will take some time...");
                    for (int i = 0; i < 5; i++)
                    {
                        clothesInventory.deleteItem();
                    }
                }
            }
            else if (currentInterObj.CompareTag("cookingPot"))
            {
                int count = foodInventory.inventoryCount();
                if (count == 0 && cookingPot.cooked() == false)
                {
                    Debug.Log("You need an ingredient to cook with.");
                }
                else if (count == 0 && cookingPot.cooked() == true)
                {
                    int plateCount = plateInventory.inventoryCount();
                    if(plateCount == 0)
                        Debug.Log("Food is ready to serve. Get a CLEAN plate.");
                    else
                    {
                        plateInventory.serve();
                        cookingPot.serve();
                    }
                }
                else
                {
                    Debug.Log("Cooking food, this will take some time...");
                    foodInventory.deleteItem();
                    cookingPot.startTimer();
                }
            }
            else if (currentInterObj.CompareTag("table"))
            {
                if (plateInventory.inventoryCount() == 0)
                    Debug.Log("Get a plate with some food.");
                else
                {
                    if (plateInventory.served())
                    {
                        plateInventory.serveTable();
                    }
                }
            }
            else
            {
                inventory.AddItem(currentInterObj);
                soundSource.Play();
                currentInterObj.SendMessage("DoInteraction");
            }

            currentInterObj = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject") || other.CompareTag("clothes") || other.CompareTag("kitchenware") || other.CompareTag("ingredient")
            || other.CompareTag("plate") || other.CompareTag("table"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
        else if (other.CompareTag("washingMachine") || other.CompareTag("cookingPot"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
            other.isTrigger = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject") || other.CompareTag("clothes") || other.CompareTag("kitchenware") || other.CompareTag("ingredient")
            || other.CompareTag("plate") || other.CompareTag("table"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }
        other.isTrigger = true;
    }
}
