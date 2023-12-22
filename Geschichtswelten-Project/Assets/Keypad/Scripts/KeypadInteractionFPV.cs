using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace NavKeypad
{
    public class KeypadInteractionFPV : MonoBehaviour
    {
        public CinemachineVirtualCamera cam;

        private void Update()
        {
            //var ray = cam.ScreenPointToRay(Input.mousePosition);
            var ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse Clicked");
                if (Physics.Raycast(ray, out var hit))
                {
                    Debug.Log("RayCast shot");
                    if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                    {
                        Debug.Log("KeypadButton hit");
                        keypadButton.PressButton();
                    }
                }
            }
        }
    }
}