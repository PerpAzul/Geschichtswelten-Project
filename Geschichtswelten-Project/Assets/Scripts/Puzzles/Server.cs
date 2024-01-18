using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : Interactable
{
    public ServerColors color;
    [SerializeField] private ServerPuzzle _serverPuzzle;

    private void Awake()
    {
        promptMessage = color.ToString();
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