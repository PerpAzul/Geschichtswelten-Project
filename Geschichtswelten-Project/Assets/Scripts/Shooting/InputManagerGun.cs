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
    private WeaponSwitching switching;
    private Aim aiming;

    void Awake()
    {
        gunInput = new GunInput();
        gunActions = gunInput.Gun;

        shoot = GetComponent<Shooting>();
        switching = GetComponentInParent<WeaponSwitching>();
        aiming = GetComponent<Aim>();
        
        gunActions.Shoot.performed += ctx => shoot.Shoot();
        gunActions.Reload.performed += ctx => shoot.Reload();
        gunActions.Switch.performed += ctx => switching.Switch();
        gunActions.Aim.started += ctx => aiming.StartAiming();
        gunActions.Aim.canceled += ctx => aiming.StopAiming();
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