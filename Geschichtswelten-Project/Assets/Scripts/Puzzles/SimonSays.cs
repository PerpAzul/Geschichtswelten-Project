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

    #region Audio

    [SerializeField] private AudioClip fail;
    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip redButton;
    [SerializeField] private AudioClip greenButton;
    [SerializeField] private AudioClip yellowButton;
    [SerializeField] private AudioClip blueButton;
    [SerializeField] private AudioSource generalAudioSource;

    #endregion

    [SerializeField] private GameObject door;
    [SerializeField] private Button RedButton;
    [SerializeField] private Button BlueButton;
    [SerializeField] private Button YellowButton;
    [SerializeField] private Button GreenButton;
    public List<Colors> solutionList = new List<Colors>();
    public List<Colors> playersInput = new List<Colors>();
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

        playersInput = new List<Colors>();
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
            if (solutionList[j].Equals(Colors.Red))
            {
                RedButton.DeactivateRenderer();
                yield return new WaitForSeconds(0.3f);
                generalAudioSource.PlayOneShot(redButton);
                RedButton.ActivateRenderer();
                yield return new WaitForSeconds(0.3f);
            }
            else if (solutionList[j].Equals(Colors.Blue))
            {
                BlueButton.DeactivateRenderer();
                yield return new WaitForSeconds(0.3f);
                generalAudioSource.PlayOneShot(blueButton);
                BlueButton.ActivateRenderer();
                yield return new WaitForSeconds(0.3f);
            }
            else if (solutionList[j].Equals(Colors.Yellow))
            {
                YellowButton.DeactivateRenderer();
                yield return new WaitForSeconds(0.3f);
                generalAudioSource.PlayOneShot(yellowButton);
                YellowButton.ActivateRenderer();
                yield return new WaitForSeconds(0.3f);
            }
            else if (solutionList[j].Equals(Colors.Green))
            {
                GreenButton.DeactivateRenderer();
                yield return new WaitForSeconds(0.3f);
                generalAudioSource.PlayOneShot(greenButton);
                GreenButton.ActivateRenderer();
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    private void EndGame()
    {
        StopAllCoroutines();
        StartCoroutine(FlashFailureColors());
        //Debug.Log("In EndGame");
        playersInput = new List<Colors>();
        solutionList = new List<Colors>();
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
        RedButton.ApplyNewColor(new Color(255, 0, 0));
        YellowButton.ApplyNewColor(new Color(255, 0, 0));
        BlueButton.ApplyNewColor(new Color(255, 0, 0));
        GreenButton.ApplyNewColor(new Color(255, 0, 0));

        for (int i = 0; i < 2; i++)
        {
            GreenButton.DeactivateRenderer();
            RedButton.DeactivateRenderer();
            BlueButton.DeactivateRenderer();
            YellowButton.DeactivateRenderer();
            yield return new WaitForSeconds(0.3f);
            generalAudioSource.PlayOneShot(fail);
            GreenButton.ActivateRenderer();
            RedButton.ActivateRenderer();
            BlueButton.ActivateRenderer();
            YellowButton.ActivateRenderer();
            yield return new WaitForSeconds(0.3f);
        }

        RedButton.ApplyNewColor(new Color(255, 0, 0));
        YellowButton.ApplyNewColor(new Color(255, 255, 0));
        BlueButton.ApplyNewColor(new Color(0, 0, 255));
        GreenButton.ApplyNewColor(new Color(0, 255, 0));
    }


    private IEnumerator Victory()
    {
        RedButton.ApplyNewColor(new Color(0, 255, 0));
        YellowButton.ApplyNewColor(new Color(0, 255, 0));
        BlueButton.ApplyNewColor(new Color(0, 255, 0));
        GreenButton.ApplyNewColor(new Color(0, 255, 0));

        for (int i = 0; i < 4; i++)
        {
            GreenButton.DeactivateRenderer();
            RedButton.DeactivateRenderer();
            BlueButton.DeactivateRenderer();
            YellowButton.DeactivateRenderer();
            yield return new WaitForSeconds(0.2f);
            generalAudioSource.PlayOneShot(success);
            GreenButton.ActivateRenderer();
            RedButton.ActivateRenderer();
            BlueButton.ActivateRenderer();
            YellowButton.ActivateRenderer();
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
            solutionList.Add(temp);
            counter++;
        }

        counter = 0;
        StartGame();
    }
}