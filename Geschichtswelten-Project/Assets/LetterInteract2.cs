using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterInteract2 : Interactable
{
    [SerializeField] private TextMeshProUGUI textToUpdate;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject papers;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private AudioClip sadMusic;
    [SerializeField] private MusicPlayer2 _musicPlayer2;
    [SerializeField] private Cutscene_Manager_2 cutsceneManager;

    public GameObject Text;
    private bool NomorePaper = false;

    private void Awake()
    {
        Text.SetActive(false);
    }

    protected override void Interact()
    {
        if (!NomorePaper)
        {
            _musicPlayer2._audioSource2.Stop();
            gameUI.SetActive(false);
            papers.SetActive(true);
            Text.SetActive(true);
            NomorePaper = true;
            Time.timeScale = 0;
            Debug.Log("in");
        }
        else
        {
            _musicPlayer2._audioSource2.clip = sadMusic;
            _musicPlayer2._audioSource2.Play();
            gameUI.SetActive(false);
            papers.SetActive(false);
            Text.SetActive(false);
            NomorePaper = false;
            cutscene.SetActive(true);
            cutsceneManager.inCutscene = true;
            cutsceneManager.index++;
            gameObject.SetActive(false);
            Debug.Log("out");
        }
    }
}