using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtRangeState : IState
{
    private EnemyRangeController enemy;
    private float hurtDuration = 0.3f;
    private float timer;

    public HurtRangeState(EnemyRangeController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        timer = 0f;

        enemy.animator.SetTrigger("Hurt");
    }

    public void Update()
    {
        timer += UnityEngine.Time.deltaTime;

        if (timer >= hurtDuration)
        {
            float dist = Vector2.Distance(enemy.transform.position, enemy.player.position);
            if (dist <= enemy.attackRange)
                enemy.StateMachine.ChangeState(new AttackRangeState(enemy));
            else
                enemy.StateMachine.ChangeState(new WalkRangeState(enemy));
        }
    }

    public void Exit() { }
}
