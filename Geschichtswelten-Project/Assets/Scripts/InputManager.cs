using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.PlayerBasicsActions playerActions;

    private Player player;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        playerActions = playerInput.PlayerBasics;
        player = GetComponent<Player>();
        look = GetComponent<PlayerLook>();
        playerActions.Jump.performed += ctx => player.Jump();
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
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}
