using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public bool on;
    public bool off;
    
    void Start()
    {
        off = true;
        on = false;
        flashlight.SetActive(false);
    }

    public void Flash()
    {
        if (off)
        {
            flashlight.SetActive(true);
            off = false;
            on = true;
            return;
        } 
        else if (on)
        {
            flashlight.SetActive(false);
            off = true;
            on = false;
        }
    }
}
