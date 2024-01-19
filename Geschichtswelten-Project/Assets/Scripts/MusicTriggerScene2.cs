using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerScene2 : MonoBehaviour
{
    [SerializeField] private MusicPlayer2 _musicPlayer2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Music") || gameObject.CompareTag("Hangar"))
            {
                _musicPlayer2.changeSpookyMusic();
            }

            if (!_musicPlayer2.spookyMusicPlaying && gameObject.CompareTag("Music"))
            {
                _musicPlayer2.PlayMuteTransition();
            }
            else if (!_musicPlayer2.spookyMusicPlaying && gameObject.CompareTag("Hangar"))
            {
                _musicPlayer2.PlayMixSource();
            }
            else if (_musicPlayer2.spookyMusicPlaying && gameObject.CompareTag("Hangar"))
            {
                _musicPlayer2.PlayMixSource2();
            }
            else if (_musicPlayer2.spookyMusicPlaying && gameObject.CompareTag("Music"))
            {
                _musicPlayer2.PlayFadeIn();
            }
        }
    }
}