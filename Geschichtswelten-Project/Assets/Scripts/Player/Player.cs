using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool running;

    public float baseSpeed = 10f;
    public float speed;
    public float gravity = -9.8f;
    public Camera mainCamera;
    [SerializeField]
    private Transform cameraTransform;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        cameraTransform = mainCamera.transform;
        isGrounded = controller.isGrounded;
    }

    public void Move(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        moveDirection = cameraTransform.forward * moveDirection.z + cameraTransform.right * moveDirection.x;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void StartRun()
    {
        speed *= 1.5f;
    }

    public void EndRun()
    {
        speed = baseSpeed;
    }
}
