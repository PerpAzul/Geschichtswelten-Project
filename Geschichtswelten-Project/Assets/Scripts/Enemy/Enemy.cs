using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastKnownPos;
    

    public NavMeshAgent Agent {get => agent;}
    public GameObject Player {get => player;}
    public Vector3 LastknowPos
    {
        get => lastKnownPos;
        set => lastKnownPos = value;
    }

    //Path
    public Way path;
    
    //Health
    public float health = 50f;
    
    //Sight Values
    public float sightDistance = 100f;
    public float fieldOfView = 90f;
    public float eyeHeight;
    
    //Weapon Values
    public Transform gunBarrel;
    [Range(0.1f, 10f)]
    public float fireRate;
    public ParticleSystem flash;
    
    //Index
    public int index;
    
    //Debug
    [SerializeField] private string currentState;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public void TakeDamage(float amount)
    {
        transform.LookAt(player.transform.position);
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit, sightDistance))
                    {
                        if (hit.transform.gameObject == player)
                        {
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                }
            }
        }
        return false;
    }
}
