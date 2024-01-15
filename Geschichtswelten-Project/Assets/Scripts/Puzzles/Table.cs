using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    public string name;
    public bool isTriggered;
    public GameObject badge;
    private bool isActive;

    private void Awake()
    {
        
    }

    protected override void Interact()
    {
        if (!isActive)
        {
            badge.gameObject.SetActive(true);
            isActive = true;
        }
        else
        {
            badge.gameObject.SetActive(false);
            isActive = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Badge"))
        {
            isTriggered = true;
        }
    }
}