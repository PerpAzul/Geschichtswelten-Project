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
        if (PlayerPrefs.HasKey("volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        }
    }

    //called on Value changed by the slider. Also based on this video: https://www.youtube.com/watch?v=YOaYQrN1oYQ
    public void SetVolume(float newVolume)
    {
        //TODO 
        Debug.Log(newVolume);
        audioMixer.SetFloat("volume", newVolume);
        PlayerPrefs.SetFloat("volume", newVolume);
    }
}
