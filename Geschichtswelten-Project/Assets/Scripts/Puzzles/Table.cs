using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Table : Interactable
{
    public string name;
    public GameObject badge;
    [SerializeField] private BadgePuzzle _badgePuzzle;
    [SerializeField] private MiniBadgePuzzle _badgeMiniPuzzle;
    [SerializeField] private TextMeshProUGUI text;
    private bool hasBadge;
    private bool minihasBadge;
    public int puzzle = 0;

    private void Awake()
    {
        if (puzzle == 0)
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
        else
        {
            badge.SetActive(false);
        }
    }

    protected override void Interact()
    {
        if (puzzle == 0)
        {
            if (!hasBadge)
            {
                if (_badgePuzzle.count != 0)
                {
                    promptMessage = "Take Badge";
                    badge.SetActive(true);
                    hasBadge = true;
                    _badgePuzzle.count--;
                    if (_badgePuzzle.count == 0)
                    {
                        text.text = "";
                    }
                    else
                    {
                        text.text = "Badges: " + _badgePuzzle.count;
                    }
                }
            }
            else
            {
                promptMessage = "Place Badge";
                badge.SetActive(false);
                hasBadge = false;
                _badgePuzzle.count++;
                text.text = "Badges: " + _badgePuzzle.count;
            }
        }
        else if (puzzle == 1)
        {
            if (!minihasBadge)
            {
                if (_badgeMiniPuzzle.count != 0)
                {
                    promptMessage = "Take Badge";
                    badge.SetActive(true);
                    minihasBadge = true;
                    _badgeMiniPuzzle.count--;
                    if (_badgeMiniPuzzle.count == 0)
                    {
                        text.text = "";
                    }
                    else
                    {
                        text.text = "MiniBadge: " + _badgeMiniPuzzle.count;
                    }
                }
            }
            else
            {
                promptMessage = "Place Badge";
                badge.SetActive(false);
                minihasBadge = false;
                _badgeMiniPuzzle.count++;
                text.text = "MiniBadge: " + _badgeMiniPuzzle.count;
            }
        }
    }
}