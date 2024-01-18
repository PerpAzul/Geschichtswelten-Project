using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public MedicineRoom MedicineRoom;
    public string name;
    private void OnTriggerStay(Collider other)
    {
        switch (name)
        {
            case "Subject A":
                MedicineRoom._bed1 = other.gameObject.GetComponent<Box>().promptMessage;
                break;
            case "Subject B":
                MedicineRoom._bed2 = other.gameObject.GetComponent<Box>().promptMessage;
                break;
            case "Subject C":
                MedicineRoom._bed3 = other.gameObject.GetComponent<Box>().promptMessage;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (name)
        {
            case "Subject A":
                MedicineRoom._bed1 = "";
                break;
            case "Subject B":
                MedicineRoom._bed2 = "";
                break;
            case "Subject C":
                MedicineRoom._bed3 = "";
                break;
            default:
                break;
        }
    }
}