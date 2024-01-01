using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxOpen : Interactable
{
    public bool hasKey;
    public GameObject Box;

    public void OpenBox()
    {
        if (hasKey)
        {
            Box.GetComponent<Animation>().Play("Crate_Open");
        }
    }
   
}