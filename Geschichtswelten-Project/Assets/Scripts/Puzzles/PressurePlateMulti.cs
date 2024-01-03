using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PressurePlateMulti : MonoBehaviour
{
    public PressurePlate PressurePlate;
    [SerializeField] private HangarDoor _hangarDoor;
    public bool isActivated;
    bool doorCanClose = false;
    bool doorCanOpen = true;
    private bool doorLocked;

    private void OnTriggerEnter(Collider other)
    {
        if (PressurePlate.turnedOn)
        {
            Debug.Log("both open");
            StartCoroutine(OpenDoor());
            doorCanOpen = false;
        }
       
    }
    
    private void OnTriggerExit(Collider other)
    {
        doorCanClose = true;
        StartCoroutine(CloseDoor());
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
        yield return new WaitForSeconds(1);

        doorCanClose = false;
        doorCanOpen = true;
    }
}