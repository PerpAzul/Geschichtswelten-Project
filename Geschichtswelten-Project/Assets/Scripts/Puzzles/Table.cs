using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    public string name;
    public bool isTriggered;

    protected override void Interact()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Badge"))
        {
            isTriggered = true;
        }
    }
}