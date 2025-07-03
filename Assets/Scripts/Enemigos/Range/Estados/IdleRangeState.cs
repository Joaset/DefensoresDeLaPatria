using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRangeState : IState
{
    private EnemyRangeController enemy;

    public IdleRangeState(EnemyRangeController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter() {enemy.animator.SetTrigger("Idle");}

    public void Update()
    {
        Vector3 scale = enemy.transform.localScale;
        scale.x = (enemy.player.position.x > enemy.transform.position.x) ? -1 : 1;
        enemy.transform.localScale = scale;

        float dist = Vector2.Distance(enemy.transform.position, enemy.player.position);
        if (dist <= enemy.visionDistance)
        {
            enemy.StateMachine.ChangeState(new WalkRangeState(enemy));
            return;
        }

        if (dist <= enemy.attackRange)
        {
            if(enemy.timer >= 2f){
                enemy.StateMachine.ChangeState(new AttackRangeState(enemy));
                return;
            }
        }
    }

    public void Exit() { }
}
