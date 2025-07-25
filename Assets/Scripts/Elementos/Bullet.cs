using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }
            BulletPool.instance.ReturnBullet(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        BulletPool.instance.ReturnBullet(gameObject);
    }
}
