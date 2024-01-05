using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorPressurePlates : MonoBehaviour
{
    [SerializeField] private PressurePlate _plate;
    private bool canClose;

    // Update is called once per frame
    void Update()
    {
        if (_plate.turnedOn && !canClose)
        {
            GetComponent<Animation>().Play("HangarDoor1Open");
            canClose = true;
        }
        else if (!_plate.turnedOn && canClose)
        {
            GetComponent<Animation>().Play("HangarDoor1Close");
            canClose = false;
        }
    }
}