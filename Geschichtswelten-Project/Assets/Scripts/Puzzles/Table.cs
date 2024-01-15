using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    public string name;
    private bool isActive;
    public GameObject badge;
    [SerializeField] private BadgePuzzle _badgePuzzle;

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

    public void DisableBadge()
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
        if (_badgePuzzle.count != 0)
        {
            badge.gameObject.SetActive(true);
            _badgePuzzle.count--;
            isActive = true;
        }
        else
        {
            badge.gameObject.SetActive(false);
            _badgePuzzle.count++;
            isActive = false;
        }
    }
    
}