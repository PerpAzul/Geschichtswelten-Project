using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Interactable
{
    public bool hasKey = false;

    protected override void Interact()
    {
        Destroy(gameObject);
        hasKey = true;
    }
}