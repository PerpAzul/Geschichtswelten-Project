using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgePuzzle : Interactable
{
    public List<string> solution = new List<string>();
    public List<string> input = new List<string>();
    public List<Table> tables = new List<Table>();
    private int count = 0;

    protected override void Interact()
    {
        GetBadges();
        CheckInput();
    }

    private void GetBadges()
    {
        foreach (var table in tables)
        {
            if (table.isTriggered)
            {
                input[count] = table.name;
                count++;
            }
        }
    }

    private void CheckInput()
    {
        for (int i = 0; i < solution.Count; i++)
        {
            if (input[i].Equals(solution[i]))
            {
                Debug.Log("Correct");
            }
        }
    }
}