using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithCutscene : MonoBehaviour
{
    public CutsceneInput cutsceneInput;
    public CutsceneInput.ContinueActions cutsceneActions;


    private CutsceneManager skip;

    void Awake()
    {
        
        cutsceneInput = new CutsceneInput();
        cutsceneActions = cutsceneInput.Continue;

        skip = GetComponent<CutsceneManager>();

        cutsceneActions.Skip.performed += ctx => skip.Skip();
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
