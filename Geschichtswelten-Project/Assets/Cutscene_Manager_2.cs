using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_Manager_2 : MonoBehaviour
{
    public List<CanvasGroup> scenes = new List<CanvasGroup>();
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject Cutscene;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioSource generalAudioSource;
    [SerializeField] private AudioClip cutscene1Music;
    [SerializeField] private MusicPlayer2 MusicPlayer2;

    public int index = 0;
    public bool inCutscene = true;

    private void Awake()
    {
        generalAudioSource.volume = 0.4f;
        generalAudioSource.clip = cutscene1Music;
        generalAudioSource.loop = true;
        generalAudioSource.Play();
        Time.timeScale = 0;
        gameUI.SetActive(false);
        Cutscene.SetActive(true);
        weaponHolder.SetActive(false);
        _player.GetComponent<Flashlight>().inCutscene = true;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (index)
        {
            case 0:
                generalAudioSource.volume += 0.01f;
                scenes[0].alpha += 0.05f;
                break;
            case 1:
                //First Scene With Flashlight
                scenes[0].alpha = 0f;
                scenes[1].alpha += 0.05f;
                break;
            case 2:
                //Ok we have a deal scene
                scenes[1].alpha = 0f;
                scenes[2].alpha += 0.05f;
                break;
            case 3:
                //power showcase with scene[2]
                scenes[3].alpha += 0.05f;
                break;
            case 4:
                //Final Scene in Dark
                scenes[2].alpha = 0f;
                scenes[3].alpha = 0f;
                scenes[4].alpha += 0.05f;
                
                break;
            case 5:
                //To Gameplay
                scenes[4].alpha = 0f;
                break;
            case 6:
                //First Cutscene of Finale
                weaponHolder.SetActive(false);
                _player.GetComponent<Flashlight>().inCutscene = true;
                scenes[5].alpha += 0.05f;
                break;
            case 7:
                //Scene 2
                scenes[5].alpha = 0f;
                scenes[6].alpha += 0.05f;
                break;
            case 8:
                //Scene 3
                scenes[7].alpha += 0.05f;
                break;
            case 9:
                //Scene 4
                scenes[6].alpha = 0f;
                scenes[7].alpha = 0f;
                scenes[8].alpha += 0.05f;
                break;
            case 10:
                //Scene 5
                scenes[8].alpha = 0f;
                scenes[9].alpha += 0.05f;
                break;
            case 11:
                //Scene 6
                scenes[9].alpha = 0f;
                scenes[10].alpha += 0.05f;
                break;
            case 12:
                //Scene 7
                scenes[11].alpha += 0.05f;
                break;
            case 13:
                //Scene 8
                scenes[10].alpha = 0f;
                scenes[11].alpha = 0f;
                scenes[12].alpha += 0.05f;
                break;
            case 14:
                //WHAM!
                scenes[13].alpha += 0.05f;
                break;
            case 15:
                //Scene 9
                scenes[14].alpha += 0.05f;
                break;
            case 16:
                //Scene 10 - Nadji Death
                scenes[12].alpha = 0f;
                scenes[13].alpha = 0f;
                scenes[14].alpha = 0f;
                scenes[15].alpha += 0.05f;
                break;
            case 17:
                //Scene 11 -Kurja Reaction
                scenes[16].alpha += 0.05f;
                break;
            case 18:
                //Scene 12 _Yuri Reaction
                scenes[17].alpha += 0.05f;
                break;
            case 19:
                //Scene 13 -Dialogue Kurja and Dude
                scenes[15].alpha = 0f;
                scenes[16].alpha = 0f;
                scenes[17].alpha = 0f;
                scenes[18].alpha += 0.05f;
                break;
            case 20:
                //Scene 14 - Yuri Reaction
                scenes[18].alpha = 0f;
                scenes[19].alpha += 0.05f;
                break;
        }
    }


    public void skip()
    {
        if (!inCutscene)
        {
            return;
        }

        Debug.Log(index);
        switch (index)
        {
            case 0:
                //In Dark before Flashlight
                index++;
                break;
            case 1:
                index++;
                break;
            case 2:
                index++;
                break;
            case 3:
                index++;
                break;
            case 4:
                //back to Gameplay
                scenes[4].alpha = 0f;
                inCutscene = false;
                gameUI.SetActive(true);
                _player.GetComponent<Flashlight>().inCutscene = false;
                generalAudioSource.Stop();
                generalAudioSource.loop = false;
                generalAudioSource.clip = null;
                generalAudioSource.volume = 1f;
                MusicPlayer2.spookyMusicPlaying = true;
                weaponHolder.SetActive(true);
                Time.timeScale = 1;
                Cutscene.SetActive(false);
                index++;
                break;
            case 5:
                //Back to Cutscene
                MusicPlayer2.spookyMusicPlaying = false;
                Time.timeScale = 0;
                gameUI.SetActive(false);
                Cutscene.SetActive(true);
                index++;
                break;
            case 6:
                index++;
                break;
            case 7:
                index++;
                break;
            case 8:
                index++;
                break;
            case 9:
                index++;
                break;
            case 10:
                index++;
                break;
            case 11:
                index++;
                break;
            case 12:
                index++;
                break;
            case 13:
                index++;
                break;
            case 14:
                index++;
                break;
            case 15:
                index++;
                break;
            case 16:
                index++;
                break;
            case 17:
                index++;
                break;
            case 18:
                index++;
                break;
            case 19:
                index++;
                break;
            case 20:
                index++;
                break;
        }
    }
}