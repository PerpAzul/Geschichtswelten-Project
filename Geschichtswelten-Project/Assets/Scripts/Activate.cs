using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject levelEnd;
    [SerializeField] private GameObject levelEnd2;
    [SerializeField] private GameObject alien;
    [SerializeField] private GameObject thisObject;

    private void OnTriggerEnter(Collider other)
    {
        dialogue.SetActive(true);
        levelEnd.SetActive(true);
        levelEnd2.SetActive(true);
        alien.SetActive(true);
        thisObject.SetActive(false);
    }
}
