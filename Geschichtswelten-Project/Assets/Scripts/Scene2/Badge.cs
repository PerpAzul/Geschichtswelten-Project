using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Badge : Interactable
{
    [SerializeField] private BadgePuzzle _badgePuzzle;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    public int count = 0;

    protected override void Interact()
    {
        textMeshPro.gameObject.SetActive(true);
        _badgePuzzle.count++;
        textMeshPro.text = "Badges: " + _badgePuzzle.count;
        Destroy(gameObject);
    }
}