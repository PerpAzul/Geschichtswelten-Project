using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractWithKeypad : Interactable
{
   public CinemachineFreeLook _KeypadCam;
   public CinemachineVirtualCamera mainCamera;
   protected override void Interact()
   {
      _KeypadCam.Priority = 10;
      mainCamera.Priority = 0;
   }
}
