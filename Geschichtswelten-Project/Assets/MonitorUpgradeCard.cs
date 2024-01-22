using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorUpgradeCard : Interactable
{
    [SerializeField] private KeycardScene2 _keycardScene2;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip _clip;
    
    protected override void Interact()
    {
        if (_keycardScene2.hasKey)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            promptMessage = "I need a Keycard for this";
        }
    }
    

    public void EnableBoxCollider()
    {
        AudioSource.PlayOneShot(_clip);
        GetComponent<BoxCollider>().enabled = true;
    }
}