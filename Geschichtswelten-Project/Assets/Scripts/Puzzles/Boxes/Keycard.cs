using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Interactable
{
    [SerializeField] private BoxOpen Open;
    public bool switchCard;
    

    protected override void Interact()
    {
        
        Destroy(gameObject);
        switchCard = true;
        Open.hasKey = true;
        
    }
}
