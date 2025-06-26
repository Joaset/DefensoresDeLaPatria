using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20);
                ScoreManager.instance.AddScore(100); // +100 puntos
            }
        }

        if(other.CompareTag("Objects")){
            ObjetoDestructible breakable = other.GetComponent<ObjetoDestructible>();
            if (breakable != null)
            {
                breakable.TakeDamage(1, transform.position);
            }
        }
    }
}
