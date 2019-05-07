using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public bool inventory;
    public AudioSource soundSource;

    public void DoInteraction()
    {
        //Picked up and put in inventory
        if(tag == "washingMachine")
        {
            soundSource = GetComponent<AudioSource>();
            soundSource.Play();
        }
        else
        {
            gameObject.SetActive(false);
        }
       
    }
}