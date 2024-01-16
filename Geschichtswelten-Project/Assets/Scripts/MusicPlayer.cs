using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//Adapted from here: https://www.youtube.com/watch?v=c3NdUYDyRhE
public class MusicPlayer : MonoBehaviour
{
    //[SerializeField] private AudioClip _audioClip;
    public int index = 0;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioSource _audioSource2;

    [SerializeField] private List<AudioClip> Musics = new List<AudioClip>();


    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _AudioSource.clip = Musics[0];
        _AudioSource.volume = 1;
        _AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void PlayMusic()
    {
        switch (index)
        {
            case 1:
                _audioSource2.clip = Musics[1];
                StartCoroutine(MixSource(_AudioSource, _audioSource2));
                break;
            case 2:
                StartCoroutine(MuteTransition(_audioSource2));
                break;
            case 3:
                _AudioSource.clip = Musics[2];
                StartCoroutine(PlayMusicTransition(_AudioSource));
                break;
            default:
                break;
        }
    }

    IEnumerator MuteTransition(AudioSource target)
    {
        var percentage = 0f;
        while (target.volume > 0)
        {
            target.volume = Mathf.Lerp(0.4f, 0, percentage);
            percentage += Time.deltaTime / 1.25f;
            yield return null;
        }
        if (target.isPlaying)
        {
            target.Stop();
        }
    }

    IEnumerator PlayMusicTransition(AudioSource target)
    {
        float percentage = 0;
        while (target.volume < 0.8f)
        {
            target.volume += Mathf.Lerp(0, 0.8f, percentage);
            percentage += Time.deltaTime / 1.25f;
            yield return null;
        }
        if (target.isPlaying == false)
        {
            target.Play();
        }
    }

    IEnumerator MixSource(AudioSource nowPlaying, AudioSource target)
    {
        float percentage = 0;
        while (nowPlaying.volume > 0)
        {
            nowPlaying.volume = Mathf.Lerp(0.4f, 0, percentage);
            percentage += Time.deltaTime / 1.25f;
            yield return null;
        }

        nowPlaying.Pause();
        if (target.isPlaying == false)
        {
            target.Play();
        }

        target.UnPause();
        percentage = 0;
        while (target.volume < 0.4f)
        {
            target.volume += Mathf.Lerp(0, 0.4f, percentage);
            percentage += Time.deltaTime / 1.25f;
            yield return null;
        }
    }
}