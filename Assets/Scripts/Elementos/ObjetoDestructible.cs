using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDestructible : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public SpriteRenderer sr;
    public Rigidbody2D rb;

    public GameObject powerUpPrefab;
    [Range(0f, 1f)] public float powerUpDropChance = 0.3f;

    private bool isDying = false;

    private void Awake()
    {
        currentHealth = maxHealth;

        if (sr == null)
            sr = GetComponent<SpriteRenderer>();

        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector3 attackerPosition)
    {
        if (isDying) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            StartCoroutine(DestroySequence(attackerPosition));
        }
    }

    private IEnumerator DestroySequence(Vector3 attackerPosition)
    {
        isDying = true;

        for (int i = 0; i < 5; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        TrySpawnPowerUp();

        Destroy(gameObject);
    }

    private void TrySpawnPowerUp()
    {
        if (Random.value < powerUpDropChance)
        {
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        }
    }
}
