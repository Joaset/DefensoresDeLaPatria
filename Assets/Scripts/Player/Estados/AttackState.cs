using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private PlayerController player;
    private float contKeyDown = 0f;
    private int contAtaque = 0;
    private float tiempoCombo = 1f;

    public AttackState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        contAtaque++;
        player.ani.SetTrigger("Attack" + contAtaque);
    }

    public void Update()
    {
        if (!player.IsMovementEnabled()) return;

        if (Input.GetKeyDown(KeyCode.J) && !player.isJumping)
        {
            if (Time.time - contKeyDown < tiempoCombo)
            {
                contAtaque++;
            }
            else
            {
                contAtaque = 1;
            }

            contKeyDown = Time.time;

            if(contAtaque == 1)
            {
                player.ani.SetTrigger("Attack" + contAtaque);
            }

            if (contAtaque == 2)
            {
                player.ani.SetTrigger("Attack" + contAtaque);
                contAtaque = 0;
            }
        }
    }

    public void Exit()
    {
        contAtaque = 0;
    }
}
