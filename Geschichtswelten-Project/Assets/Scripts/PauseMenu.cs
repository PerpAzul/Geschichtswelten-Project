using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject OptionsMenu;
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
        gameUI.SetActive(true);
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

    private void Unpause()
    {
        
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        gameUI.SetActive(true);
        isPaused = false;
    }

    private void Pause()
    {
        
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
}