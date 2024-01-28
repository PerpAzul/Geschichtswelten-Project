using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MiniBadgePuzzle : Interactable
{
    public List<string> solution = new List<string>();
    public List<Table> tables = new List<Table>();
    public List<string> input = new List<string>();
    public int count = 0;
    [SerializeField] private GameObject monitoron;
    [SerializeField] private GameObject monitoroff;
    [SerializeField] private GameObject monitorbox;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip fail;
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
        if (input.Count == 0)
        {
            _source.PlayOneShot(fail);
            input = new List<string>();
            return;
        }
        
        for (var i = 0; i < solution.Count; i++)
        {
            if (!input[i].Equals(solution[i]))
            {
                _source.PlayOneShot(fail);
                input = new List<string>();
                return;
            }
        }

        Winner();
    }

    private void Winner()
    {
        _source.PlayOneShot(win);
        GetComponent<BoxCollider>().enabled = false;
        monitorbox.GetComponent<BoxCollider>().enabled = true;
        monitoroff.SetActive(false);
        monitoron.SetActive(true);
        foreach (var table in tables)
        {
            table.GetComponent<BoxCollider>().enabled = false;
        }
    }
}