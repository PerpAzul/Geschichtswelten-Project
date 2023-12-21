using System;
using NavKeypad;
using UnityEngine;
using UnityEngine.Serialization;


public class OpenDoor : MonoBehaviour
{
    //public List<PressurePlate> PressurePlates = new List<PressurePlate>();
    [SerializeField] private PressurePlate pressurePlate1;
    [SerializeField] private PressurePlate pressurePlate2; 
    public Animator animator;
    public AudioClip _clip;
    public AudioSource _Source;
    private bool canPlay;
    public Keypad _keypad;
    
    

    private void Update()
    {
        if (pressurePlate1.isActivated && pressurePlate2.isActivated || pressurePlate2.isActivated && pressurePlate1.isActivated || _keypad.stopDoor)
        {
            PlayOpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    public void CloseDoor()
    {
        animator.SetBool("OpenDoor",false);
        canPlay = false;
    }

    public void PlayOpenDoor()
    {
        animator.SetBool("OpenDoor",true);
        PlaySound();
    }

    private void PlaySound()
    {
        if (!canPlay)
        {
            _Source.PlayOneShot(_clip);
            canPlay = true;
        }
    }
}
