using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public bool inventory;
<<<<<<< HEAD
    public AudioSource soundSource;
=======
>>>>>>> steven

    public void DoInteraction()
    {
        //Picked up and put in inventory
<<<<<<< HEAD
        if(tag == "washingMachine")
        {
            soundSource = GetComponent<AudioSource>();
            soundSource.Play();

        }
        else
        {
            gameObject.SetActive(false);
        }
       
=======
        gameObject.SetActive(false);
>>>>>>> steven
    }
}