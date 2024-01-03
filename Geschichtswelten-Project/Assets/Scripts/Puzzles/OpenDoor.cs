using System;
using NavKeypad;
using UnityEngine;
using UnityEngine.Serialization;


public class OpenDoor : Interactable
{
    [SerializeField] private Keycard Keycard;

    protected override void Interact()
    {
        if (Keycard.switchCard)
        {
            GetComponent<Animation>().Play("HangarDoor1Open");
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}