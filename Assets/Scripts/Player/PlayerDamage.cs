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
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20f);
                ScoreManager.instance.AddScore(100); // +100 puntos
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
