using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineRoom : Interactable
{
    public string _bed1;
    public string _bed2;
    public string _bed3;

    public string solution1;
    public string solution2;
    public string solution3;
    // Start is called before the first frame update

    protected override void Interact()
    {
        CheckBeds();
    }

    private void CheckBeds()
    {
        if (_bed1.Equals(solution1) && _bed2.Equals(solution2) && _bed3.Equals(solution3))
        {
            //Upgrade
            Debug.Log("Upgrade");
        }
    }

    private void Reset()
    {
        _bed1 = "";
        _bed2 = "";
        _bed3 = "";
    }
}