using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScene2 : Interactable
{
    [SerializeField] private AudioSource generalAudioSource;
    [SerializeField] private AudioClip _audio;
    [SerializeField] private MiniSimonSays _miniSimonSays;
    private string tempText;
    protected override void Interact()
    {
        StartCoroutine(DoInteract());
    }

    IEnumerator DoInteract()
    {
        GetComponent<Renderer>().enabled = false;
        generalAudioSource.PlayOneShot(_audio);
        _miniSimonSays.input.Add(GetComponent<Interactable>().promptMessage);
        yield return new WaitForSeconds(0.3f);
        GetComponent<Renderer>().enabled = true;
    }

    public void AddInteractText()
    {
        promptMessage = tempText;
    }
    public void RemoveInteractText()
    {
        tempText = promptMessage;
        promptMessage = "";
    }

    public void DisableBoxCollider()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    public void EnableBoxCollider2()
    {
        GetComponent<BoxCollider>().enabled = true;
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
