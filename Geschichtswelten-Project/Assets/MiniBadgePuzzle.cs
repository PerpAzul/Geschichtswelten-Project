using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBadgePuzzle : Interactable
{
    public List<string> solution = new List<string>();
    public List<Table> tables = new List<Table>();
    public List<string> input = new List<string>();
    public int count = 0;


   

    protected override void Interact()
    {
        GetBadges();
    }

    private void GetBadges()
    {
        for (var i = 0; i < tables.Count; i++)
        {
            {
                if (tables[i].badge.activeSelf)
                {
                    input.Add(tables[i].name);
                }
            }
        }

        CheckInput();
    }

    private void CheckInput()
    {
        for (var i = 0; i < solution.Count; i++)
        {
            
            Debug.Log(input[i]);
            Debug.Log(solution[i]);
            if (!input[i].Equals(solution[i]))
            {
                input = new List<string>();
                return;
            }
        }

        Winner();
    }

    private void Winner()
    {
        GetComponent<BoxCollider>().enabled = false;
        foreach (var table in tables)
        {
            table.GetComponent<BoxCollider>().enabled = false;
        }
    }
}