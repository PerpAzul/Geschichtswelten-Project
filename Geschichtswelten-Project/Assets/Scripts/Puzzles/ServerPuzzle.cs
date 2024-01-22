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
    Yellow2,
    Green2,
    Red2,
    Blue2,

    //Left Side
    Yellow,
    Green,
    Red,
    Blue,
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
    public List<ServerColors> solution2 = new List<ServerColors>();
    public List<MeshRenderer> Servers = new List<MeshRenderer>();
    public List<MeshRenderer> ServersFront = new List<MeshRenderer>();
    public List<GameObject> _BoxServer = new List<GameObject>();
    public List<GameObject> _BoxServerFront = new List<GameObject>();
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
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip fail;

    private void Awake()
    {
        SelectRandomColor();
        SelectRandomColor2();
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
                Debug.Log("count");
                if (CheckInput())
                {
                    Debug.Log("checkinput");
                    TurnOnOtherServers();
                    TurnOffOtherServers();
                    plug1.GetComponent<MeshRenderer>().enabled = true;
                    plug2.GetComponent<MeshRenderer>().enabled = true;
                    ActivateOtherServers = true;
                    activateSolition = true;
                    Failure2();
                }
            }
        }

        if (activateSolition)
        {
            if (playerInput.Count == 2)
            {
                if (CheckInput2())
                {
                    TurnOffOtherServers2();
                    activateSolition = false;
                    Victory();
                }
            }
        }
    }

    private bool CheckInput()
    {
        for (int i = 0; i < solution.Count; i++)
        {
            if (!playerInput.Contains(solution[i]))
            {
                Failure();
                return false;
            }
        }

        return true;
    }
    
    private bool CheckInput2()
    {
        for (int i = 0; i < solution2.Count; i++)
        {
            if (!playerInput.Contains(solution2[i]))
            {
                Failure();
                return false;
            }
        }

        return true;
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
    
    private void TurnOffOtherServers()
    {
        for (int i = 0; i < ServersFront.Count; i++)
        {
            ServersFront[i].enabled = false;
        }
        
        for (int i = 0; i < _BoxServerFront.Count; i++)
        {
            _BoxServerFront[i].GetComponent<BoxCollider>().enabled = false;
            _BoxServerFront[i].GetComponent<Server>().promptMessage = "";
        }
    }
    
    private void TurnOffOtherServers2()
    {
        for (int i = 0; i < Servers.Count; i++)
        {
            Servers[i].enabled = false;
        }
        
        for (int i = 0; i < _BoxServer.Count; i++)
        {
            _BoxServer[i].GetComponent<BoxCollider>().enabled = false;
            _BoxServer[i].GetComponent<Server>().promptMessage = "";
        }
    }


    private void Victory()
    {
        _source.PlayOneShot(win);
        GetComponent<BoxCollider>().enabled = true;
        screenBlack.SetActive(false);
        screen.SetActive(true);
    }

    private void Failure()
    {
        _source.PlayOneShot(fail);
        Debug.Log("failure");
        playerInput = new List<ServerColors>();
        
    }

    private void Failure2()
    {
        Debug.Log("failure");
        playerInput = new List<ServerColors>();
    }

    private void SelectRandomColor()
    {
        //Selected Random Combinated Colors
        for (var i = 0; i <= 1; i++)
        {
            if (i % 2 == 0)
            {
                var valuesforServersOnRight = Enum.GetValues(typeof(ServerColors));
                var random2 = Random.Range(0, valuesforServersOnRight.Length - 7);
                var temp2 = (ServerColors)random2;
                solution.Add(temp2);
                continue;
            }

            var values = Enum.GetValues(typeof(ServerColors));
            var random = Random.Range(4, values.Length);
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
                case ServerColors.Red2:
                    _plugs[i].material.color = Color.red;
                    break;
                case ServerColors.Blue2:
                    _plugs[i].material.color = Color.blue;
                    break;
                case ServerColors.Green2:
                    _plugs[i].material.color = Color.green;
                    break;
                case ServerColors.Yellow2:
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
    
    private void SelectRandomColor2()
    {
        //Selected Random Combinated Colors
        for (var i = 0; i <= 1; i++)
        {
            if (i % 2 == 0)
            {
                var valuesforServersOnRight = Enum.GetValues(typeof(ServerColors));
                var random2 = Random.Range(0, valuesforServersOnRight.Length - 7);
                var temp2 = (ServerColors)random2;
                solution2.Add(temp2);
                continue;
            }

            var values = Enum.GetValues(typeof(ServerColors));
            var random = Random.Range(4, values.Length);
            var temp = (ServerColors)random;
            solution2.Add(temp);
        }

        //Select Which Colors to showcase and Display
        for (int i = 0; i < solution2.Count; i++)
        {
            switch (solution2[i])
            {
                case ServerColors.Red:
                    _plugs[i+2].material.color = Color.red;
                    break;
                case ServerColors.Blue:
                    _plugs[i+2].material.color = Color.blue;
                    break;
                case ServerColors.Green:
                    _plugs[i+2].material.color = Color.green;
                    break;
                case ServerColors.Yellow:
                    _plugs[i+2].material.color = Color.yellow;
                    break;
                case ServerColors.Red2:
                    _plugs[i+2].material.color = Color.red;
                    break;
                case ServerColors.Blue2:
                    _plugs[i+2].material.color = Color.blue;
                    break;
                case ServerColors.Green2:
                    _plugs[i+2].material.color = Color.green;
                    break;
                case ServerColors.Yellow2:
                    _plugs[i+2].material.color = Color.yellow;
                    break;
                case ServerColors.White:
                    _plugs[i+2].material = white;
                    break;
                case ServerColors.Pink:
                    _plugs[i+2].material = _pink;
                    break;
                case ServerColors.LightBlue:
                    _plugs[i+2].material.color = Color.cyan;
                    break;
            }
        }
    }
}