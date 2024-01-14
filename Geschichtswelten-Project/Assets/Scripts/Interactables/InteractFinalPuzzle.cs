using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFinalPuzzle : Interactable
{
    public GameObject panel;
    
    protected override void Interact()
    {
        panel.GetComponent<BoxCollider>().enabled = false;
    }
}
