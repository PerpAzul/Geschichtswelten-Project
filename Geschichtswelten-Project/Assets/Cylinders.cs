using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinders : Interactable
{
    public bool isOn;

    protected override void Interact()
    {
        isOn = true;
    }
}
