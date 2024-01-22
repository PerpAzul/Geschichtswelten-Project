using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorPressurePlates : MonoBehaviour
{
    [SerializeField] private PressurePlate _plate;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip clip;
    private bool canClose;

    // Update is called once per frame
    void Update()
    {
        if (_plate.turnedOn && !canClose)
        {
            _audio.PlayOneShot(clip);
            GetComponent<Animation>().Play("HangarDoor1Open");
            canClose = true;
        }
        else if (!_plate.turnedOn && canClose)
        {
            _audio.PlayOneShot(clip);
            GetComponent<Animation>().Play("HangarDoor1Close");
            canClose = false;
        }
    }
}