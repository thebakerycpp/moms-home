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
    public AudioSource soundSource;

    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            if(currentInterObjScript.inventory && currentInterObj.CompareTag("kitchenware"))
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
                    for(int i = 0; i < 5; i++)
                    {
                        clothesInventory.deleteItem();
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
        if (other.CompareTag("interObject") || other.CompareTag("clothes") || other.CompareTag("kitchenware"))
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
        if (other.CompareTag("interObject") || other.CompareTag("clothes") || other.CompareTag("kitchenware"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }
        other.isTrigger = true;
    }
}
