using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{
    bool clean;
    // Start is called before the first frame update
    void Start()
    {
        clean = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setClean()
    {
        clean = true;
    }

    public bool isClean()
    {
        return clean;
    }
}
