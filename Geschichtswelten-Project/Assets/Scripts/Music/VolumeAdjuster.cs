using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeAdjuster : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    //called on Value changed by the slider. Also based on this video: https://www.youtube.com/watch?v=YOaYQrN1oYQ
    public void SetVolume(float newVolume)
    {
        //TODO 
        Debug.Log(newVolume);
        audioMixer.SetFloat("volume", newVolume);
    }
}
