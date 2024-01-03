using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogSystemObject;
    [SerializeField] private List<string> dialogLines;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with:" + other.name);
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false); //the Dialog should only be triggered once when passing through the door
            dialogSystemObject.SetActive(true); // reactivate the dialog system if it was inactive
            dialogSystemObject.GetComponent<DialogSystem>().AddMultipleLines(dialogLines);
        }
    }
}
