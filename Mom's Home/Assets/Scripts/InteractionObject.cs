using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public bool inventory;
    public AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    
    public void DoInteraction()
    {
        if (tag == "washingMachine")
        {
            audiosource.Play();
        }
        else
        {
            gameObject.SetActive(false);
        }
        //Picked up and put in inventory
        
    }
}