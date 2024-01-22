using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private HangarDoor _hangarDoor;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip AudioClip;
    public bool isActivated;
    bool doorCanClose = false;
    bool doorCanOpen = true;
    public bool turnedOn;
    private float isOpen = 0;

    private void OnTriggerEnter(Collider other)
    {
        turnedOn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        turnedOn = false;
    }

    /*
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
    */
    public void OpenDoorSimple()
    {
        AudioSource.PlayOneShot(AudioClip);
        _hangarDoor.GetComponent<Animation>().Play("HangarDoor1Open");
    }

    public void CloseDoorSimple()
    {
        _hangarDoor.GetComponent<Animation>().Play("HangarDoor1Close");
    }
    
    public void OpenDoorSimple2()
    {
        if (isOpen == 0)
        {
            isOpen = 1;
            AudioSource.PlayOneShot(AudioClip);
            _hangarDoor.GetComponent<Animation>().Play("HangarDoor1Open");  
        }
    }
}