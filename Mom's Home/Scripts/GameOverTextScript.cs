using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTextScript : MonoBehaviour
{
    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        if (choresDone())
        {
            gameOverText.text = "Congratulations!\nYou were able to complete all your chores before your mom came back and succeeded in not getting beaten!";
        }
        else
        {
            gameOverText.text = "Your mom came back home, and you didn't finish all your chores :(\nYour butt is sore from all the beating.";
        }
    }

    //returns true if all chores were finished on time, false otherwise.
    bool choresDone()
    {
        //add logic here
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
