using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private PlayerController player;
    private bool pickedUp = false;
    public bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pies"))
        {
            player = other.GetComponentInParent<PlayerController>();
            playerInRange = true;
            player.pp = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pies"))
        {
            playerInRange = false;
            if (player != null)
                player.pp = null;
            player = null;
        }
    }

    public void Collect()
    {
        if (pickedUp) return;

        pickedUp = true;
        Destroy(gameObject);
    }
}
