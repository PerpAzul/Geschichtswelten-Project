using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Interactable
{
    [SerializeField] private BoxOpen Open;
    protected override void Interact()
    {
        Destroy(gameObject);
        Open.hasKey = true;
        
    }
}
