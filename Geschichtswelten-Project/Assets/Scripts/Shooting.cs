using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float maxReload = 10f;
    public float maxAmmo;
    public float ammo;
    public float reloadTime = 1f;

    public Camera cam;
    
    private bool isReloading;
    
    public ParticleSystem flash;

    public Animator animator;

    private void Start()
    {
        maxAmmo = 20f;
        ammo = maxReload;
    }

    public void Shoot()
    {
        if (ammo > 0)
        {
            ammo--;
            flash.Play();
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
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
}
