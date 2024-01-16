using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : Interactable
{
    [SerializeField] private BadgePuzzle _badgePuzzle;
    public int count = 0;

    protected override void Interact()
    {
        _badgePuzzle.count++;
        Destroy(gameObject);
    }
}