using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnState : IState{
    private EnemyController enemy;
    private float attackCooldown = 1.25f;
    private float timer = 0;

    public AttackEnState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        timer = 0;
        enemy.animator.SetTrigger("Attack");
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attackCooldown)
        {
            enemy.StateMachine.ChangeState(new IdleEnemyState(enemy));
        }
    }

    public void Exit() {}
}
