using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    private PlayerLook Look;
    public GameObject player;
    public bool inAir = false;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Look = player.GetComponent<PlayerLook>();
    }

    void Update()
    {
        if (inAir)
        {
            return;
        }
        if (activeState != null)
        {
            if (Look.navMeshisDeactivated)
            {
                Debug.Log(Look.navMeshisDeactivated);
                ChangeState(new WaitingState());
            }
            
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (activeState != null)
        {
            //exit former state
            activeState.Exit();
        }

        //change to a new state
        activeState = newState;

        if (activeState != null)
        {
            //Setup new state
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }

    public void Initialize()
    {
        ChangeState(new PatrolState());
    }
}
