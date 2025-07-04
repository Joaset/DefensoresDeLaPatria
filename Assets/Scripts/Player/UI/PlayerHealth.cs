using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public PlayerController player;
    public Image healthBar;

    private void Start()
    {
        currentHealth = GameManager.Instance.maxHealth; ;
    }

   void Update()
    {
        healthBar.fillAmount = currentHealth / 100;
    }

    public void TakeDamage()
    {
        currentHealth = currentHealth -10;

        if (player != null)
        {
            if (currentHealth <= 0)
            {
                StartCoroutine(Lose());
            }
            else
            {
                player.ChangeStatetoHurt();
            }
        }
        else
        {
            Debug.Log("no hay player");
        }
    }

    public void TakeLife()
    {
        currentHealth = currentHealth +10;
    }

    IEnumerator Lose()
    {
        
        player.ani.SetTrigger("Dead");
        player.SetMovementEnabled(false);
        GetComponent<Collider2D>().enabled = false;
        GameObject.Destroy(player);
        AudioManager.Instance.PlayAudio(AudioManager.Instance.dead);

        yield return new WaitForSeconds(1.5f);

        AudioManager.Instance.StopAudio(AudioManager.Instance.backgroundMusic);
        SceneManager.LoadScene("Derrota");
    }
}
