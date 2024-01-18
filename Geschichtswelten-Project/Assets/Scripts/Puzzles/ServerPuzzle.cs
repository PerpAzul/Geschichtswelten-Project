using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public enum ServerColors
{
    //Server Colors
    Yellow,
    Green,
    Red,
    Blue,

    //Left Side
    White,
    Pink,
    LightBlue
}


public class ServerPuzzle : MonoBehaviour
{
    public List<MeshRenderer> _plugs = new List<MeshRenderer>();
    [SerializeField] private Material _pink;
    [SerializeField] private Material white;
    public List<ServerColors> solution = new List<ServerColors>();
    public List<MeshRenderer> Servers = new List<MeshRenderer>();
    public List<GameObject> _BoxServer = new List<GameObject>();
    public List<ServerColors> playerInput = new List<ServerColors>();
    [SerializeField] private KeycardScene2 _keycard;
    private bool ActivateOtherServers = false;
    private bool activateSolition = false;
    [SerializeField] private GameObject screenBlack;
    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject Light1;
    [SerializeField] private GameObject Light2;
    [SerializeField] private GameObject plug1;
    [SerializeField] private GameObject plug2;

    private void Awake()
    {
        SelectRandomColor();
        plug1.GetComponent<MeshRenderer>().enabled = false;
        plug2.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        for (int i = 0; i < _BoxServer.Count; i++)
        {
            Debug.Log(_BoxServer[i]);
            _BoxServer[i].GetComponent<BoxCollider>().enabled = false;
            _BoxServer[i].GetComponent<Server>().promptMessage = "";
        }
    }

    private void Update()
    {
        if (!ActivateOtherServers)
        {
            if (playerInput.Count == 2)
            {
                Debug.Log("IN Turn");
                TurnOnOtherServers();
                plug1.GetComponent<MeshRenderer>().enabled = true;
                plug2.GetComponent<MeshRenderer>().enabled = true;
                ActivateOtherServers = true;
            }
        }

        if (!activateSolition)
        {
            if (playerInput.Count == 4)
            {
                CheckInput();
                activateSolition = true;
            }
        }
    }

    private void CheckInput()
    {
        for (int i = 0; i < solution.Count; i++)
        {
            if (!playerInput.Contains(solution[i]))
            {
                Failure();
                return;
            }
        }

        Victory();
    }

    private void TurnOnOtherServers()
    {
        for (int i = 0; i < Servers.Count; i++)
        {
            Servers[i].enabled = true;
        }

        
        Light2.SetActive(true);
        Light1.SetActive(true);
        for (int i = 0; i < _BoxServer.Count; i++)
        {
            _BoxServer[i].GetComponent<BoxCollider>().enabled = true;
            _BoxServer[i].GetComponent<Server>().promptMessage = _BoxServer[i].GetComponent<Server>().color.ToString();
        }
    }


    private void Victory()
    {
        GetComponent<BoxCollider>().enabled = true;
        screenBlack.SetActive(false);
        screen.SetActive(true);
    }

    private void Failure()
    {
        playerInput.RemoveRange(0, playerInput.Count);
        activateSolition = false;
    }

    private void SelectRandomColor()
    {
        //Selected Random Combinated Colors
        for (var i = 0; i <= 3; i++)
        {
            if (i % 2 == 0)
            {
                var valuesforServersOnRight = Enum.GetValues(typeof(ServerColors));
                var random2 = Random.Range(0, valuesforServersOnRight.Length - 3);
                var temp2 = (ServerColors)random2;
                solution.Add(temp2);
                continue;
            }

            var values = Enum.GetValues(typeof(ServerColors));
            var random = Random.Range(0, values.Length);
            var temp = (ServerColors)random;
            solution.Add(temp);
        }

        //Select Which Colors to showcase and Display
        for (int i = 0; i < solution.Count; i++)
        {
            switch (solution[i])
            {
                case ServerColors.Red:
                    _plugs[i].material.color = Color.red;
                    break;
                case ServerColors.Blue:
                    _plugs[i].material.color = Color.blue;
                    break;
                case ServerColors.Green:
                    _plugs[i].material.color = Color.green;
                    break;
                case ServerColors.Yellow:
                    _plugs[i].material.color = Color.yellow;
                    break;
                case ServerColors.White:
                    _plugs[i].material = white;
                    break;
                case ServerColors.Pink:
                    _plugs[i].material = _pink;
                    break;
                case ServerColors.LightBlue:
                    _plugs[i].material.color = Color.cyan;
                    break;
            }
        }
    }
}