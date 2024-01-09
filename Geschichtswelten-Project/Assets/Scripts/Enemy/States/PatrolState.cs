using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
   public int waypointIndex;
   public float waitTimer;
   
   public override void Enter()
   {
      
   }
   
   public override void Perform()
   {
      PatrolCycle();
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
   }
   
   public override void Exit()
   {
            
   }

   public void PatrolCycle()
   {
      //Debug.Log("Patrol State");
      if (enemy.Agent.remainingDistance < 0.2f)
      {
         waitTimer += Time.deltaTime;

         if (waitTimer > 3)
         {
            if (waypointIndex < enemy.path.waypoints.Count - 1)
            {
               waypointIndex++;
            }
            else
            {
               waypointIndex = 0;
            }

            //Debug.Log("Moving to Location");
            enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
            waitTimer = 0;
         }
      }
   }
}
