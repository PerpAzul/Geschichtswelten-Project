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
    [SerializeField] private GameObject Nadji;
    [SerializeField] private GameObject cutsceneUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            Nadji.gameObject.SetActive(false);
            cutsceneUI.SetActive(true);
            dialogue.SetActive(true);
            levelEnd.SetActive(true);
            levelEnd2.SetActive(true);
            alien.SetActive(true);
            thisObject.SetActive(false);
        }
    }
}
