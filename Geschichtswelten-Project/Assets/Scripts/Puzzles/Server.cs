using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : Interactable
{
    public ServerColors color;
    [SerializeField] private ServerPuzzle _serverPuzzle;

    private void Start()
    {
        switch (color)
        {
            case ServerColors.Red:
                promptMessage = "Red";
                break;
            case ServerColors.Blue:
                promptMessage = "Blue";
                break;
            case ServerColors.Green:
                promptMessage = "Green";
                break;
            case ServerColors.Yellow:
                promptMessage = "Yellow";
                break;
            case ServerColors.Red2:
                promptMessage = "Red";
                break;
            case ServerColors.Blue2:
                promptMessage = "Blue";
                break;
            case ServerColors.Green2:
                promptMessage = "Green";
                break;
            case ServerColors.Yellow2:
                promptMessage = "Yellow";
                break;
            case ServerColors.White:
                promptMessage = "White";
                break;
            case ServerColors.Pink:
                promptMessage = "Pink";
                break;
            case ServerColors.LightBlue:
                promptMessage = "Light Blue";
                break;
        }
    }

    protected override void Interact()
    {
        StartCoroutine(DoInteract());
    }

    IEnumerator DoInteract()
    {
        _serverPuzzle.playerInput.Add(color);
        GetComponentInChildren<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        GetComponentInChildren<MeshRenderer>().enabled = true;
    }
}