using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool hasCollision;
    private void OnCollisionEnter(Collision collision)
    {
        if (hasCollision)
        {
            hasCollision = false;
            return;
        }
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            hasCollision = true;
            Debug.Log("Hit Player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage();
            Invoke("ResetHasCollision", 1f);
        }
        
        Destroy(gameObject);
    }
    
    void ResetHasCollision()
    {
        hasCollision = false;
    }
}
