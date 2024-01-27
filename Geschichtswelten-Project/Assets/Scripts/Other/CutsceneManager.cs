using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CutsceneManager : MonoBehaviour
{
    #region Scenes

    [SerializeField] private GameObject Scene1;
    [SerializeField] private GameObject Scene2;
    [SerializeField] private GameObject Scene3;
    [SerializeField] private GameObject Scene4;

    #endregion

    #region CanvasGroups

    [SerializeField] private CanvasGroup Scene1CanvasGroup;
    [SerializeField] private CanvasGroup Scene2Picture1CanvasGroup;
    [SerializeField] private CanvasGroup Scene2Picture2CanvasGroup;
    [SerializeField] private CanvasGroup Scene2Picture3CanvasGroup;
    [SerializeField] private CanvasGroup Scene3Picture1CanvasGroup;
    [SerializeField] private CanvasGroup Scene3Picture2CanvasGroup;
    [SerializeField] private CanvasGroup Scene3Picture3CanvasGroup;
    [SerializeField] private CanvasGroup Scene4Picture1CanvasGroup;
    [SerializeField] private CanvasGroup Scene4Picture2CanvasGroup;
    [SerializeField] private CanvasGroup Scene4Picture3CanvasGroup;

    #endregion


    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject Cutscene;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject _player;
    private int index = 0;
    private bool _stopInput;

    private void Awake()
    {
        Time.timeScale = 0;
        gameUI.gameObject.SetActive(false);
        Cutscene.gameObject.SetActive(true);
        Scene1.gameObject.SetActive(true);
        weaponHolder.SetActive(false);
        _player.GetComponent<Flashlight>().inCutscene = true;
    }

    private void Update()
    {
        switch (index)
        {
            case 0:
                Scene1CanvasGroup.alpha += 0.05f;
                break;
            case 1:
                Scene2Picture1CanvasGroup.alpha += 0.05f;
                break;
            case 2:
                Scene2Picture2CanvasGroup.alpha += 0.05f;
                break;
            case 3:
                Scene2Picture3CanvasGroup.alpha += 0.05f;
                break;
            case 4:
                weaponHolder.SetActive(false);
                _player.GetComponent<Flashlight>().inCutscene = true;
                Scene3Picture1CanvasGroup.alpha += 0.05f;
                break;
            case 5:
                Scene3Picture1CanvasGroup.alpha = 0f;
                Scene3Picture2CanvasGroup.alpha += 0.05f;
                break;
            case 6:
                Scene3Picture3CanvasGroup.alpha += 0.05f;
                break;
            case 7:
                _player.GetComponent<Flashlight>().inCutscene = true;
                weaponHolder.SetActive(false);
                Scene4Picture1CanvasGroup.alpha += 0.05f;
                break;
            case 8:
                Scene4Picture2CanvasGroup.alpha += 0.05f;
                break;
            case 9:
                Scene4Picture1CanvasGroup.alpha = 0f;
                Scene4Picture2CanvasGroup.alpha = 0f;
                Scene4Picture3CanvasGroup.alpha += 0.05f;
                break;
            default:
                return;
        }
    }


    public void Skip()
    {
        switch (index)
        {
            case 0:
                Scene1.gameObject.SetActive(false);
                Scene2.gameObject.SetActive(true);
                index++;
                break;
            case 1:
                index++;
                break;
            case 2:
                index++;
                break;
            case 3:
                Scene2.gameObject.SetActive(false);
                Cutscene.gameObject.SetActive(false);
                gameUI.SetActive(true);
                _player.GetComponent<Flashlight>().inCutscene = false;
                weaponHolder.SetActive(true);
                Time.timeScale = 1;
                index++;
                break;
            //Nadji room Scene
            case 4:
                
                Scene3.gameObject.SetActive(true);
                gameUI.SetActive(false);
                Time.timeScale = 0;
                index++;
                break;
            case 5:
                index++;
                break;
            case 6:
                Scene3.gameObject.SetActive(false);
                Cutscene.gameObject.SetActive(false);
                gameUI.SetActive(true);
                _player.GetComponent<Flashlight>().inCutscene = false;
                weaponHolder.SetActive(true);
                Time.timeScale = 1;
                index++;
                break;
            case 7:
                Scene4.gameObject.SetActive(true);
                gameUI.SetActive(false);
                Time.timeScale = 0;
                index++;
                break;
            case 8:
                index++;
                break;
            case 9:
                index++;
                break;
            case 10:
                if (_stopInput)
                {
                    return;
                }
                PlayerPrefs.SetInt("CompletedLvl1", 1);
                StartCoroutine(LoadNextScene());
                //SceneManager.LoadScene("scene_lightsOff");
                _stopInput = true;
                break;
            default:
                return;
        }
    }

    IEnumerator LoadNextScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("scene_lightsOff");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}