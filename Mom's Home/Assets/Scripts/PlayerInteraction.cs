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

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            if(currentInterObjScript.inventory && currentInterObj.CompareTag("kitchenware"))
            {
                kitchenwareInventory.AddItem(currentInterObj);
                Debug.Log("Kitchenware picked up");
            }

            else if (currentInterObjScript.inventory && currentInterObj.CompareTag("clothes"))
            {
                clothesInventory.AddItem(currentInterObj);
                Debug.Log("Clothes picked up");
            }

            else
            {
                inventory.AddItem(currentInterObj);
            }
            currentInterObj.SendMessage("DoInteraction");
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
    }
}
