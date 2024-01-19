using System;
using System.Collections;
using Cinemachine;
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
    private StateMachine _state = new StateMachine();

    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    

    //GravityPush Power with Collision Detection
    public void GravityPush()
    {
        if (_canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity))
            {
                var hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Box"))
                {
                    //Debug.Log("Push Hit");
                    var rigidbody = hitGameObject.GetComponent<Rigidbody>();
                    var distance = Vector3.Distance(transform.position, rigidbody.transform.position);
                    Debug.Log(distance);
                    switch (distance)
                    {
                        case <= 5f:
                            rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 3500f,
                                ForceMode.Force);
                            break;
                        case > 5f and <= 10f:
                            rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 2000f,
                                ForceMode.Force);
                            break;
                        case > 10f and < 15f:
                            rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 1750f,
                                ForceMode.Force);
                            break;
                    }

                    //Cooldown
                    StartCoroutine(StartCountdown(2));
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
                    _turnoff = hitGameObject.GetComponent<Rigidbody>();
                    _turnoff.useGravity = false;
                    Debug.Log("Float hit!");
                    navMeshisDeactivated = true;
                    _turnoff.GetComponent<NavMeshAgent>().enabled = false;
                    _turnoff.AddForce(Vector3.up.normalized * 7.5f, ForceMode.VelocityChange);
                    _useGravityFloat = true;
                    _state.inAir = true;

                    StartCoroutine(StartFloatCountdown(5));
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


    /*
    //Can Pick Up Stuff
    public void PickUpStuff()
    {
        if (!Stop)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    3f))
            {
                var hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Box") && hitGameObject.GetComponent<Rigidbody>())
                {
                    Stop = true;
                    hitGameObject.transform.parent = cam.transform;
                    hitGameObject.GetComponent<Rigidbody>().isKinematic = true;
                    hitGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                    hitGameObject.GetComponent<Rigidbody>().freezeRotation = true;
                    hitGameObject.GetComponent<Rigidbody>().useGravity = false;
                    PickUpHit = hit;
                }
            }
        }
        else
        {
            PickUpHit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            PickUpHit.collider.gameObject.transform.parent = null;
            PickUpHit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            PickUpHit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Stop = false;
        }
    }
    */


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
                if (hitGameObject.CompareTag("Box"))
                {
                    Debug.Log("Pull Hit");

                    var rigidbody = hitGameObject.GetComponent<Rigidbody>();
                    var distance = transform.position - rigidbody.transform.position;
                    rigidbody.AddForce(
                        (transform.position - rigidbody.transform.position).normalized * Time.deltaTime +
                        distance * 75.75f,
                        ForceMode.Force);
                        
                    StartCoroutine(StartCountdown(1));
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

    private IEnumerator StartFloatCountdown(int time)
    {
        _turnoff.useGravity = true;
        _canUsePowers = false;
        _useGravityFloat = false;
        yield return new WaitForSeconds(time);
        _canUsePowers = true;
        _state.inAir = false;
        _turnoff.GetComponent<NavMeshAgent>().enabled = true;
        navMeshisDeactivated = false;
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
            Debug.Log("Waiting");
            _state.inAir = false;
            _turnoff.GetComponent<NavMeshAgent>().enabled = true;
            navMeshisDeactivated = false;
        }

        Debug.Log("End of StartCountdown");
    }
    /*
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
    */
}