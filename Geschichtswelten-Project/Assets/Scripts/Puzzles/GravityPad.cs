using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPad : MonoBehaviour
{
    private void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position,1.5f,Vector3.up,out hit,1f))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                hit.collider.gameObject.GetComponent<CharacterController>().Move(new Vector3(0, 5, 0));
            }
        }
    }

    
}