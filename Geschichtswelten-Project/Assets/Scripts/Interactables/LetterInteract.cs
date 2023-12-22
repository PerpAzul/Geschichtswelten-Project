using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterInteract : Interactable
{
    [SerializeField] private TextMeshProUGUI textToUpdate;
    public GameObject gameUI;
    public GameObject Text;
    private bool NomorePaper;
    public GameObject Player;

    private void Awake()
    {
        Text.SetActive(false);
    }

    protected override void Interact()
    {
        if (!NomorePaper)
        {
            gameUI.SetActive(false);
            Text.SetActive(true);
            textToUpdate.text = "TEstytesty";
            NomorePaper = true;
            Time.timeScale = 0;
        }
        else
        {
            gameUI.SetActive(true);
            Text.SetActive(false);
            NomorePaper = false;
            Time.timeScale = 1;
        }
    }
}