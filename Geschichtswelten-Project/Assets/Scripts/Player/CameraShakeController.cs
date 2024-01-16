using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraShakeController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    [SerializeField] private float cameraShakeRunning = 3;
    [SerializeField] private float cameraShakeAiming = 0.1f;
    [SerializeField] private float cameraShakeWalking = 1; //default
    [SerializeField] private float cameraShakeWhenHit = 10;
    [SerializeField] private float increaseTimeHitShake = 0.1f; // in seconds
    private bool cameraShakeShouldDecrease = false;
    private bool cameraShakeShouldIncrease = false;
    private bool cameraShakeGotHit = false;
    private float currentAmplitudeGain;
    private float stepSize;
    private float amplitudeTarget;

   [SerializeField] private float smoothingTime; //in seconds. describes how many seconds it will take for the cameraShakey-ness to fully increase/decrease between different values;

   
    // Start is called before the first frame update
    void Start()
    {
        currentAmplitudeGain = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraShakeGotHit)
        {
            
        }
        if (cameraShakeShouldIncrease)
        {
            currentAmplitudeGain += stepSize * Time.deltaTime;
            
            if (currentAmplitudeGain >= amplitudeTarget)
            {
                currentAmplitudeGain = amplitudeTarget;
            }
            _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = currentAmplitudeGain;
        } 
        if (cameraShakeShouldDecrease)
        {
            currentAmplitudeGain -= stepSize * Time.deltaTime;
            if (currentAmplitudeGain <= amplitudeTarget)
            {
                currentAmplitudeGain = amplitudeTarget;
            }
            _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = currentAmplitudeGain;
        }
    }

    public void StartRunning()
    {
        Increase(cameraShakeRunning, smoothingTime);
    }

    public void StopRunning()
    {
       Decrease(cameraShakeWalking, smoothingTime);
    }

    public void StartAiming()
    {
        Decrease(cameraShakeAiming, smoothingTime);
    }

    public void StopAiming()
    {
        Increase(cameraShakeWalking, smoothingTime);
    }

    public void TakeDamage()
    {
        var oldTarget = amplitudeTarget;
        Increase(cameraShakeWhenHit, increaseTimeHitShake);
        StartCoroutine(DecreaseAfterHit(oldTarget));

    }

    IEnumerator DecreaseAfterHit(float oldTarget)
    {
        yield return new WaitForSeconds(increaseTimeHitShake);
        Decrease(oldTarget, smoothingTime); //in case that there was currently a Decrease/Increase going on. Also amplitudeTarget should always has the previous currentAmplitude to return to, if there was no increase/decrease
    }

    private void Increase(float increaseTo, float timeScaleForIncrease)
    {
        if (currentAmplitudeGain >= increaseTo)
        {
            return;
        }
        cameraShakeShouldIncrease = true;
        cameraShakeShouldDecrease = false;
        stepSize = (increaseTo - currentAmplitudeGain)/timeScaleForIncrease;
        amplitudeTarget = increaseTo;
    }

    private void Decrease(float decreaseTo, float timeScaleForDecrease)
    {
        if (currentAmplitudeGain <= decreaseTo)
        {
            return;
        }
        cameraShakeShouldIncrease = false;
        cameraShakeShouldDecrease = true;
        stepSize = (currentAmplitudeGain - decreaseTo)/timeScaleForDecrease;
        amplitudeTarget = decreaseTo;

    }
}