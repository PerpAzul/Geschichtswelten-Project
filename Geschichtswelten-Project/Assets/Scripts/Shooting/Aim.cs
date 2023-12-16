using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class Aim : MonoBehaviour
{
   public Vector3 normalPose;
   public Vector3 aimPose;
   public float aimSpeed;
   private bool isAiming;
   public Camera cam;
   public GameObject crosshair;

   public void Start()
   {
      isAiming = false;
   }

   private void Update()
   {
      if (isAiming)
      {
         StartAiming();
      }
      else
      {
         StopAiming();
      }
   }

   public void StartAiming()
   {
      isAiming = true;
      transform.localPosition = Vector3.Slerp(transform.localPosition, aimPose, aimSpeed * Time.deltaTime);
      cam.fieldOfView -= 200 * Time.deltaTime;
      cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 30, 60);
      crosshair.SetActive(false);
   }

   public void StopAiming()
   {
      isAiming = false;
      transform.localPosition = Vector3.Slerp(transform.localPosition, normalPose, aimSpeed * Time.deltaTime);
      cam.fieldOfView += 200 * Time.deltaTime;
      cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 30, 60);
      crosshair.SetActive(true);
   }
}
