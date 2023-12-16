using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    public float damage;
    public float timeBetweenShooting;
    public float spread;
    public float range;
    public float maxReload;
    public float maxAmmo;
    public float ammo;
    public float reloadTime;
    
    //UI
    [SerializeField] private TextMeshProUGUI ammoCount;
    [SerializeField] private GameObject hitmarkerUI;
    [SerializeField] private GameObject crosshairUI;

    public Camera cam;
    
    private bool isReloading;
    public bool isShooting;
    
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

    private void Update()
    {
        ammoCount.text = ammo + "/" + maxAmmo;
    }

    public void Shoot()
    {
        if (ammo > 0 && isShooting == false)
        {
            isShooting = true;
            ammo--;
            Invoke("ResetShot", timeBetweenShooting);
            flash.Play();

            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);
            Vector3 direction = cam.transform.forward + new Vector3(x, y, 0);
            
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, direction, out hit, range))
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

        if (maxAmmo >= maxReload || ammo + maxAmmo >= maxReload)
        {
            maxAmmo -= (maxReload - ammo);
            ammo = maxReload;
        }
        else
        {
            ammo += maxAmmo;
            maxAmmo = 0;
        }

        ammoCount.text =  ammo + "/10";
        isReloading = false;
    }

    public void Reload()
    {
        if (isReloading == false && maxAmmo > 0 && ammo < maxReload)
        {
            StartCoroutine(Reloading());   
        }
    }

    public void pickAmmo()
    {
        maxAmmo += 5;
    }

    public void ResetShot()
    {
        isShooting = false;
    }

    private void OnEnable()
    {
        isReloading = false;
        isShooting = false;
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
