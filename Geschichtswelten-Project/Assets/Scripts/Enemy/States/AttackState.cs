using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float shotTimer;

    private float changeTimer;
    public override void Enter()
    {
        stateMachine.GetAnimator().SetTrigger("RaiseGun");
    }

    public override void Perform()
    {
        //Debug.Log("AttackState");
        if (Look.navMeshisDeactivated)
        {
            return;
        }

        if (enemy.CanSeePlayer())
        {
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            changeTimer = 0;
            enemy.transform.LookAt(enemy.Player.transform);

            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }

            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }

            if (enemy.CanSeePlayer()) //this is necessary so the enemy does not chase the player back to the respawn point, if the player respawned (changed to a new position) after the attack
            {
                enemy.LastknowPos = enemy.Player.transform.position;
            }
        }
        else
        {
            if (changeTimer <= 0.00001)
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            changeTimer += Time.deltaTime;
            if (changeTimer > 2f)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

    public override void Exit()
    {
        stateMachine.GetAnimator().SetTrigger("LowerGun");
    }

    public void Shoot()
    {
        if (stateMachine.GetAnimator().GetCurrentAnimatorStateInfo(0).IsName("idle pose with a gun"))
        {
            stateMachine.GetAnimator().SetTrigger("Shoot");
            Debug.Log("Shoot");
            enemy.flash.Play();
            Transform gunBarrel = enemy.gunBarrel;
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject,
                gunBarrel.position, enemy.transform.rotation);
            Vector3 shootDirection = (enemy.Player.transform.position - gunBarrel.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity =
                Quaternion.AngleAxis(Random.Range(-2f, 2f), Vector3.up) * shootDirection * 40;
            shotTimer = 0;
        }
        else
        {
            stateMachine.GetAnimator().SetTrigger("RaiseGun");
        }
    }
}