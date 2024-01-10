using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    [SerializeField] private SimonSays game;
    [SerializeField] private AudioSource generalAudioSource;
    [SerializeField] private AudioClip buttonSound;
    public SimonSays.Colors Colors;
    public bool pressed = false;

    protected override void Interact()
    {
        StartCoroutine(DoInteract());
    }

    IEnumerator DoInteract()
    {
        game.playersInput.Add(Colors);
        pressed = true;
        GetComponent<Renderer>().enabled = false;
        generalAudioSource.PlayOneShot(buttonSound);
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < game.playersInput.Count; i++)
        {
            Debug.Log(game.playersInput[i]);
        }

        GetComponent<Renderer>().enabled = true;
        pressed = false;
    }

    public void ApplyNewColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    public void DeactivateRenderer()
    {
        GetComponent<Renderer>().enabled = false;
    }
    public void ActivateRenderer()
    {
        GetComponent<Renderer>().enabled = true;
    }
}