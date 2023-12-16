using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


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
    [SerializeField] private Transform hold;
    private RaycastHit PickUpHit;
    public bool navMeshisDeactivated = false;


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
                    navMeshisDeactivated = true;
                    _turnoff.GetComponent<NavMeshAgent>().enabled = false;
                    _turnoff.GetComponent<NavMeshAgent>().speed = 0;
                    _turnoff.useGravity = false;
                    _turnoff.AddForce(Vector3.up.normalized * 50f, ForceMode.Force);
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

        
        Debug.Log("End of Float Function");
    }


    //Can Pick Up Stuff but now it does not Rotate with the Camera Upwards again will fix later
    public void PickUpStuff()
    {
        
        if (!Stop)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity))
            {
                var hitGameObject = hit.collider.gameObject;
                if (!hitGameObject.CompareTag("Untagged") && hitGameObject.GetComponent<Rigidbody>())
                {
                    //Place it slighty above
                    hitGameObject.GetComponent<Rigidbody>().useGravity = false;
                    hitGameObject.GetComponent<Rigidbody>().drag = 10;
                    Stop = true;
                    hitGameObject.GetComponent<Rigidbody>().transform.parent = hold;
                    hitGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    var moveDirection = (cam.transform.position - hitGameObject.transform.position);
                    hitGameObject.GetComponent<Rigidbody>().AddForce(moveDirection * 250.0f);
                    hitGameObject.transform.rotation = cam.transform.rotation;
                    PickUpHit = hit;
                }
            }
        }
        else
        {
            PickUpHit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            PickUpHit.collider.gameObject.GetComponent<Rigidbody>().drag = 1;
            PickUpHit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            PickUpHit.collider.gameObject.GetComponent<Rigidbody>().transform.parent = null;
            Stop = false;
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
                        (transform.position - rigidbody.transform.position).normalized * Time.deltaTime +
                        distance * 75.75f,
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
            _useGravityFloat = false;
            navMeshisDeactivated = false;
            yield return new WaitForSeconds(2);
            _turnoff.GetComponent<NavMeshAgent>().enabled = true;
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