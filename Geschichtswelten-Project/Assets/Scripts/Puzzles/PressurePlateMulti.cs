using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PressurePlateMulti : MonoBehaviour
{
    [SerializeField] private PressurePlate PressurePlate;
    [SerializeField] private PressurePlate PressurePlate2;
    [SerializeField] private HangarDoor _hangarDoor;
    public bool isActivated;
    bool doorCanClose = false;
    bool doorCanOpen = true;
    private bool doorLocked;

    private void Update()
    {
        
        if (PressurePlate.turnedOn & PressurePlate2.turnedOn)
        {
            StartCoroutine(OpenDoor());
            doorCanOpen = false;
        }
        else
        {
            doorCanClose = true;
        }
    }

    IEnumerator OpenDoor()
    {
        while (!doorCanOpen)
        {
            yield return null;
        }

        _hangarDoor.GetComponent<Animation>().Play("HangarDoor1Open");
        yield return new WaitForSeconds(1);

        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        while (!doorCanClose)
        {
            yield return null;
        }

        _hangarDoor.GetComponent<Animation>().Play("HangarDoor1Close");
        yield return new WaitForSeconds(10);

        doorCanClose = false;
        doorCanOpen = true;
    }
}