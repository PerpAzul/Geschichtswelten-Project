using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<GameObject> scenes = new List<GameObject>();

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            return;
        }

        scenes[0].SetActive(true);
        scenes[1].SetActive(false);
        scenes[2].SetActive(false);
    }

    public void OpenLevelSelecter()
    {
        scenes[0].SetActive(false);
        scenes[1].SetActive(true);
    }

    public void CloseLevelSelecter()
    {
        scenes[0].SetActive(true);
        scenes[1].SetActive(false);
        scenes[2].SetActive(false);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Jorge Scene");
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        scenes[0].SetActive(false);
        scenes[1].SetActive(false);
        scenes[2].SetActive(true);
    }

    public void CloseOptions()
    {
        scenes[0].SetActive(true);
        scenes[1].SetActive(false);
        scenes[2].SetActive(false);
    }
}