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
    public DirtyDishBehavior dirtyDishes;
    public CleanDishBehavior cleanDishes;
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
                    int plateCount = plateInventory.cleanDishCount();
                    if(plateCount == 0)
                        Debug.Log("Food is ready to serve. Get a CLEAN plate.");
                    else
                    {
                        Debug.Log(plateCount);
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
                if (plateInventory.served())
                    plateInventory.serveTable();
                else
                    Debug.Log("Get a plate of food");
            }
            else if (currentInterObj.CompareTag("dirtyDishes"))
            {
                if (plateInventory.dirtyDishCount() == 0)
                {
                    Debug.Log("Find some dirty dishes.");
                }
                else
                {
                    dirtyDishes.addDish();
                    plateInventory.deleteDirty();
                }
            }
            else if (currentInterObj.CompareTag("sink"))
            {
                if (dirtyDishes.dirtyDishCount() == 0)
                {
                    Debug.Log("Place some dirty dishes on the counter.");
                }
                else
                {
                    dirtyDishes.removeDish();
                    cleanDishes.addDish();
                }
            }
            else if (currentInterObj.CompareTag("cleanDishes"))
            {
                if(cleanDishes.cleanDishCount() == 0)
                {
                    Debug.Log("No clean dishes.");
                }
                else
                {
                    cleanDishes.removeDish();
                    plateInventory.AddCleanPlate();
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
            || other.CompareTag("plate") || other.CompareTag("table") || other.CompareTag("cookingPot") || other.CompareTag("dirtyDishes")
            || other.CompareTag("sink") || other.CompareTag("cleanDishes"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
        else if (other.CompareTag("washingMachine"))
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
            || other.CompareTag("plate") || other.CompareTag("table") || other.CompareTag("dirtyDishes") || other.CompareTag("sink")
            || other.CompareTag("cleanDishes"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }
        other.isTrigger = true;
    }
}
