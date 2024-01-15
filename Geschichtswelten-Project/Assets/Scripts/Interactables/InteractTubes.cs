using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InteractTubes : Interactable
{
    [SerializeField] private GameObject tube1;
    [SerializeField] private GameObject tube2;
    [SerializeField] private GameObject tube3;
    [SerializeField] private GameObject tube4;
    [SerializeField] private GameObject tube5;
    [SerializeField] private GameObject tube6;
    [SerializeField] private int index;

    protected override void Interact()
    {
        switch (index)
        {
            case 2:
                Change2Tubes();
                break;
            case 3:
                Change3Tubes();
                break;
            case 4:
                Change4Tubes();
                break;
            case 7:
                Reset();
                break;
        }
    }

    public void Change2Tubes()
    {
        if (tube1.gameObject.activeSelf)
        {
            tube1.SetActive(false);
        }
        else
        {
            tube1.SetActive(true);
        }

        if (tube2.gameObject.activeSelf)
        {
            tube2.SetActive(false);
        }
        else
        {
            tube2.SetActive(true);
        }
    }

    public void Change3Tubes()
    {
        if (tube1.gameObject.activeSelf)
        {
            tube1.SetActive(false);
        }
        else
        {
            tube1.SetActive(true);
        }

        if (tube2.gameObject.activeSelf)
        {
            tube2.SetActive(false);
        }
        else
        {
            tube2.SetActive(true);
        }
        
        if (tube3.gameObject.activeSelf)
        {
            tube3.SetActive(false);
        }
        else
        {
            tube3.SetActive(true);
        }
    }

    public void Change4Tubes()
    {
        if (tube1.gameObject.activeSelf)
        {
            tube1.SetActive(false);
        }
        else
        {
            tube1.SetActive(true);
        }

        if (tube2.gameObject.activeSelf)
        {
            tube2.SetActive(false);
        }
        else
        {
            tube2.SetActive(true);
        }
        
        if (tube3.gameObject.activeSelf)
        {
            tube3.SetActive(false);
        }
        else
        {
            tube3.SetActive(true);
        }
        
        tube4.SetActive(false);
    }

    public void Reset()
    {
        tube1.SetActive(false);
        tube2.SetActive(false);
        tube3.SetActive(false);
        tube4.SetActive(false);
        tube5.SetActive(false);
        tube6.SetActive(false);
    }
}
