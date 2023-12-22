using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
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
