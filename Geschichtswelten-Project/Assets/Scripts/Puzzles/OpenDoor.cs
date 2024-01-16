using System;
using NavKeypad;
using UnityEngine;
using UnityEngine.Serialization;


public class OpenDoor : Interactable
{
    [SerializeField] private Keycard Keycard;

    protected override void Interact()
    {
        if (Keycard.hasKey)
        {
            GetComponent<Animation>().Play("HangarDoor1Open");
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            promptMessage = "I might need a Keycard...";
        }
    }
}