using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithCutscene : MonoBehaviour
{
    public CutsceneInput cutsceneInput;
    public CutsceneInput.ContinueActions cutsceneActions;
    public Cutscene_Manager_2 CutsceneManager2;
    public int index;


    private CutsceneManager _skip;

    void Awake()
    {
        cutsceneInput = new CutsceneInput();
        cutsceneActions = cutsceneInput.Continue;

        _skip = GetComponent<CutsceneManager>();
        CutsceneManager2 = GetComponent<Cutscene_Manager_2>();

        switch (index)
        {
            case 0:
                cutsceneActions.Skip.performed += ctx => _skip.Skip();
                break;
            case 1:
                cutsceneActions.Skip.performed += ctx => CutsceneManager2.skip();
                break;
        }
    }

    private void OnEnable()
    {
        cutsceneActions.Enable();
    }

    private void OnDisable()
    {
        cutsceneActions.Disable();
    }
}