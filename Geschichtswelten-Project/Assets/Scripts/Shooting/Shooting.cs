using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float maxReload = 10f;
    public float maxAmmo;
    public float ammo;
    public float reloadTime = 1f;
    
    //UI
    [SerializeField] private TextMeshProUGUI ammoCount;
    [SerializeField] private GameObject hitmarkerUI;
    [SerializeField] private GameObject crosshairUI;

    public Camera cam;
    
    private bool isReloading;
    
    public ParticleSystem flash;

    public Animator animator;

    private void Start()
    {
        maxAmmo = 20f;
        ammo = maxReload;
        ammoCount.text = ammo + "/10";
        hitmarkerUI.gameObject.SetActive(false);
        crosshairUI.gameObject.SetActive(true);
    }

    public void Shoot()
    {
        if (ammo > 0)
        {
            ammo--;
            ammoCount.text = ammo + "/10";
            flash.Play();
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Enemy target = hit.transform.GetComponent<Enemy>();
                if (target != null)
                {
                    hitActive();
                    Invoke("hitDisable", 0.2f);
                    target.TakeDamage(damage);
                }
            }
        }
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        
        animator.SetBool("Reloading", true);
        
        yield return new WaitForSeconds(reloadTime - 0.25f);
        
        animator.SetBool("Reloading", false);
        
        yield return new WaitForSeconds(0.25f);

        if (maxAmmo >= 10 || ammo + maxAmmo >= 10)
        {
            maxAmmo -= (maxReload - ammo);
            ammo = maxReload;
        }
        else
        {
            ammo = maxAmmo;
            maxAmmo = 0;
        }

        ammoCount.text =  ammo + "/10";
        isReloading = false;
    }

    public void Reload()
    {
        if (isReloading == false && maxAmmo > 0 && ammo < 10)
        {
            StartCoroutine(Reloading());   
        }
    }

    public void pickAmmo()
    {
        maxAmmo += 5;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    
    private void hitActive()
    {
        crosshairUI.gameObject.SetActive(false);
        hitmarkerUI.gameObject.SetActive(true);
    }

    private void hitDisable()
    {
        crosshairUI.gameObject.SetActive(true);
        hitmarkerUI.gameObject.SetActive(false);
    }
}
