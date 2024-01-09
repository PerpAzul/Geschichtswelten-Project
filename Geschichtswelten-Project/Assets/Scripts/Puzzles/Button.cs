using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    [SerializeField] private SimonSays game;
    public SimonSays.Colors Colors;
    public bool pressed = false;

    protected override void Interact()
    {
        StartCoroutine(DoInteract());
    }

    IEnumerator DoInteract()
    {
        game.playersInput.Add((int)Colors);
        pressed = true;
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < game.playersInput.Count; i++)
        {
            Debug.Log(game.playersInput[i]);
        }

        GetComponent<Renderer>().enabled = true;
        pressed = false;
    }
}