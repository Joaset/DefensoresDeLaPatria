using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private PlayerController player;
    private int contAtaque = 0;
    private float tiempoCombo = 1f;

    private float tiempoAtaque = 0.95f;
    private float contTiempoAtaque;
    private bool atacando =false;

    public AttackState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        contAtaque++;
        atacando = true;
        contTiempoAtaque = 0f;
        player.ani.SetTrigger("Attack" + contAtaque);
    }

    public void Update()
    {
        if (!player.IsMovementEnabled()) return;

        if (atacando)
        {
            contTiempoAtaque += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.J) && contTiempoAtaque < tiempoCombo && contAtaque < 2)
            {
                contAtaque++;
                player.ani.SetTrigger("Attack" + contAtaque);
                contTiempoAtaque = 0f;
            }

            if (contTiempoAtaque >= tiempoAtaque)
            {
                atacando = false;
                contAtaque = 0;
                player.StateMachine.ChangeState(new IdleState(player));
            }

        }
    }

    public void Exit()
    {
        contAtaque = 0;
    }
}
