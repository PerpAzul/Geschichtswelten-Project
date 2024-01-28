using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<GameObject> scenes = new List<GameObject>();
    [SerializeField] private GameObject lvl2Button;

    private void Awake()
    {
        if (!Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            return;
        }
        
        scenes[0].SetActive(true);
        scenes[1].SetActive(false);
        scenes[2].SetActive(false);
        scenes[4].SetActive(false);
    }

    public void StartGame()
    {
        if (PlayerPrefs.HasKey("TutorialDone"))
        {
            SceneManager.LoadScene("DarkUnderground_Setup");
        }
        else
        {
            OpenTutorial();
        }
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
        //disable lvl2 if lvl isn't completed yet
        if (PlayerPrefs.HasKey("CompletedLvl1") && PlayerPrefs.GetInt("CompletedLvl1") == 1)
        {
            lvl2Button.SetActive(true);
        }
        else
        {
            lvl2Button.SetActive(false);
        }
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
        if (PlayerPrefs.HasKey("TutorialDone"))
        {
            SceneManager.LoadScene("DarkUnderground_Setup");
        }
        else
        {
            OpenTutorial();
        }
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

    public void OpenTutorial()
    {
        scenes[0].SetActive(false);
        scenes[1].SetActive(false);
        scenes[2].SetActive(false);
        scenes[4].SetActive(true);
    }
    public void CloseTutorial()
    {
        scenes[4].SetActive(false);
        PlayerPrefs.SetInt("TutorialDone", 1);
        StartGame();
    }
}