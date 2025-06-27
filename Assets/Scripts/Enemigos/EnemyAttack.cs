using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController enemy;

    private void Awake() {
        enemy = GetComponentInParent<EnemyController>();
    }

    public void EnableHitbox() {
        enemy.EnableHitboxPunch();
    }

    public void DisableHitbox() {
        enemy.DisableHitboxPunch();
    }
}
