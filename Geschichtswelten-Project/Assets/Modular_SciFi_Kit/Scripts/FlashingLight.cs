using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour {
    public GameObject theLight;

    public float flashingSpeed;
	public float flashLength;

    string flashingType;

    Color lightBulbColor;
    // Choose between flashing and flickering light
    public bool flashing;

    public Color lightColor;

	void Start () {

        theLight.GetComponent<Light>().color = lightColor;

        if (flashing)
        {
            StartCoroutine(Flashing());
        }
        else
        {
            StartCoroutine(Flickering());
        }
		
	}

    // Flashing - Good for warning systems, the light turns off and on at regular intervals by setting the flashing speeds in the inspector. 
	IEnumerator Flashing() {

		while (true) {
            
            yield return new WaitForSeconds (flashingSpeed);
            theLight.GetComponent<Light> ().enabled = false;
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            yield return new WaitForSeconds (flashLength);
            theLight.GetComponent<Light> ().enabled = true;
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", lightColor);
        }
	}

    // Flickering - Good for broken / faulty lights, light turns off and on at random intervals.
    IEnumerator Flickering()
    {
        while (true) {
           
            yield return new WaitForSeconds(Random.Range(0, 0.3f));
            theLight.GetComponent<Light>().enabled = false;
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            yield return new WaitForSeconds(Random.Range(0, 0.3f));
            theLight.GetComponent<Light>().enabled = true;
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", lightColor);
        }
    }
}
