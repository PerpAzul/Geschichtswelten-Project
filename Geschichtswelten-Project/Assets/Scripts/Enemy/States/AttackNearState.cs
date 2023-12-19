using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNearState : BaseState
{
    private float attackTimer;

    public override void Enter()
    {

    }

    public override void Perform()
    {
        Debug.Log("AttackNearState");
        if (Look.navMeshisDeactivated)
        {
            return;
        }
        if (enemy.CanSeePlayer())
        {
            float targetDistance = Mathf.Abs(Vector3.Distance(enemy.Player.transform.position, enemy.transform.position));
            enemy.transform.LookAt(enemy.Player.transform);
            enemy.Agent.SetDestination(enemy.Player.transform.position);

            if (targetDistance < enemy.Agent.stoppingDistance)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer > 1f)
                {
                    Attack();
                    attackTimer = 0;   
                }
            }

            enemy.LastknowPos = enemy.Player.transform.position;
        }
        else
        { 
            stateMachine.ChangeState(new SearchState());
        }
    }

    public override void Exit()
    {

    }

    public void Attack()
    {
        Debug.Log("Attack");
        enemy.Player.GetComponent<PlayerHealth>().TakeDamage();
    }
}
