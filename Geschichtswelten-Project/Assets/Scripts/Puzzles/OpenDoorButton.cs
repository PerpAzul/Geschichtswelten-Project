using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : Interactable
{
    [SerializeField] private GameObject button;
    
    protected override void Interact()
    {
        button.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
