using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeMiniPuzzle : Interactable
{
    [SerializeField] private MiniBadgePuzzle _miniBadgePuzzle;
    protected override void Interact()
    {
        _miniBadgePuzzle.count++;
        Destroy(gameObject);
    }
}
