using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    /*public GameObject playerWeaponPrefab; // El arma que se le da al jugador al recogerla
    public int ammo = 5;

    private void Start()
    {
        
    }

    public void SetAmmo(int amount)
    {
        ammo = amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Instancia el arma en el jugador
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null && player.weaponHolder != null)
            {
                GameObject weapon = Instantiate(playerWeaponPrefab, player.weaponHolder.position, Quaternion.identity, player.weaponHolder);
                
                PlayerWeapon playerWeapon = weapon.GetComponent<PlayerWeapon>();
                if (playerWeapon != null)
                    playerWeapon.SetAmmo(ammo);
            }

            Destroy(gameObject); // Elimina el objeto del suelo
        }
    }*/
}
