using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadRangeState : IState
{
    private EnemyRangeController enemy;

    public DeadRangeState(EnemyRangeController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        //enemy.DropWeapon();
        enemy.animator.SetTrigger("Die");
        GameObject.Destroy(enemy.gameObject, 1.5f);
    }

    public void Update() { }
    public void Exit() { }
}
