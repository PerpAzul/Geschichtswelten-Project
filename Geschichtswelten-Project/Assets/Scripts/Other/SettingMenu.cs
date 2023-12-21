using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
