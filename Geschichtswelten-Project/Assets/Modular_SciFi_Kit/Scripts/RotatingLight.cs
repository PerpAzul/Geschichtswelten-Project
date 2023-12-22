using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLight : MonoBehaviour {
    public float speed;

    public GameObject theLight;
    public GameObject theLightBulb;

    public Color lightColor;

    private void Start()
    {
        theLight.GetComponent<Light>().color = lightColor;
        theLightBulb.GetComponent<Renderer>().material.SetColor("_EmissionColor", lightColor);
    }

    // Update is called once per frame
    void Update () {
        theLightBulb.transform.Rotate(0, speed, 0);
	}
}
