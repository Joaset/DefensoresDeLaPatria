using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : IState
{
    private PlayerController player;
    private float hurtDuration = 0.5f;
    private float timer;

    public HurtState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        timer = 0f;
        player.ani.SetTrigger("Hurt"); // Asegurate de tener esta animación
        player.SetMovementEnabled(false); // Desactivar movimiento si querés
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= hurtDuration)
        {
            player.StateMachine.ChangeState(new IdleState(player)); // o JumpState si está en el aire
        }
    }

    public void Exit()
    {
        player.SetMovementEnabled(true); // Volver a habilitar movimiento
    }
}
