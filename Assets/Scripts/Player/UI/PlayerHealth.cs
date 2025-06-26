using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public PlayerController player;
    public UIManager uiManager;

    private void Start()
    {
        currentHealth = maxHealth;
        uiManager.UpdateLives(currentHealth);
    }

    public void TakeDamage()
    {
        currentHealth --;
        uiManager.UpdateLives(currentHealth);

        if(player != null){
            if (currentHealth <= 0)
            {
                player.ChangeStatetoHurt();
                GameObject.Destroy(player);
            }
            else
            {
                player.ChangeStatetoHurt();
            }
        }else{
            Debug.Log("no hay player");
        }
    }

    public void TakeLife()
    {
        currentHealth ++;
        uiManager.UpdateLives(currentHealth);
    }
}
