using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineRoom : Interactable
{
    public List<string> Beds = new List<string>();

    public List<string> solution = new List<string>();
    // Start is called before the first frame update

    protected override void Interact()
    {
        CheckBeds();
    }

    private void CheckBeds()
    {
        for (int i = 0; i < solution.Count; i++)
        {
            if (!Beds[i].Equals(solution[i]))
            {
                Reset();
                return;
            }
        }
        //Upgrade Card
    }

    private void Reset()
    {
        solution = new List<string>();
    }
}
