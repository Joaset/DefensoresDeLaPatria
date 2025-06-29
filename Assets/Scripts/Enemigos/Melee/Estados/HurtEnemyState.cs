using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyState : IState
{
    
    private EnemyController enemy;
    private float timer = 0f;

    public HurtEnemyState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        timer = 0;
        enemy.animator.SetTrigger("Hurt");
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
            enemy.StateMachine.ChangeState(new IdleEnemyState(enemy));
    }

    public void Exit() {}
}
