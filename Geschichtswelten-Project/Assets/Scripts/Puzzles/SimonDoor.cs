using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _clip;
    private void OnTriggerEnter(Collider other)
    {
        _audio.PlayOneShot(_clip);
        GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Animation>().Play("HangarDoor1Close");
    }
}
