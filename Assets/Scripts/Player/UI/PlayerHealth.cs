using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //public int maxHealth = 3;
    public float currentHealth;
    public PlayerController player;
    //public UIManager uiManager;
    public Image healthBar;

    private void Start()
    {
        currentHealth = GameManager.Instance.maxHealth; ;
        //uiManager.UpdateLives(currentHealth);
    }

   void Update()
    {
        healthBar.fillAmount = currentHealth / 100;
    }

    public void TakeDamage()
    {
        currentHealth = currentHealth -10;
        //uiManager.UpdateLives(currentHealth);

        if (player != null)
        {
            if (currentHealth <= 0)
            {
                //GameObject.Destroy(player);
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
        //uiManager.UpdateLives(currentHealth);
    }

    IEnumerator Lose()
    {
        
        player.ani.SetTrigger("Dead");
        player.SetMovementEnabled(false);
        GetComponent<Collider2D>().enabled = false;
        GameObject.Destroy(player);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Derrota");
    }
}
