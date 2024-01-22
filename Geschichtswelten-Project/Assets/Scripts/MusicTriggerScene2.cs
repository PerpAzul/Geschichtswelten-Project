using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerScene2 : MonoBehaviour
{
    [SerializeField] private MusicPlayer2 _musicPlayer2;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!_musicPlayer2.spookyMusicPlaying && !_musicPlayer2.onHangar && gameObject.CompareTag("Music"))
            {
                _musicPlayer2.PlayFadeIn();
                _musicPlayer2.spookyMusicPlaying = true;
            }
            else if (!_musicPlayer2.spookyMusicPlaying && _musicPlayer2.onHangar && gameObject.CompareTag("Music"))
            {
                _musicPlayer2.PlayMixSource2();
                _musicPlayer2.spookyMusicPlaying = true;
                _musicPlayer2.onHangar = false;
            }
            else if (_musicPlayer2.spookyMusicPlaying && gameObject.CompareTag("Hangar"))
            {
                _musicPlayer2.PlayMixSource();
                _musicPlayer2.spookyMusicPlaying = false;
                _musicPlayer2.onHangar = true;
            }
            else if (_musicPlayer2.spookyMusicPlaying && gameObject.CompareTag("Puzzle"))
            {
                _musicPlayer2.PlayMuteTransition();
                _musicPlayer2.spookyMusicPlaying = false;
            }
            
        }
    }
}