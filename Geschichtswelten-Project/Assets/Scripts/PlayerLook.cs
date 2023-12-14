using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float _rotation;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    private bool _canUsePowers = true;
    private bool _useGravityFloat;
    private Rigidbody _turnoff;
    private bool Stop;

        

    //GravityPush Power with Collision Detection
    public void GravityPush()
    {
        if (_canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    15f))
            {
                var hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Push Hit");
                    var rigidbody = hitGameObject.GetComponent<Rigidbody>();
                    var distance = Vector3.Distance(transform.position, rigidbody.transform.position);
                    Debug.Log(distance);
                    switch (distance)
                    {
                        
                        case <= 5f:
                            rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 7500f,
                                ForceMode.Force);
                            break;
                        case > 5f and <= 10f:
                            rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 3500f,
                                ForceMode.Force);
                            break;
                        case > 10f and < 15f:
                            rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 1500f,
                                ForceMode.Force);
                            break;
                    }
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
        if (_canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    15f))
            {
                var hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Float hit!");
                    _turnoff = hitGameObject.GetComponent<Rigidbody>();
                    _turnoff.useGravity = false;
                    _turnoff.AddForce(Vector3.up.normalized * 15f, ForceMode.Force);
                    _turnoff.GetComponent<SphereCollider>().radius = 3.02f;
                    _turnoff.GetComponent<SphereCollider>().enabled = true;
                    _useGravityFloat = true;


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

    //Can Pick Up Stuff but does not move with Player 
    public void PickUpStuff()
    {
        if (!Stop)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,  Mathf.Infinity))
            {
                var hitGameObject = hit.collider.gameObject;
                if (!hitGameObject.CompareTag("Untagged") && hitGameObject.GetComponent<Rigidbody>())
                {
                    //Place it slighty above
                    hitGameObject.GetComponent<Rigidbody>().useGravity = false;
                    hitGameObject.GetComponent<Rigidbody>().drag = 10;
                    hitGameObject.GetComponent<Rigidbody>().freezeRotation = true;
                    Stop = true;
                    var moveDirection = (cam.transform.position - hitGameObject.transform.position);
                    hitGameObject.GetComponent<Rigidbody>().AddForce(moveDirection * 150.0f);
                }
            }
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                hit.collider.gameObject.GetComponent<Rigidbody>().drag = 0;
                hit.collider.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                Stop = false;
            }
        }
    }


    //GravityPull with Detection 
    public void GravityPull()
    {
        if (_canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity))
            {
                var hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Pull Hit");

                    var rigidbody = hitGameObject.GetComponent<Rigidbody>();
                    var distance = transform.position - rigidbody.transform.position;
                    rigidbody.AddForce(
                        (transform.position - rigidbody.transform.position).normalized + distance * 75.75f,
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
        _canUsePowers = false;
        yield return new WaitForSeconds(time);
        _canUsePowers = true;
        if (_useGravityFloat)
        {
            _turnoff.useGravity = true;
            _turnoff.AddForce(Vector3.up.normalized * 0f, ForceMode.Force);
            _useGravityFloat = false;
            _turnoff.GetComponent<SphereCollider>().radius = 0.1f;
        }

        Debug.Log("End of StartCountdown");
    }

    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //calculate camera rotation for looking up and down
        _rotation -= (mouseY * Time.deltaTime) * ySensitivity;
        _rotation = Mathf.Clamp(_rotation, -80f, 80f);

        //apply this to camera transform
        cam.transform.localRotation = Quaternion.Euler(_rotation, 0, 0);

        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}