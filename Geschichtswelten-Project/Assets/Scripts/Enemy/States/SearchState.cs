using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;
    
    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastknowPos);
        stateMachine.GetAnimator().SetTrigger("Move");
    }

    public override void Perform()
    {
        //Debug.Log("Search State");
        if (enemy.CanSeePlayer())
        {
            if (enemy.index == 0)
            {
                stateMachine.ChangeState(new AttackState());
            }
            else
            {
                stateMachine.ChangeState(new AttackNearState());
            }
        }

        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            
            if (moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }
            
            if (searchTimer > 5)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit()
    {
        
    }
}
