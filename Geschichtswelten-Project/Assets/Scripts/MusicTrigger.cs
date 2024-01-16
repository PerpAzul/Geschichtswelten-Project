using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] private MusicPlayer MusicPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MusicPlayer.index++;
            MusicPlayer.PlayMusic();
            GetComponent<BoxCollider>().enabled = false;
        }
        
    }
}
