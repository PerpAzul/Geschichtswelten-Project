using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpenScene2 : MonoBehaviour
{
    public int index;
    public GameObject Box;

    void Awake()
    {
        index = 0;
    }
    

    public void IncrementIndex()
    {
        index++;

        if (index == 3)
        {
            Box.GetComponent<Animation>().Play("Crate_Open");
            Box.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
