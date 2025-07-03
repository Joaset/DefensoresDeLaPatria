using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemyHealth = other.GetComponent<EnemyController>();
            Debug.Log(enemyHealth);
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);
                ScoreManager.instance.AddScore(10);
            }
        }

        if (other.CompareTag("EnemyRange"))
        {
            EnemyRangeController enemyHealth = other.GetComponent<EnemyRangeController>();
            Debug.Log(enemyHealth);
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);
                ScoreManager.instance.AddScore(10);
            }
        }

        if(other.CompareTag("Object")){
            ObjetoDestructible breakable = other.GetComponent<ObjetoDestructible>();
            if (breakable != null)
            {
                breakable.TakeDamage(1, transform.position);
            }
        }
    }
}
