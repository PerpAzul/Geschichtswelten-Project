using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cutsceneUI;
    private void OnTriggerEnter(Collider other)
    {
        cutsceneUI.gameObject.SetActive(true);
    }
}
