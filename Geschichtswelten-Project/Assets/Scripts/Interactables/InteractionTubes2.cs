using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTubes2 : Interactable
{
   [SerializeField] private GameObject tube1;
    [SerializeField] private GameObject tube2;
    [SerializeField] private GameObject tube3;
    [SerializeField] private GameObject tube4;
    [SerializeField] private int index;
    [SerializeField] private GameObject monitor;
    [SerializeField] private LevelDoors orangeDoor;
    private bool isSolved;

    protected override void Interact()
    {
        switch (index)
        {
            case 1:
                Change1Tube();
                break;
            case 2:
                Change2Tubes();
                break;
            case 3:
                Change3Tubes();
                break;
            case 7:
                Reset();
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (!isSolved)
        {
            if (tube1.activeSelf == true && tube2.activeSelf == true && tube3.activeSelf == true && tube4.activeSelf == true)
            {
                monitor.GetComponent<BoxCollider>().enabled = false;
                orangeDoor.OpenDoor();
                isSolved = true;
            }
        }
    }

    public void Change1Tube()
    {
        if (tube1.gameObject.activeSelf)
        {
            tube1.SetActive(false);
        }
        else
        {
            tube1.SetActive(true);
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
        
        tube2.SetActive(false);
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
        
        tube3.SetActive(false);
    }

    public void Reset()
    {
        tube1.SetActive(false);
        tube2.SetActive(false);
        tube3.SetActive(false);
        tube4.SetActive(false);
    }
}
