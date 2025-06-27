using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnState : IState{
    private EnemyController enemy;
    private float attackCooldown = 1f;
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
            // Acá hacés daño al jugador
            enemy.StateMachine.ChangeState(new WalkState(enemy));
        }
    }

    public void Exit() {}
}
