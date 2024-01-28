using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    

    private static int _vSyncIndex;
    private static bool _softParticles;

    private static bool _isFullscreen;
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
            ChangeQuality(PlayerPrefs.GetInt("Quality") == 0 ? 2 : PlayerPrefs.GetInt("Quality"));
            ChangeAntiAliasing(PlayerPrefs.GetInt("AntiAliasing") == 0 ? 2 : PlayerPrefs.GetInt("AntiAliasing"));
            EnableVSync(PlayerPrefs.GetInt("VSync") == 0 ? 0 : PlayerPrefs.GetInt("VSync"));
            SetShadowQuality(PlayerPrefs.GetInt("ShadowQuality") == 0 ? 1 : PlayerPrefs.GetInt("ShadowQuality"));
            ChangeShadowDistance(PlayerPrefs.GetInt("ShadowDistance") == 0 ? 0 : PlayerPrefs.GetInt("ShadowDistance"));
            SetShadowResolution(PlayerPrefs.GetInt("ShadowResolution") == 0 ? 1 : PlayerPrefs.GetInt("ShadowResolution"));
            SoftParticles(_softParticles != false && _softParticles);
            setFullScreen(_isFullscreen);
            SetResolution(PlayerPrefs.GetInt("Resolution Value") == 0 ? 1 : PlayerPrefs.GetInt("Resolution Value"));
            SetSensitivityX(PlayerPrefs.GetFloat("SensitivityX") == 0f ? 0.25f : PlayerPrefs.GetFloat("SensitivityX"));
            SetSensitivityY(PlayerPrefs.GetFloat("SensitivityY") == 0f ? 0.25f : PlayerPrefs.GetFloat("SensitivityY"));
        }
    }

    // Start is called before the first frame update
    public void ChangeQuality(int index)
    {
        
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("Quality", index);
        quality.value = index;
    }

    public void setFullScreen(bool toIsFullscreen)
    {
        SettingMenu._isFullscreen = toIsFullscreen;
        Screen.fullScreen = toIsFullscreen;
        fullscreen.isOn = toIsFullscreen;
    }

    public void SetResolution(int index)
    {
      
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
        PlayerPrefs.SetInt("Resolution Value", index);
        resolution.value = index;
    }

    public void ChangeShadowDistance(int index)
    {
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
        PlayerPrefs.SetInt("ShadowDistance", index);
    }

    public void SoftParticles(bool isOn)
    {
        _softParticles = isOn;
        QualitySettings.softParticles = isOn;
        softParticles.isOn = isOn;
    }

    public void ChangeAntiAliasing(int index)
    {
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
        PlayerPrefs.SetInt("AntiAliasing", index);
        antiAliasing.value = index;
    }

    public void EnableVSync(int index)
    {
        //_vSyncIndex = index;
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
        PlayerPrefs.SetInt("VSync", index);
        vsync.value = index;
    }

    public void SetShadowResolution(int index)
    {
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
        PlayerPrefs.SetInt("ShadowResolution", index);
        shadowResolution.value = index;
    }

    public void SetSensitivityX(float value)
    {
        if (SceneManager.GetActiveScene().name.Equals("Start Menu"))
        {
            return;
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = value;
        }
        PlayerPrefs.SetFloat("SensitivityX", value);
        sensitivityX.value = value;
    }

    public void SetSensitivityY(float value)
    {
        if (SceneManager.GetActiveScene().name.Equals("Start Menu"))
        {
            return;
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Debug.Log("Changing");
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = value;
        }
        PlayerPrefs.SetFloat("SensitivityY", value);
        sensitivityY.value = value;
    }

    public void SetShadowQuality(int index)
    {
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
        PlayerPrefs.SetInt("ShadowQuality", index);
        shadowQuality.value = index;
    }
}