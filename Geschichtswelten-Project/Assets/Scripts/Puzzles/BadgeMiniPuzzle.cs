using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BadgeMiniPuzzle : Interactable
{
    [SerializeField] private MiniBadgePuzzle _miniBadgePuzzle;
    [SerializeField] private TextMeshProUGUI text;
    protected override void Interact()
    {
        _miniBadgePuzzle.count++;
        text.text = "Badges: " + _miniBadgePuzzle.count; 
        Destroy(gameObject);
    }
}
