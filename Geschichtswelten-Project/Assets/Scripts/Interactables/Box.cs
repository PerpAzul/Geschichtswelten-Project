using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interactable
{
    public bool Stop;
    public Camera cam;

    protected override void Interact()
    {
        if (!Stop)
        {
            Stop = true;
            GetComponent<Collider>().gameObject.transform.parent = cam.transform;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            GetComponent<Collider>().gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Collider>().gameObject.transform.parent = null;
            GetComponent<Collider>().gameObject.GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().gameObject.GetComponent<Rigidbody>().useGravity = true;
            Stop = false;
        }
    }
}