using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    private static int _indexForGame;

    private static int _indexForAntiAliasing;

    private static int _vSyncIndex;

    private static int _qualityShadowIndex;

    private static int _shadowResolutionIndex;

    private static int _shadowDistanceIndex;

    private static bool _softParticles;

    private static bool _isFullscreen;

    private static int _indexResolution;

    private static float _sensitivityX;
    private static float _sensitivityY;

    [SerializeField] private CinemachineVirtualCamera playerCam;

    #region Dropdowns

    [Header("Sliders and Dropdowns")] [SerializeField]
    private TMP_Dropdown resolution;

    //[SerializeField] private TMP_Dropdown shadowDistance;
    [SerializeField] private TMP_Dropdown antiAliasing;
    [SerializeField] private TMP_Dropdown quality;
    [SerializeField] private TMP_Dropdown vsync;
    [SerializeField] private TMP_Dropdown shadowQuality;
    [SerializeField] private TMP_Dropdown shadowResolution;
    [SerializeField] private Slider sensitivityX;
    [SerializeField] private Slider sensitivityY;
    [SerializeField] private Toggle fullscreen;
    [SerializeField] private Toggle softParticles;

    #endregion
    //[SerializeField] private Dropdown advancedOptions;

    //https://www.youtube.com/watch?v=YOaYQrN1oYQ adapted some options from here
    private void Awake()
    {
        if (!SceneManager.GetActiveScene().ToString().Equals("Start Menu"))
        {
            Debug.Log(_indexForGame);
            ChangeQuality(_indexForGame == 0 ? 2 : _indexForGame);
            ChangeAntiAliasing(_indexForAntiAliasing == 0 ? 2 : _indexForAntiAliasing);
            EnableVSync(_vSyncIndex == 0 ? 0 : _vSyncIndex);
            SetShadowQuality(_qualityShadowIndex == 0 ? 1 : _qualityShadowIndex);
            //ChangeShadowDistance(_shadowDistanceIndex == 0 ? 0 : _shadowDistanceIndex);
            SetShadowResolution(_shadowResolutionIndex == 0 ? 1 : _shadowResolutionIndex);
            SoftParticles(_softParticles != false && _softParticles);
            setFullScreen(_isFullscreen);
            SetResolution(_indexResolution == 0 ? 1 : _indexResolution);
            SetSensitivityX(_sensitivityX == 0f ? 0.25f : _sensitivityX);
            SetSensitivityY(_sensitivityY == 0f ? 0.25f : _sensitivityX);
        }
    }

    // Start is called before the first frame update
    public void ChangeQuality(int index)
    {
        _indexForGame = index;
        QualitySettings.SetQualityLevel(index);
        quality.value = _indexForGame;
    }

    public void setFullScreen(bool toIsFullscreen)
    {
        SettingMenu._isFullscreen = toIsFullscreen;
        Screen.fullScreen = toIsFullscreen;
        fullscreen.isOn = toIsFullscreen;
    }

    public void SetResolution(int index)
    {
        _indexResolution = index;
        switch (index)
        {
            case 0:
                Screen.SetResolution(800, 600, _isFullscreen);
                break;
            case 1:
                Screen.SetResolution(1980, 1080, _isFullscreen);
                break;
            case 2:
                Screen.SetResolution(2160, 1440, _isFullscreen);
                break;
            case 3:
                Screen.SetResolution(2160, 1600, _isFullscreen);

                break;
            case 4:
                Screen.SetResolution(3840, 2160, _isFullscreen);
                break;
            default:
                break;
        }

        resolution.value = index;
    }

    public void ChangeShadowDistance(int index)
    {
        _shadowDistanceIndex = index;
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
        //Dunno why ShadowDistance does not work here
        //shadowDistance.value = _shadowDistanceIndex;
    }

    public void SoftParticles(bool isOn)
    {
        _softParticles = isOn;
        QualitySettings.softParticles = isOn;
        softParticles.isOn = isOn;
    }

    public void ChangeAntiAliasing(int index)
    {
        _indexForAntiAliasing = index;
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

        antiAliasing.value = index;
    }

    public void EnableVSync(int index)
    {
        _vSyncIndex = index;
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

        vsync.value = _vSyncIndex;
    }

    public void SetShadowResolution(int index)
    {
        _shadowResolutionIndex = index;
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

        shadowResolution.value = index;
    }

    public void SetSensitivityX(float value)
    {
        if (SceneManager.GetActiveScene().name.Equals("Start Menu"))
        {
            _sensitivityX = value;
            return;
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = value;
        }

        sensitivityX.value = value;
    }

    public void SetSensitivityY(float value)
    {
        if (SceneManager.GetActiveScene().name.Equals("Start Menu"))
        {
            _sensitivityY = value;
            return;
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Debug.Log("Changing");
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = value;
        }

        sensitivityY.value = value;
    }

    public void SetShadowQuality(int index)
    {
        _qualityShadowIndex = index;
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

        shadowQuality.value = index;
    }
}