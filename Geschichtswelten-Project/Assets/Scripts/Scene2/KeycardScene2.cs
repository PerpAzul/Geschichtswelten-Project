using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardScene2 : Interactable
{
    public bool hasKey;
    public int upgradeIndex;

    private void Awake()
    {
        hasKey = false;
        upgradeIndex = 0;
    }

    protected override void Interact()
    {
        hasKey = true;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    public void UpgradeKeycard()
    {
        upgradeIndex++;
    }
}
