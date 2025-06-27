using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickState : IState
{
    private PlayerController player;
    private bool isGrounded;
    private float timer = 0f;
    private float duration = 0.7f;

    public KickState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        if (!player.isJumping)
            player.ani.SetTrigger("Kick");

    }

    public void Update()
    {
        if (!player.IsMovementEnabled()) return;
        timer += Time.deltaTime;
        if (timer >= duration)
            player.StateMachine.ChangeState(new IdleState(player));
    }

    public void Exit() {}
}
