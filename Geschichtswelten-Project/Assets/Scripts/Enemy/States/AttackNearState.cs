using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNearState : BaseState
{
    private float attackTimer;
    private float changeTimer;

    public override void Enter()
    {
        stateMachine.GetAnimator().SetTrigger("Aggressive");
        enemy.PlayInitialAggressionSound();
    }

    public override void Perform()
    {
        enemy.Agent.SetDestination(enemy.Player.transform.position);
        
        if (enemy.CanSeePlayer())
        {
            changeTimer = 0;
            float targetDistance = Mathf.Abs(Vector3.Distance(enemy.Player.transform.position, enemy.transform.position));
            if (targetDistance < 1.5 * enemy.Agent.stoppingDistance)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer > 1f)
                {
                    Attack();
                    attackTimer = 0;   
                }
            }

            if (enemy.CanSeePlayer()) //this is necessary so the enemy does not chase the player back to the respawn point, if the player respawned (changed to a new position) after the attack
            {
                enemy.LastknowPos = enemy.Player.transform.position;
            }
        }
        else
        { 
            changeTimer += Time.deltaTime;
            if (changeTimer > 2f)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

    public override void Exit()
    {
        stateMachine.GetAnimator().SetTrigger("StopAggression");
    }

    public void Attack()
    {
        //Debug.Log("Attack");
        stateMachine.GetAnimator().SetTrigger("Attack");
        enemy.Player.GetComponent<PlayerHealth>().TakeDamage();
        enemy.PlayMeleeAttackSound();
    }
}
