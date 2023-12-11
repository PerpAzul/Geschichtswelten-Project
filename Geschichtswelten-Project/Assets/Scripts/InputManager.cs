using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInput.PlayerBasicsActions playerActions;
    private PlayerInput.PowersActions powersActions;

    private Player player;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        playerActions = playerInput.PlayerBasics;
        powersActions = playerInput.Powers;
        player = GetComponent<Player>();
        look = GetComponent<PlayerLook>();
        playerActions.Jump.performed += ctx => player.Jump();
        powersActions.GravityPull.performed += ctx => look.GravityPull();
        powersActions.ActivateGravityPush.performed += ctx => look.GravityPush();
        powersActions.GravityFloat.performed += ctx => look.GravityFloat();
    }

    private void FixedUpdate()
    { 
        player.Move(playerActions.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.Look(playerActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerActions.Enable();
        powersActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
        powersActions.Disable();
    }
}
