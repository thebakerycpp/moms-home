using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float startTime;
    float currentTime;
    public float lowTime; //time at which the text color changes to red, as to show urgency
    public Text countdownText;
    bool soundAlreadyPlayed;

    // Start is called before the first frame update
    void Start()
    {
        soundAlreadyPlayed = false;
        currentTime = startTime + 1; //the +1 makes it actually start at startTime       
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if(currentTime >= 60)
            countdownText.text = "Time until mom's home:\n" + ((int)currentTime / 60).ToString() + ":" + (((int)currentTime % 60 < 10) ? "0" : "") + ((int)currentTime % 60).ToString();
        else
            countdownText.text = "Time until mom's home:\n" + ((int)currentTime).ToString() + "s";

        if (currentTime <= lowTime)
        {
            //play a sound?
            if (!soundAlreadyPlayed)
            {
                soundAlreadyPlayed = true;
                AudioSource audio = gameObject.AddComponent<AudioSource>();
                audio.PlayOneShot((AudioClip)Resources.Load("woopwoop"));
            }
            countdownText.color = Color.red;
        }
        if(currentTime < 0)
        {
            //change scene to show game over?
            SceneManager.LoadScene("GameOverScene");
        }
    }
}