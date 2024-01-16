using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : Interactable
{
    [SerializeField] private BadgePuzzle _badgePuzzle;

    protected override void Interact()
    {
        _badgePuzzle.count++;
        _badgePuzzle.count2++;
        Destroy(gameObject);
    }
}