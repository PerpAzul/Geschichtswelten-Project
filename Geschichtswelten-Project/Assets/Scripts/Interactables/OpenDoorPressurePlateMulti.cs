using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorPressurePlateMulti : MonoBehaviour
{
    [SerializeField] private PressurePlate PressurePlate1;

    [SerializeField] private PressurePlate PressurePlate2;
    [SerializeField] private AudioSource aAudioSource;
    [SerializeField] private AudioClip _clip;
    private bool canOpen;

    // Update is called once per frame
    void Update()
    {
        if (PressurePlate1.turnedOn && PressurePlate2.turnedOn && !canOpen)
        {
            GetComponent<Animation>().Play("HangarDoor1Open");
            aAudioSource.PlayOneShot(_clip);
            canOpen = true;
        }
        else if ((PressurePlate1.turnedOn && !PressurePlate2.turnedOn ||
                  !PressurePlate1.turnedOn && PressurePlate2.turnedOn) && canOpen)
        {
            GetComponent<Animation>().Play("HangarDoor1Close");
            aAudioSource.PlayOneShot(_clip);
            canOpen = false;
        }
    }
}