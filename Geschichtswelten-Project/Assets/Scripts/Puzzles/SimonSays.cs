using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class SimonSays : MonoBehaviour
{
    public enum Colors
    {
        Red,
        Blue,
        Yellow,
        Green
    }

    [SerializeField] private GameObject door;
    [SerializeField] private Button RedButton;
    [SerializeField] private Button BlueButton;
    [SerializeField] private Button YellowButton;
    [SerializeField] private Button GreenButton;
    public List<int> solutionList = new List<int>();
    public List<int> playersInput = new List<int>();
    private int counter = 0;
    public int count = 0;
    public int maxnumber;
    private bool stop;
    

    private void Start()
    {
        count = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            stop = false;
            PickColors();
        }
       
    }


    private void StartGame()
    {
        
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        for (int i = 0; i < maxnumber; i++)
        {
            StartCoroutine(FlashColors());
            yield return new WaitForSeconds(10f);
            CheckPlayerCount();
            if (stop)
            {
                yield return null;
            }
        }

        StartCoroutine(Victory());
    }

    private void CheckPlayerCount()
    {
        if (playersInput.Count != count + 1)
        {
            EndGame();
            stop = true;
            return;
        }
        else
        {
            CheckForRightButton();
        }
    }

    private void CheckForRightButton()
    {
        for (var j = 0; j <= count; j++)
        {
            //Debug.Log("In CheckForRightButton");
            //Debug.Log("J: " + j);
            if (playersInput[j] == solutionList[j])
            {
                Debug.Log("Right Button");
            }
            else
            {
                EndGame();
                stop = true;
                return;
            }
        }

        playersInput = new List<int>();
        count++;
    }

    private IEnumerator FlashColors()
    {
        for (int j = 0; j <= count; j++)
        {
            //Debug.Log(j);
            yield return new WaitForSeconds(0.1f);
            //Debug.Log("In For Loop");
            //flash color
            if (solutionList[j].Equals(0))
            {
                RedButton.GetComponent<Renderer>().enabled = false;
                yield return new WaitForSeconds(0.3f);
                RedButton.GetComponent<Renderer>().enabled = true;
                yield return new WaitForSeconds(0.3f);
            }
            else if (solutionList[j].Equals(1))
            {
                BlueButton.GetComponent<Renderer>().enabled = false;
                yield return new WaitForSeconds(0.3f);
                BlueButton.GetComponent<Renderer>().enabled = true;
                yield return new WaitForSeconds(0.3f);
            }
            else if (solutionList[j].Equals(2))
            {
                YellowButton.GetComponent<Renderer>().enabled = false;
                yield return new WaitForSeconds(0.3f);
                YellowButton.GetComponent<Renderer>().enabled = true;
                yield return new WaitForSeconds(0.3f);
            }
            else if (solutionList[j].Equals(3))
            {
                GreenButton.GetComponent<Renderer>().enabled = false;
                yield return new WaitForSeconds(0.3f);
                GreenButton.GetComponent<Renderer>().enabled = true;
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    private void EndGame()
    {
        StopAllCoroutines();
        StartCoroutine(FlashFailureColors());
        //Debug.Log("In EndGame");
        playersInput = new List<int>();
        solutionList = new List<int>();
        counter = 0;
        count = 0;
        Invoke("BoxColliderOn", 2f);
    }

    private void BoxColliderOn()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    private IEnumerator FlashFailureColors()
    {
        RedButton.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
        YellowButton.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
        BlueButton.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
        GreenButton.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);

        for (int i = 0; i < 2; i++)
        {
            GreenButton.GetComponent<Renderer>().enabled = false;
            RedButton.GetComponent<Renderer>().enabled = false;
            BlueButton.GetComponent<Renderer>().enabled = false;
            YellowButton.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(0.3f);
            GreenButton.GetComponent<Renderer>().enabled = true;
            RedButton.GetComponent<Renderer>().enabled = true;
            BlueButton.GetComponent<Renderer>().enabled = true;
            YellowButton.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(0.3f);
        }

        RedButton.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
        YellowButton.GetComponent<MeshRenderer>().material.color = new Color(255, 255, 0);
        BlueButton.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 255);
        GreenButton.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0);
    }


    private IEnumerator Victory()
    {
        RedButton.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0);
        YellowButton.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0);
        BlueButton.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0);
        GreenButton.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0);

        for (int i = 0; i < 4; i++)
        {
            GreenButton.GetComponent<Renderer>().enabled = false;
            RedButton.GetComponent<Renderer>().enabled = false;
            BlueButton.GetComponent<Renderer>().enabled = false;
            YellowButton.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            GreenButton.GetComponent<Renderer>().enabled = true;
            RedButton.GetComponent<Renderer>().enabled = true;
            BlueButton.GetComponent<Renderer>().enabled = true;
            YellowButton.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }

        door.GetComponent<Animation>().Play("HangarDoor1Open");
    }


    private void PickColors()
    {
        while (counter != maxnumber)
        {
            var values = Enum.GetValues(typeof(Colors));
            int random = Random.Range(0, values.Length);
            Colors temp = (Colors)random;
            solutionList.Add(random);
            counter++;
        }

        counter = 0;
        StartGame();
    }
}