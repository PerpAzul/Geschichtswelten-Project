using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerGun : MonoBehaviour
{
    private GunInput gunInput;
    private GunInput.GunActions gunActions;
    
    private Shooting shoot;

    void Awake()
    {
        gunInput = new GunInput();
        gunActions = gunInput.Gun;

        shoot = GetComponent<Shooting>();
        gunActions.Shoot.performed += ctx => shoot.Shoot();
        //gunActions.Shoot.canceled += ctx => shoot.EndShoot();
    }

    private void OnEnable()
    {
        gunActions.Enable();
    }

    private void OnDisable()
    {
        gunActions.Disable();
    }
}