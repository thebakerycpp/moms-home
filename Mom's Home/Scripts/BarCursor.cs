using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarCursor : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed,0,0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = -speed;
        }
    }
}
