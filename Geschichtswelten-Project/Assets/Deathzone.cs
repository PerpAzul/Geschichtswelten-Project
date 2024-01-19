using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    public List<GameObject> Objects = new List<GameObject>();

    public List<GameObject> locationsToRespawn = new List<GameObject>();
    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Objects.Count; i++)
        {
            if (Objects[i].Equals(other.gameObject))
            {
                count = i;
                break;
            }
        }

        Objects[count].transform.position = locationsToRespawn[count].transform.position;
        Objects[count].transform.rotation = new Quaternion(0, 0, 0, 0);
        Objects[count].transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        count = 0;
    }
}
