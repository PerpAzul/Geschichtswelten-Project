using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : BaseState
{
    public override void Enter()
    {
        
    }

    public override void Perform()
    {
        //Debug.Log("In WaitingClass");
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
        else
        {
            stateMachine.ChangeState(new PatrolState());
        }
    }

    public override void Exit()
    {
        
    }
}
