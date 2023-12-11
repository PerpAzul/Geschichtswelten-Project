using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public int maxHealth = 3;


    void Start()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        currentHealth--;
    }
}
