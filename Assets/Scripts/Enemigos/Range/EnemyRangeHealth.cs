using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeHealth : MonoBehaviour
{
    private EnemyRangeController controller;

    private void Start()
    {
        controller = GetComponent<EnemyRangeController>();
    }

    public void TakeDamage(int damage)
    {
        if (controller != null)
        {
            controller.currentHealth -= damage;
            Debug.Log("Enemigo recibió daño, salud actual: " + controller.currentHealth);

            if (controller.currentHealth <= 0)
            {
                controller.StateMachine.ChangeState(new DeadRangeState(controller));
            }
            else
            {
                controller.StateMachine.ChangeState(new HurtRangeState(controller));
            }
        }
    }
}
