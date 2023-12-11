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
    private bool canUsePowers = true;
    private bool useGravityFloat = false;
    private Rigidbody turnoff;
    

    //GravityPush Power with Collision Detection
    public void GravityPush()
    {
        if (canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    15f))
            {
                GameObject hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Hit");
                    var rigidbody = hitGameObject.GetComponent<Rigidbody>();
                    rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 1500f,
                        ForceMode.Force);
                    
                    //Cooldown
                    StartCoroutine(StartCountdown(5));
                }
            }
            else
            {
                StartCoroutine(StartCountdown(1));
            }
        }
        else
        {
            return;
        }

        Debug.Log("No Hit");
    }

    //GravityFloat 
    public void GravityFloat()
    {
        if (canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    15f))
            {
                GameObject hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Float hit!");
                    
                    //var rigidBody = hitGameObject.GetComponent<Rigidbody>();
                    turnoff = hitGameObject.GetComponent<Rigidbody>();
                    turnoff.transform.position = new Vector3(turnoff.transform.position.x,
                        turnoff.transform.position.y + 2f,
                        turnoff.transform.position.z);
                    turnoff.useGravity = false;
                    useGravityFloat = true;
                    StartCoroutine(StartCountdown(3));
                    
                }
            }
            else
            {
                StartCoroutine(StartCountdown(1));
            }
        }
        else
        {
            return;
        }
        Debug.Log("No Float Hit");
    }

    //GravityPull with Detection 
    public void GravityPull()
    {
        if (canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    15f))
            {
                GameObject hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Hit");
                    var rigidbody = hitGameObject.GetComponent<Rigidbody>();
                    rigidbody.AddForce((transform.position - rigidbody.transform.position).normalized * 1500f,
                        ForceMode.Force);
                    StartCoroutine(StartCountdown(5));
                }
            }
            else
            {
                StartCoroutine(StartCountdown(1));
            }
        }
        else
        {
            return;
        }

        Debug.Log("No Hit");
    }

    private IEnumerator StartCountdown(int time)
    {
        canUsePowers = false;
        yield return new WaitForSeconds(time);
        canUsePowers = true;
        if (useGravityFloat)
        {
            turnoff.useGravity = true;
            turnoff.transform.position = new Vector3(turnoff.transform.position.x, turnoff.transform.position.y - 2f,
                turnoff.transform.position.z);
            Debug.Log("Gravity on");
            useGravityFloat = false;
        }
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