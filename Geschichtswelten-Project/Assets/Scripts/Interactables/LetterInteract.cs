using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LetterInteract : Interactable
{
    [SerializeField] private TextMeshProUGUI textToUpdate;
    [SerializeField] private GameObject gameUI;
    public GameObject Text;
    private bool NomorePaper = false;

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
            NomorePaper = true;
            Time.timeScale = 0;
            Debug.Log("in");
        }
        else
        {
            gameUI.SetActive(true);
            Text.SetActive(false);
            NomorePaper = false;
            Time.timeScale = 1;
            Debug.Log("out");
        }
    }
}