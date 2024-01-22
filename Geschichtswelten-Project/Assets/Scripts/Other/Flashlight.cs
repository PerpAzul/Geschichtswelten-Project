using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public bool on;
    public bool off;
    public bool inCutscene;
    [SerializeField] private AudioSource generalAudioSource;
    [SerializeField] private AudioClip flashLightSound;

    void Start()
    {
        off = true;
        on = false;
        flashlight.SetActive(false);
    }

    public void Flash()
    {
        if (!inCutscene)
        {
            if (off)
            {
                flashlight.SetActive(true);
                off = false;
                on = true;
                generalAudioSource.PlayOneShot(flashLightSound);
                return;
            }
            else if (on)
            {
                flashlight.SetActive(false);
                off = true;
                on = false;
                generalAudioSource.PlayOneShot(flashLightSound);
            }
        }
    }
}