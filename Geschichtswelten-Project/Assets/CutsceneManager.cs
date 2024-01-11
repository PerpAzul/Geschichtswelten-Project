using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject Scene1;
    [SerializeField] private CanvasGroup Scene1CanvasGroup;
    [SerializeField] private GameObject Scene2;
    [SerializeField] private CanvasGroup Scene2Picture1CanvasGroup;
    [SerializeField] private CanvasGroup Scene2Picture2CanvasGroup;
    [SerializeField] private CanvasGroup Scene2Picture3CanvasGroup;
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

    private void LateUpdate()
    {
        switch (index)
        {
            case 0:
                Scene1CanvasGroup.alpha += 0.01f;
                break;
            case 1:
                Scene2Picture1CanvasGroup.alpha += 0.01f;
                break;
            case 2:
                Scene2Picture2CanvasGroup.alpha += 0.01f;
                break;
            case 3:
                Scene2Picture3CanvasGroup.alpha += 0.01f;
                break;
            default:
                return;
        }
    }


    public void Skip()
    {
        switch (index)
        {
            case 0:
                Scene1.gameObject.SetActive(false);
                Scene2.gameObject.SetActive(true);
                index++;
                break;
            case 1:
                index++;
                break;
            case 2:
                index++;
                break;
            case 3:
                Scene2.gameObject.SetActive(false);
                Cutscene.gameObject.SetActive(false);
                gameUI.SetActive(true);
                Time.timeScale = 1;
                index++;
                break;
            default:
                return;
        }
    }
}