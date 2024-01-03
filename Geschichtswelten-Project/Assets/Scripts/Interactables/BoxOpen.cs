using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxOpen : Interactable
{
    public bool hasKey;
    public GameObject Box;

    protected override void Interact()
    {
        promptMessage = "I might need a Key for this...";
        if (hasKey)
        {
            promptMessage = "";
            Debug.Log("Opening");
            Box.GetComponent<Animation>().Play("Crate_Open");
            Box.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            Debug.Log("No Key");
        }
    }
}