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


    //Method to detect if an enemy is in front of you
    public void GravityPush()
    {
        if (canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity))
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

    public void GravityPull()
    {
        if (canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity))
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