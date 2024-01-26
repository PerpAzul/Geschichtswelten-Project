using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BadgePuzzle : Interactable
{
    public List<string> solution = new List<string>();
    public List<string> input = new List<string>();
    public List<Table> tables = new List<Table>();
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject letter;
    [SerializeField] private GameObject zombie;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip fail;
    public int count = 0;

    private void Awake()
    {
        letter.SetActive(false);
    }

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
        _source.PlayOneShot(win);
        box.GetComponent<Animation>().Play("Crate_Open");
        GetComponent<BoxCollider>().enabled = false;
        zombie.SetActive(true);
        foreach (var table in tables)
        {
            letter.SetActive(true);
            box.GetComponent<BoxCollider>().enabled = false;
            table.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void ResetList()
    {
        input = new List<string>();
        _source.PlayOneShot(fail);
    }
}