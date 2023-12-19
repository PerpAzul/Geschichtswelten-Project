using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;

    private void Awake()
    {
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
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
        OptionMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void CloseOptions()
    {
        OptionMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    
}
