using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone2 : MonoBehaviour
{
    public List<GameObject> Objects = new List<GameObject>();
    public List<GameObject> locations = new List<GameObject>();
    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Objects.Count; i++)
        {
            Objects[i].transform.position = locations[i].transform.position;
        }
    }
}