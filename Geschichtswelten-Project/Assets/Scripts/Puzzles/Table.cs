using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    public string name;
    public bool isTriggered;
    public GameObject badge;
    private bool isActive;
    public int count = 0;

    private void Awake()
    {
        switch (name)
        {
            case "A":
                badge.SetActive(false);
                break;

            case "B":
                badge.SetActive(false);
                break;

            case "D":
                badge.SetActive(false);
                break;

            case "E":
                badge.SetActive(false);
                break;
            case "F":
                badge.SetActive(false);
                break;

            case "G":
                badge.SetActive(true);
                break;
            
            default:
                badge.SetActive(false);
                break;
        }
    }

    protected override void Interact()
    {
        if (!isActive)
        {
            badge.gameObject.SetActive(true);
            isActive = true;
        }
        else
        {
            badge.gameObject.SetActive(false);
            isActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Badge"))
        {
            Debug.Log(other + "hit");
            isTriggered = true;
        }
    }
}