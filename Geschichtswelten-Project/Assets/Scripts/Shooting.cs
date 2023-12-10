using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera cam;
    private bool isShooting;
    public ParticleSystem flash;

    private void Update()
    {
        //if (isShooting)
        //{
        //    Shoot();
        //}
    }

    public void Shoot()
    {
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

    public void StartShoot()
    {
        isShooting = true;
    }
    
    public void EndShoot()
    {
        isShooting = false;
    }
}
