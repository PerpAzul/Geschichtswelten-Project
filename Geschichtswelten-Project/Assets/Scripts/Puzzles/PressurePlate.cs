using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PressurePlate : MonoBehaviour
{
    public bool isActivated;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        isActivated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");
        isActivated = false;
    }
}