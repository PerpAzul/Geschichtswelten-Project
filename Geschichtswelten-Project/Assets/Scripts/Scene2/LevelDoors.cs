using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoors : Interactable
{
    [SerializeField] private KeycardScene2 keycard;
    [SerializeField] private int index;
    [SerializeField] private String color;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _audioClip;

    protected override void Interact()
    {
        if (keycard.hasKey && keycard.upgradeIndex >= index)
        {
            _audio.PlayOneShot(_audioClip);
            GetComponent<Animation>().Play("HangarDoor1Open");
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            promptMessage = "I need a " + color + " level Keycard";
        }
    }

    public void OpenDoor()
    {
        _audio.PlayOneShot(_audioClip);
        GetComponent<Animation>().Play("HangarDoor1Open");
    }
    
    public void CloseDoor()
    {
        _audio.PlayOneShot(_audioClip);
        GetComponent<Animation>().Play("HangarDoor1Close");
    }
    
}
