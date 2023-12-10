using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float rotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    private PlayerInput playerInput;
    private PlayerInput.PowersActions powersActions;

    private void Awake()
    {
        playerInput = new PlayerInput();
        powersActions = playerInput.Powers;
    }

    private void OnEnable()
    {
        powersActions.Enable();
    }

    private void OnDisable()
    {
        powersActions.Disable();
    }

    private void LateUpdate()
    {
        if (powersActions.ActivateGravityPush.IsPressed())
        {
            GravityPush();
        }
        
    }

    //Method to detect if an enemy is in front of you
    private bool DetectCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.TransformDirection(Vector3.forward),out hit,Mathf.Infinity))
        {
            GameObject hitGameObject = hit.collider.gameObject;
            if (hitGameObject.CompareTag("Enemy"))
            {
                return true;
            }
        }
       
        return false;
    }

    private void GravityPush()
    {
        if (DetectCollision())
        {
            Debug.Log("Hit");
        }
        Debug.Log("No hit");
    }
    

    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        
        //calculate camera rotation for looking up and down
        rotation -= (mouseY * Time.deltaTime) * ySensitivity;
        rotation = Mathf.Clamp(rotation, -80f, 80f);
        
        //apply this to camera transform
        cam.transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        
        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
