﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;


    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            Debug.Log("There was an interact for " + currentInterObj);
            if (currentInterObjScript.inventory)
            {
                Debug.Log("There was an interact for " + currentInterObj);
                inventory.AddItem(currentInterObj);             
            }
            currentInterObj.SendMessage("DoInteraction");
            currentInterObj = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }
    }
}
