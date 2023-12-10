using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float rotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        
        //calculate camera rotation for looking up and down
        rotation -= (mouseY * Time.deltaTime) * ySensitivity;
        rotation = Mathf.Clamp(rotation, -80f, 80f);
        
        //apply this to camera transform
        cam.transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        
        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
