using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyController controller;
    //public GameObject enemyObject;

    private void Start()
    {}

    public void TakeDamage(int damage)
    {
        controller.health -= damage;
        Debug.Log(controller.health);
        if (controller.health <= 0)
            controller.ChageStatetoDie();
        else
            controller.ChangeStatetoHurt();
    }
}
