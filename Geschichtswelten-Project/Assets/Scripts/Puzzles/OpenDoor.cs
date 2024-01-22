using System;
using NavKeypad;
using UnityEngine;
using UnityEngine.Serialization;


public class OpenDoor : Interactable
{
    [SerializeField] private Keycard Keycard;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip _clip;
    protected override void Interact()
    {
        if (Keycard.hasKey)
        {
            GetComponent<Animation>().Play("HangarDoor1Open");
            GetComponent<BoxCollider>().enabled = false;
            AudioSource.PlayOneShot(_clip);
        }
        else
        {
            promptMessage = "I might need a Keycard...";
        }
    }
}