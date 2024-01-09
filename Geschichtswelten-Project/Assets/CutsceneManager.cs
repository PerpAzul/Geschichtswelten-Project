using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject Scene1;
    [SerializeField] private GameObject Scene2;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject Cutscene;
    private int index = 0;
    private void Awake()
    {
        Time.timeScale = 0;
        gameUI.gameObject.SetActive(false);
        Cutscene.gameObject.SetActive(true);
        Scene1.gameObject.SetActive(true);
        Scene2.gameObject.SetActive(false);
        
    }


    public void Skip()
    {
        if (index == 0)
        {
            Scene1.gameObject.SetActive(false);
            Scene2.gameObject.SetActive(true);
            index++;
        }
        else
        {
            Scene2.gameObject.SetActive(false);
            Cutscene.gameObject.SetActive(false);
            gameUI.SetActive(true);
            Time.timeScale = 1;
        }
       
    }
}