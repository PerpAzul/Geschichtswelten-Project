using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractWithKeypad : Interactable
{
    public CinemachineVirtualCamera _KeypadCam;
    public CinemachineVirtualCamera mainCamera;
    public GameObject Weapons;
    public GameObject hitMarker;
    public GameObject player;
    public bool stopDoor;

    private void Awake()
    {
        _KeypadCam.enabled = false;
    }

    public void ReeenableBoxCollider()
    {
        GetComponent<BoxCollider>().enabled = true;
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
    }

    protected override void Interact()
    {
        _KeypadCam.enabled = true;
        mainCamera.enabled = false;
        Weapons.gameObject.SetActive(false);
        hitMarker.gameObject.SetActive(false);
        _KeypadCam.Priority = 1;
        mainCamera.Priority = 0;
        player.gameObject.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
    }
}