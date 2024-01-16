using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public MedicineRoom MedicineRoom;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Box>().promptMessage.Equals("Medicine"))
        {
            MedicineRoom.Beds.Add("Medicine");
        }
        else if (other.gameObject.GetComponent<Box>().promptMessage.Equals("Hazard Medicine"))
        {
            MedicineRoom.Beds.Add("Hazard Medicine");
        }
        else if (other.gameObject.GetComponent<Box>().promptMessage.Equals("First Aid Medicine"))
        {
            MedicineRoom.Beds.Add("First Aid Medicine");
        }
    }
}