using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject tutorialGotItButton;
    [SerializeField] private GameObject PapersUI;
    [SerializeField] private GameObject keypad;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private GameObject advancedOptions;
    private PlayerInput.PauseMenuActions playerActions;
    private PlayerInput PlayerInput;
    public bool isPaused = false;
    public bool inOptions;

    private void Awake()
    {
        PlayerInput = new PlayerInput();
        playerActions = PlayerInput.PauseMenu;
        playerActions.OpenMenu.performed += _ => DeterminePause();
        pauseMenu.SetActive(false);
        //gameUI.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    public void DeterminePause()
    {
        if (!isPaused)
            Pause();
        else
            Unpause();
    }

    public void EXITGAME()
    {
        Application.Quit();
    }

    public void SwitchtoMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    private void Unpause()
    {
        if (tutorialText.activeSelf)
        {
            tutorialText.SetActive(false);
        }
        if (cutscene.gameObject.activeSelf)
        {
            advancedOptions.SetActive(false);
            pauseMenu.SetActive(false);
            OptionsMenu.SetActive(false);
            isPaused = false;
            return;
        }

        if (PapersUI.gameObject.activeSelf)
        {
            advancedOptions.SetActive(false);
            pauseMenu.SetActive(false);
            OptionsMenu.SetActive(false);
            isPaused = false;
            return;
        }

        if (keypad.gameObject.activeSelf)
        {
            advancedOptions.SetActive(false);
            pauseMenu.SetActive(false);
            OptionsMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
            return;
        }

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        advancedOptions.SetActive(false);
        gameUI.SetActive(true);
        isPaused = false;
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        gameUI.SetActive(false);
        isPaused = true;
    }

    public void CloseOptions()
    {
        OptionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void OpenOptions()
    {
        //gameUI.SetActive(false);
        pauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void CloseAdvancedOptions()
    {
        if (advancedOptions.activeSelf)
        {
            advancedOptions.SetActive(false);
            OptionsMenu.SetActive(true);
        }
    }

    public void OpenAdvancedOptions()
    {
        if (OptionsMenu.activeSelf)
        {
            OptionsMenu.SetActive(false);
            advancedOptions.SetActive(true);
        }
    }

    public void OpenTutorialPage()
    {
        tutorialText.SetActive(true);
        tutorialGotItButton.SetActive(true);
    }
    public void CloseTutorialPage()
    {
        tutorialText.SetActive(false);
        tutorialGotItButton.SetActive(false);
    }
}