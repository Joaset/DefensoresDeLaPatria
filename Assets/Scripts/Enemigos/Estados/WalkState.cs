using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
    private EnemyController enemy;
    

    public WalkState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter(){enemy.animator.SetTrigger("Walk");}

    public void Update()
    {
        float distance = Vector3.Distance(enemy.transform.position, enemy.player.position);
        
        Vector2 direccion = enemy.player.position - enemy.transform.position;

        if (Mathf.Abs(direccion.x) > 0.1f)
        {
            bool band = direccion.x > 0;

            if (band && !enemy.mira)
            {
                enemy.transform.localScale = new Vector2(enemy.transform.localScale.x * -1, enemy.transform.localScale.y);
                enemy.mira = true;
            }
            else if (!band && enemy.mira)
            {
                enemy.transform.localScale = new Vector2(enemy.transform.localScale.x * 1, enemy.transform.localScale.y);
                enemy.mira = false;
            }
        }

        if (distance < enemy.attackRange)
        {
            enemy.StateMachine.ChangeState(new AttackEnState(enemy));
            return;
        }

        Vector3 dir = (enemy.player.position - enemy.transform.position).normalized;
        enemy.transform.position += (dir * enemy.speed * Time.deltaTime);
    }

    public void Exit() {}
}
