using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicPlayer2 : MonoBehaviour
{
    //[SerializeField] private AudioClip _audioClip;
    public int index = 0;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioSource _audioSource2;
    [SerializeField] private List<AudioClip> Musics = new List<AudioClip>();
    public bool spookyMusicPlaying;
    public bool onHangar;

    // Start is called before the first frame update
    void Start()
    {
        spookyMusicPlaying = true;
        onHangar = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_AudioSource.isPlaying && spookyMusicPlaying)
        {
            _AudioSource.clip = GetRandomClip();
            _AudioSource.Play();
        }
    }
    

    public void changeSpookyMusic()
    {
        spookyMusicPlaying = !spookyMusicPlaying;
    }

    public void PlayMixSource()
    {
        StartCoroutine(MixSource(_AudioSource, _audioSource2));
    }

    public void PlayMuteTransition()
    {
        StartCoroutine(MuteTransition(_AudioSource));
    }

    private AudioClip GetRandomClip()
    {
        return Musics[Random.Range(0, Musics.Count)];
    }

    public void PlayMixSource2()
    {
        StartCoroutine(MixSource(_audioSource2, _AudioSource));
    }

    public void PlayFadeIn()
    {
        StartCoroutine(PlayMusicTransition(_AudioSource));
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
        while (target.volume < 0.4f)
        {
            target.volume += Mathf.Lerp(0, 0.4f, percentage);
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