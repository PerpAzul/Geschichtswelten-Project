using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    private static int indexForGame = 0;

    //https://www.youtube.com/watch?v=YOaYQrN1oYQ adapted some options from here
    private void Awake()
    {
        Debug.Log(indexForGame);
        QualitySettings.SetQualityLevel(indexForGame == 0 ? 2 : indexForGame);
    }

    // Start is called before the first frame update
    public void ChangeQuality(int index)
    {
        indexForGame = index;
        QualitySettings.SetQualityLevel(index);
    }

    public void setFullScreen(bool isFoolscreen)
    {
        Screen.fullScreen = isFoolscreen;
    }
}