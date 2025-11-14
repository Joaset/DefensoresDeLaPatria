using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;
    [SerializeField] GameObject player4;
    void Start()
    {
        if (GameManager.Instance.player == 1)
        {
            player1.SetActive(true);
        }
        else if (GameManager.Instance.player == 2)
        {
            player2.SetActive(true);
        }
        if (GameManager.Instance.player == 3)
        {
            player3.SetActive(true);
        }
        if (GameManager.Instance.player == 4)
        {
            player4.SetActive(true);
        }
    }

}
