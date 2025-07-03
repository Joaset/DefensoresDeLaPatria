using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeState : IState
{
    private EnemyRangeController enemy;

    public AttackRangeState(EnemyRangeController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.animator.SetTrigger("Attack");
    }

    public void Update()
    {
        Vector3 scale = enemy.transform.localScale;
        scale.x = (enemy.player.position.x > enemy.transform.position.x) ? -1 : 1;
        enemy.transform.localScale = scale;

        float dist = Vector2.Distance(enemy.transform.position, enemy.player.position);
        if (dist > enemy.attackRange)
        {
            enemy.StateMachine.ChangeState(new WalkRangeState(enemy));
            return;
        }
    }

    public void Exit() {}

    public void Shoot()
    {
        if(enemy.timer >= 2f){
            enemy.timer = 0;
            GameObject proj = BulletPool.instance.GetBullet();
            proj.transform.position = enemy.shootPoint.position;

            Vector2 dir = (enemy.player.position - enemy.shootPoint.position).normalized;
            proj.GetComponent<Rigidbody2D>().velocity = dir * 5f;
        }
    }
}
