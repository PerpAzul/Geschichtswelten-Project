using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarDoor : MonoBehaviour
{
    public bool doorLocked;
    public GameObject doorFrame;

    bool doorCanClose = false;
    bool doorCanOpen = true;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        if (doorLocked) {
            Renderer renderer = doorFrame.GetComponent<Renderer>();
            Material mat = renderer.material;
            Color finalColor = Color.red;
            mat.SetColor("_EmissionColor", finalColor);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (!doorLocked) {
            audio.PlayOneShot(_clip);
            StartCoroutine(OpenDoor());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!doorLocked)
        {
            audio.PlayOneShot(_clip);
            doorCanClose = true;
        }
    }

    IEnumerator OpenDoor()
    {
        while (!doorCanOpen)
        {
            yield return null;
        }

        doorCanOpen = false;

        GetComponent<Animation>().Play("HangarDoor1Open");
        yield return new WaitForSeconds(1);
            
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        while (!doorCanClose)
        {
            yield return null;
        }

        GetComponent<Animation>().Play("HangarDoor1Close");
        yield return new WaitForSeconds(1);

        doorCanClose = false;
        doorCanOpen = true;
    }

}
