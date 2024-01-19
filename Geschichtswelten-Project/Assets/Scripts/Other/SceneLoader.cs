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

    public void StartGame()
    {
        SceneManager.LoadScene("DarkUnderground_Setup");
    }
    public void OpenAdvancedSettings()
    {
        scenes[2].SetActive(false);
        scenes[3].SetActive(true);
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

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("DarkUnderground_Setup");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("scene_lightsOff");
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

    public void CloseAdvancedSettings()
    {
        scenes[3].SetActive(false);
        scenes[2].SetActive(true);
    }
}