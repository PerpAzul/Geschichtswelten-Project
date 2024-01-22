using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineRoom : MonoBehaviour
{
    public string _bed1;
    public string _bed2;
    public string _bed3;

    public string solution1;
    public string solution2;
    public string solution3;

    public GameObject monitor1;
    public GameObject monitor2;
    public GameObject upgrade;
    private bool canUpgrade;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip clip;


    private void Update()
    {
        if (!canUpgrade)
        {
            if (_bed1.Equals(solution1) && _bed2.Equals(solution2) && _bed3.Equals(solution3))
            {
                _source.PlayOneShot(clip);
                Debug.Log("solved");
                monitor1.SetActive(false);
                monitor2.SetActive(true);
                upgrade.GetComponent<BoxCollider>().enabled = true;
                canUpgrade = true;
            }
        }
    }

    private void Reset()
    {
        _bed1 = "";
        _bed2 = "";
        _bed3 = "";
    }
}