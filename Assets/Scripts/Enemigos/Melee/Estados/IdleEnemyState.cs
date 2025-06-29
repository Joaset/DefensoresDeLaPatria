using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemyState : IState
{
    private EnemyController enemy;
    private float idleDuration = 1.0f;
    private float timer = 0f;

    public IdleEnemyState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        timer = 0f;
        enemy.animator.SetTrigger("Idle");
    }

    public void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector3.Distance(enemy.transform.position, enemy.player.position);
        Debug.Log(timer >= idleDuration);
        if (distance <= enemy.attackRange)
        {
            enemy.StateMachine.ChangeState(new AttackEnState(enemy));
        }
        else if (timer >= idleDuration)
        {
            enemy.StateMachine.ChangeState(new WalkState(enemy));
        }
    }

    public void Exit() {}
}
