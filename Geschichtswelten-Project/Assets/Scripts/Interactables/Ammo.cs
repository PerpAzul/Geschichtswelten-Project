using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Interactable
{
    //design interaction 
    protected override void Interact()
    {
        Destroy(gameObject);
    }
}
