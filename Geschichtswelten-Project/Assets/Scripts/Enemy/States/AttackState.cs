using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float shotTimer;

    public override void Enter()
    {

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

    public void Shoot()
    {
        Debug.Log("Shoot");
        enemy.flash.Play();
        Transform gunBarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, enemy.transform.rotation);
        Vector3 shootDirection = (enemy.Player.transform.position - gunBarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-2f, 2f), Vector3.up) * shootDirection * 40;
        shotTimer = 0;
    }
}
