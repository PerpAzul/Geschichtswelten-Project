using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerKeypad : MonoBehaviour
{
    public KeypadInput keypadInput;
    public KeypadInput.KeypadExitActions keypadActions;


    private InteractWithKeypad exit;

    void Awake()
    {
        
        keypadInput = new KeypadInput();
        keypadActions = keypadInput.KeypadExit;

        exit = GetComponent<InteractWithKeypad>();

        keypadActions.Exit.performed += ctx => exit.Exit();
    }

    private void OnEnable()
    {
        keypadActions.Enable();
        
    }

    private void OnDisable()
    {
        keypadActions.Disable();
    }
}
