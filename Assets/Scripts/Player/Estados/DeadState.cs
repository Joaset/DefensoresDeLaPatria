using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    private PlayerController player;

    public DeadState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.ani.SetTrigger("Die"); // Animación de muerte
        player.SetMovementEnabled(false);
        player.GetComponent<Collider2D>().enabled = false;
        // Podés desactivar también el hitbox de ataque

        // Opcional: llamar GameManager para Game Over después de delay
    }

    public void Update()
    {
        // Podés esperar a que termine la animación o hacer fade out
    }

    public void Exit() { }
}
