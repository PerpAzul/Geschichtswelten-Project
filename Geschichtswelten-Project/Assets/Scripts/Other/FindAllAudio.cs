using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class FindAllAudio : MonoBehaviour
{
    //this is a helper class that finds all Audio Sources and puts them into a list visible in the editor
    public AudioSource[] allSources;

    public AudioSource[] unassignedSources;
    private int unassignedCount = 0;
    // Start is called before the first frame update
    void Start()
    {
       allSources = GameObject.FindObjectsOfType<AudioSource>();
       unassignedSources = new AudioSource[allSources.Length];
       foreach (var curSource in allSources)
       {
           if (curSource.outputAudioMixerGroup == null)
           {
               unassignedSources[unassignedCount++] = curSource;
           }
       }
    }

}
