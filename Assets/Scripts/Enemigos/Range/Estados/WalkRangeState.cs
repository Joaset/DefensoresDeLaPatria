using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRangeState : IState
{
    private EnemyRangeController enemy;

    public WalkRangeState(EnemyRangeController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter() {enemy.animator.SetTrigger("Walk");}

    public void Update()
    {
        float dist = Vector2.Distance(enemy.transform.position, enemy.player.position);

        if (dist > enemy.visionDistance)
        {
            enemy.StateMachine.ChangeState(new IdleRangeState(enemy));
            return;
        }

        if (dist <= enemy.attackRange)
        {
            if(enemy.timer >= 2f){
                enemy.StateMachine.ChangeState(new AttackRangeState(enemy));
            }
            return;
        }

        Vector2 dir = (enemy.player.position - enemy.transform.position).normalized;
        enemy.transform.position += (Vector3)(dir * enemy.speed * Time.deltaTime);

        Vector3 scale = enemy.transform.localScale;
        scale.x = (enemy.player.position.x > enemy.transform.position.x) ? -1 : 1;
        enemy.transform.localScale = scale;
    }

    public void Exit() {}
}
