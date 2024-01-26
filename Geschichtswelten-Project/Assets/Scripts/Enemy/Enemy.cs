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

   [HideInInspector] public bool dying = false;

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
    public float health = 60f;
    
    //Sight Values
    public float sightDistance = 20f;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Debug.Log("In onCollisionEnter");
            var temp =other.gameObject;
            var speed = Vector3.Magnitude(temp.GetComponent<Rigidbody>().velocity);
            Debug.Log(speed);
            switch (speed)
            {
                case <= 2f:
                    Debug.Log("Damage 1");
                    TakeDamage(5);
                    break;
                case > 2f and <= 5f:
                    Debug.Log("Damage 2");
                    TakeDamage(10);
                    break;
                case > 5f:
                    Debug.Log("Damage 3");
                    TakeDamage(20);
                    break;
            }
        }
    }
    
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
        if (dying)
        {
            return;
        }
        dying = true;
        stateMachine.GetAnimator().SetTrigger("Death");
        agent.destination = gameObject.transform.position; // to avoid the enemy getting moved while dying
        agent.speed = 0;
        gameObject.tag = "Untagged";
        StartCoroutine(DestroyOnceAnimationIsOver());
    }

    private IEnumerator DestroyOnceAnimationIsOver()
    {
        yield return new WaitForSeconds(0.5f); //wait a bit so the animation can start to play
        yield return new WaitUntil(() => stateMachine.GetAnimator().GetCurrentAnimatorStateInfo(0).IsName("dead") == false); // wait until the animation is done playing
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
