using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeAdjuster : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        float output;
        bool success = audioMixer.GetFloat("volume", out output); //using the last set value in the Audio Mixer to get the same sound volume between scenes
        if (success)
        {
            volumeSlider.value = output;
        }
    }

    //called on Value changed by the slider. Also based on this video: https://www.youtube.com/watch?v=YOaYQrN1oYQ
    public void SetVolume(float newVolume)
    {
        //TODO 
        Debug.Log(newVolume);
        audioMixer.SetFloat("volume", newVolume);
    }
}
