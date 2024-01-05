using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class InteractWithKeypad : Interactable
{
    public CinemachineVirtualCamera _KeypadCam;
    public CinemachineVirtualCamera mainCamera;
    public GameObject Weapons;
    public GameObject hitMarker;
    public GameObject player;

    [SerializeField] private GameObject Text;
    //public GameObject UI;
    private bool isInKeyPad;

    private void Awake()
    {
        _KeypadCam.enabled = false;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && isInKeyPad)
        {
            SwitchToMainCamera();
        }
    }

    public void SwitchToMainCamera()
    {
        mainCamera.enabled = true;
        _KeypadCam.enabled = false;
        _KeypadCam.Priority = 0;
        mainCamera.Priority = 1;
        hitMarker.gameObject.SetActive(true);
        Weapons.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        _KeypadCam.GetComponent<Camera>().enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        promptMessage = "Keypad";
        Text.SetActive(true);
        isInKeyPad = false;
        GetComponent<BoxCollider>().enabled = true;
    }

    protected override void Interact()
    {
        _KeypadCam.Priority = 1;
        mainCamera.Priority = 0;
        _KeypadCam.enabled = true;
        _KeypadCam.GetComponent<Camera>().enabled = true;
        mainCamera.enabled = false;
        Weapons.gameObject.SetActive(false);
        hitMarker.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        promptMessage = "";
        Text.SetActive(false);
        isInKeyPad = true;
        //UI.gameObject.SetActive(false);
    }
}