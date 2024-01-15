using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgePuzzle : Interactable
{
    public List<string> solution = new List<string>();
    public List<string> input = new List<string>();
    public List<Table> tables = new List<Table>();
    private List<Table> trash = new List<Table>();
    [SerializeField] private GameObject box;
    public int count = 0;
    public int count2 = 0;

    protected override void Interact()
    {
        GetBadges();
    }

    private void GetBadges()
    {
       
        for (int i = 0; i < tables.Count; i++)
        {
            {
                if (tables[i].badge.activeSelf)
                {
                    input[i] = tables[i].name;
                }
            }
        }

        CheckInput();
    }

    private void CheckInput()
    {
        for (var i = 0; i < solution.Count; i++)
        {
            if (!input[i].Equals(solution[i]))
            {
                ResetList();
                return;
            }
        }

        Winner();
    }

    private void Winner()
    {
        box.GetComponent<Animation>().Play("Crate_Open");
    }

    private void ResetList()
    {
        count = count2;
        for (int i = 0; i < input.Count; i++)
        {
            input[i] = "";
        }

        for (int i = 0; i < tables.Count; i++)
        {
            tables[i].DisableBadge();
        }
    }
}