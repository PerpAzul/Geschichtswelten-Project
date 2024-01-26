using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    private static int indexForGame = 0;

    private static int indexForAntiAliasing = 0;

    private static int VSyncIndex = 0;

    private static int QualityShadowIndex = 0;

    private static int ShadowResolutionIndex = 0;

    private static bool softParticles = false;

    private static bool isFullscreen = false;

    private static int indexResolution;

    public AudioMixer audioMixer;
    //[SerializeField] private Dropdown advancedOptions;

    //https://www.youtube.com/watch?v=YOaYQrN1oYQ adapted some options from here
    private void Awake()
    {
        Debug.Log(indexForGame);
        QualitySettings.SetQualityLevel(indexForGame == 0 ? 2 : indexForGame);
        ChangeAntiAliasing(indexForAntiAliasing == 0 ? 2 : indexForAntiAliasing);
        EnableVSync(VSyncIndex == 0 ? 0 : VSyncIndex);
        SetShadowQuality(QualityShadowIndex == 0 ? 1 : QualityShadowIndex);
        SetShadowResolution(ShadowResolutionIndex == 0? 1 : ShadowResolutionIndex);
        SoftParticles(softParticles != false && softParticles);
        setFullScreen(isFullscreen);
        SetResolution(indexResolution == 0 ? 1 : indexResolution);
    }

    // Start is called before the first frame update
    public void ChangeQuality(int index)
    {
        indexForGame = index;
        QualitySettings.SetQualityLevel(index);
    }

    public void setFullScreen(bool toIsFullscreen)
    {
        SettingMenu.isFullscreen = toIsFullscreen;
        Screen.fullScreen = toIsFullscreen;
    }

    public void SetResolution(int index)
    {
        
        switch (index)
        {
            case 0:
                Screen.SetResolution(800,600,isFullscreen);
                break;
            case 1:
                Screen.SetResolution(1980,1080,isFullscreen);
                break;
            case 2:
                Screen.SetResolution(2160,1440,isFullscreen);
                break;
            case 3:
                Screen.SetResolution(2160,1600,isFullscreen);
                break;
            case 4:
                Screen.SetResolution(3840,2160,isFullscreen);
                break;
            default:
                break;
        }
        indexResolution = index;
    }

    public void ChangeShadowDistance(int index)
    {
        ShadowResolutionIndex = index;
        switch (index)
        {
            case 0:
                QualitySettings.shadowDistance = 0;
                break;
            case 1:
                QualitySettings.shadowDistance = 25;
                break;
            case 2:
                QualitySettings.shadowDistance = 50;
                break;
            case 3:
                QualitySettings.shadowDistance = 100;
                break;
            case 4:
                QualitySettings.shadowDistance = 150;
                break;
            case 5:
                QualitySettings.shadowDistance = 300;
                break;
            default:
                break;
            
                
        }
    }

    public void SoftParticles(bool isOn)
    {
        softParticles = isOn;
        QualitySettings.softParticles = isOn;
    }
    public void ChangeAntiAliasing(int index)
    {
        indexForAntiAliasing = index;
        switch (index)
        {
            case 0:
                QualitySettings.antiAliasing = 0;
                break;
            case 1:
                QualitySettings.antiAliasing = 2;
                break;
            case 2:
                QualitySettings.antiAliasing = 4;
                break;
            case 3:
                QualitySettings.antiAliasing = 8;
                break;
            default:
                break;
        }
    }

    public void EnableVSync(int index)
    {
        VSyncIndex = index;
        switch (index)
        {
            case 0:
                QualitySettings.vSyncCount = index;
                break;
            case 1:
                QualitySettings.vSyncCount = index;
                break;
            case 2:
                QualitySettings.vSyncCount = index;
                break;
            default:
                break;
        }
        
    }
    public void SetShadowResolution(int index)
    {
        ShadowResolutionIndex = index;
        switch (index)
        {
            case 0:
                QualitySettings.shadowResolution = ShadowResolution.Low;
                break;
            case 1:
                QualitySettings.shadowResolution = ShadowResolution.Medium;
                break;
            case 2:
                QualitySettings.shadowResolution = ShadowResolution.High;
                break;
            case 3:
                QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
                break;
            default:
                break;
        }
    }

    public void SetShadowQuality(int index)
    {
        QualityShadowIndex = index;
        switch (index)
        {
            case 0:
                QualitySettings.shadows = ShadowQuality.Disable;
                break;
            case 1:
                QualitySettings.shadows = ShadowQuality.HardOnly;
                break;
            case 2:
                QualitySettings.shadows = ShadowQuality.All;
                break;
            default:
                break;
        }
    }
}