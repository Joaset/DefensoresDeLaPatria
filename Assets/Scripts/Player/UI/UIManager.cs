using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //public Image[] lives;
    public TextMeshProUGUI scoreText;
    private int score = 0000;

    /*public void UpdateLives(int health)
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = i < health;
        }
    }*/

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
