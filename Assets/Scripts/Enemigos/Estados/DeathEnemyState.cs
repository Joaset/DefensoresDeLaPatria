using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemyState : IState
{
    private EnemyController enemy;

    public DeathEnemyState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.animator.SetTrigger("Die");
        GameObject.Destroy(enemy.gameObject, 1.5f); // destruir con delay
    }

    public void Update() {}
    public void Exit() {}
}
