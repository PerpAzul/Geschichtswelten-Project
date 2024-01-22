using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSimonSays : MonoBehaviour
{
    public List<string> solution = new List<string>();
    public List<string> input = new List<string>();
    [SerializeField] private ButtonScene2 _redButton;
    [SerializeField] private ButtonScene2 _orangeButton;
    [SerializeField] private ButtonScene2 _purpleButton;
    [SerializeField] private ButtonScene2 _greenButton;
    [SerializeField] private AudioSource generalAudioSource;
    [SerializeField] private AudioClip fail;
    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip _clip;
    private bool hasInput;

    [SerializeField] private GameObject monitorbox;
    [SerializeField] private GameObject monitoroff;
    [SerializeField] private GameObject monitoron;

    private void Update()
    {
        if (input.Count == 4)
        {
            if (hasInput)
            {
                return;
            }
            Game();
            hasInput = true;
        }
    }

    private void Game()
    {
        for (var i = 0; i < input.Count; i++)
        {
            if (!input[i].Equals(solution[i]))
            {
                
                hasInput = true;
                StartCoroutine(FlashFailureColors());
                return;
            }
        }
        Debug.Log("Correct");
        StartCoroutine(Victory());
    }
    private IEnumerator FlashFailureColors()
    {
        _greenButton.RemoveInteractText();
        _redButton.RemoveInteractText();
        _purpleButton.RemoveInteractText();
        _orangeButton.RemoveInteractText();
        _greenButton.DisableBoxCollider();
        _redButton.DisableBoxCollider();
        _purpleButton.DisableBoxCollider();
        _orangeButton.DisableBoxCollider();
        var orange = _orangeButton.GetComponent<Renderer>().material.color;
        var purple = _purpleButton.GetComponent<Renderer>().material.color;
        var red = _redButton.GetComponent<Renderer>().material.color;
        var green = _greenButton.GetComponent<Renderer>().material.color;
        _redButton.ApplyNewColor(new Color(255, 0, 0));
        _purpleButton.ApplyNewColor(new Color(255, 0, 0));
        _orangeButton.ApplyNewColor(new Color(255, 0, 0));
        _greenButton.ApplyNewColor(new Color(255, 0, 0));

        for (int i = 0; i < 3; i++)
        {
            _greenButton.DeactivateRenderer();
            _redButton.DeactivateRenderer();
            _orangeButton.DeactivateRenderer();
            _purpleButton.DeactivateRenderer();
            yield return new WaitForSeconds(0.3f);
            generalAudioSource.PlayOneShot(fail);
            _greenButton.ActivateRenderer();
            _redButton.ActivateRenderer();
            _orangeButton.ActivateRenderer();
            _purpleButton.ActivateRenderer();
            yield return new WaitForSeconds(0.3f);
        }

        _redButton.ApplyNewColor(red);
        _purpleButton.ApplyNewColor(purple);
        _orangeButton.ApplyNewColor(orange);
        _greenButton.ApplyNewColor(green);
        _greenButton.AddInteractText();
        _redButton.AddInteractText();
        _purpleButton.AddInteractText();
        _orangeButton.AddInteractText();
        _greenButton.EnableBoxCollider2();
        _redButton.EnableBoxCollider2();
        _purpleButton.EnableBoxCollider2();
        _orangeButton.EnableBoxCollider2();
        input.Remove(input[3]);
        input.Remove(input[2]);
        input.Remove(input[1]);
        input.Remove(input[0]);
        hasInput = false;
    }
    
    private IEnumerator Victory()
    {
        monitorbox.GetComponent<BoxCollider>().enabled = true;
        monitoroff.SetActive(false);
        monitoron.SetActive(true);
        _greenButton.RemoveInteractText();
        _redButton.RemoveInteractText();
        _purpleButton.RemoveInteractText();
        _orangeButton.RemoveInteractText();
        _redButton.ApplyNewColor(new Color(0, 255, 0));
        _purpleButton.ApplyNewColor(new Color(0, 255, 0));
        _orangeButton.ApplyNewColor(new Color(0, 255, 0));
        _greenButton.ApplyNewColor(new Color(0, 255, 0));

        for (int i = 0; i < 3; i++)
        {
            _greenButton.DeactivateRenderer();
            _redButton.DeactivateRenderer();
            _orangeButton.DeactivateRenderer();
            _purpleButton.DeactivateRenderer();
            yield return new WaitForSeconds(0.2f);
            generalAudioSource.PlayOneShot(success);
            _greenButton.ActivateRenderer();
            _redButton.ActivateRenderer();
            _orangeButton.ActivateRenderer();
            _purpleButton.ActivateRenderer();
            yield return new WaitForSeconds(0.2f);
        }
        _greenButton.DisableBoxCollider();
        _redButton.DisableBoxCollider();
        _purpleButton.DisableBoxCollider();
        _orangeButton.DisableBoxCollider();
        yield return new WaitForSeconds(0.5f);
        generalAudioSource.PlayOneShot(_clip);
    }
}