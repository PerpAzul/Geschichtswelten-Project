using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Animation>().Play("HangarDoor1Close");
    }
}
