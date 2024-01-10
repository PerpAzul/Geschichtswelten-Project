using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    //https://www.youtube.com/watch?v=YOaYQrN1oYQ adapted some options from here
    private void Awake()
    {
        QualitySettings.SetQualityLevel(2);
    }

    // Start is called before the first frame update
    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void setFullScreen(bool isFoolscreen)
    {
        Screen.fullScreen = isFoolscreen;
    }
    
}
