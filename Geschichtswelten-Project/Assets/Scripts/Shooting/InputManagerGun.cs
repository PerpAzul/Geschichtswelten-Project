using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerGun : MonoBehaviour
{
    private GunInput gunInput;
    private GunInput.GunActions gunActions;

    //private Shooting shoot;
    private WeaponSwitching switching;

    private Gun _gun;
    //private Aim aiming;

    void Awake()
    {
        gunInput = new GunInput();
        gunActions = gunInput.Gun;

        //shoot = GetComponent<Shooting>();
        _gun = GetComponent<Gun>();
        switching = GetComponentInParent<WeaponSwitching>();
        //aiming = GetComponent<Aim>();

        gunActions.Shoot.performed += ctx => _gun.Shoot();
        gunActions.Reload.performed += ctx => _gun.Reload();
        gunActions.Aim.started += ctx => _gun.StartAiming();
        gunActions.Aim.canceled += ctx => _gun.StopAiming();
        gunActions.Switch.performed += ctx => switching.Switch();
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