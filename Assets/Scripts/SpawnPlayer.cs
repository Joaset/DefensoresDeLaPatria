using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;
    [SerializeField] GameObject player4;
    //[SerializeField] Transform spawnPlayer;

    void Start()
    {
        if (GameManager.Instance.player == 1)
        {
            Instantiate(player1,transform.position, player1.transform.rotation);
        }

        if (GameManager.Instance.player == 2)
        {
            Instantiate(player2, transform.position, player2.transform.rotation);
        }

        if (GameManager.Instance.player == 3)
        {
            Instantiate(player3, transform.position, player3.transform.rotation);
        }

        if (GameManager.Instance.player == 4)
        {
            Instantiate(player4, transform.position, player4.transform.rotation);
        }
    }
}
