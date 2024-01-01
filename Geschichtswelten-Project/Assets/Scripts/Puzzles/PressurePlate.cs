using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private HangarDoor _hangarDoor;
    public bool isActivated;
    bool doorCanClose = false;
    bool doorCanOpen = true;
    public bool turnedOn;

   

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(OpenDoor());
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(CloseDoor());
    }

    IEnumerator OpenDoor()
    {
        _hangarDoor.GetComponent<Animation>().Play("HangarDoor1Open");
        turnedOn = true;
        yield return new WaitForSeconds(1);
    }

    IEnumerator CloseDoor()
    {
        _hangarDoor.GetComponent<Animation>().Play("HangarDoor1Close");
        turnedOn = false;
        yield return new WaitForSeconds(1);
    }
    
    public void OpenDoorSimple()
    {
        _hangarDoor.GetComponent<Animation>().Play("HangarDoor1Open");
        
    }
}