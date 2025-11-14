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
    public SpriteRenderer sr;
    public Image healthBar;
    private bool vulnerable = true;
    private float contador = 0f;

    private void Start()
    {
        currentHealth = GameManager.Instance.maxHealth;
        healthBar = GameObject.Find("Vida").GetComponent<Image>();
    }

   void Update()
    {
        healthBar.fillAmount = currentHealth / 100;
        contador += Time.deltaTime;
        /*if(contador > 1f)
        {
            StopCoroutine(Parpadear());
            contador = 0f;
        }*/
    }

    public void TakeDamage()
    {
        if (vulnerable)
        {
            currentHealth = currentHealth - 10;

            if (player != null)
            {
                if (currentHealth <= 0)
                {
                    StartCoroutine(Lose());
                    return;
                }
                else
                {
                    vulnerable = false;
                    player.ChangeStatetoHurt();
                }
            }
            else
            {
                Debug.Log("no hay player");
            }
        }
    }

    public void ActivarCorrutina()
    {
        StartCoroutine(Parpadear());
    }

    public void DetenerCorrutina()
    {
        StopCoroutine(Parpadear());
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

    IEnumerator Parpadear()
    {
        vulnerable = false;
        float cont = 0f;
        while (cont < 2f)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
            cont += 0.2f;
        }
        sr.enabled = true;
        vulnerable = true;
    }
}
