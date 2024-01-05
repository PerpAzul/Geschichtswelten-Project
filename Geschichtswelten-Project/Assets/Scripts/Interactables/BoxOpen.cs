using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxOpen : Interactable
{
    [SerializeField] private Keycard _keycard;
    public GameObject Box;

    protected override void Interact()
    {
        
        if (_keycard.hasKey)
        {
            promptMessage = "";
            Debug.Log("Opening");
            Box.GetComponent<Animation>().Play("Crate_Open");
            Box.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            promptMessage = "I might need a Keycard for this";
        }
    }
}