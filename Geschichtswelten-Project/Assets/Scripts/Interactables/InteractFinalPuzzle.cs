using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFinalPuzzle : Interactable
{
    public GameObject panel;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip clip;
    
    protected override void Interact()
    {
        AudioSource.PlayOneShot(clip);
        panel.GetComponent<BoxCollider>().enabled = false;
    }
}
