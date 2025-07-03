using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController player;
    private bool canJump = true;

    public IdleState(PlayerController player) {
        this.player = player;
    }

    public void Enter() {
        player.ani.Play("IdlePlayer1");
    }

    public void Update() {
        if (!player.IsMovementEnabled()) return;
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (input != Vector2.zero) {
            player.StateMachine.ChangeState(new MovState(player));
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !player.isJumping) {
            player.StateMachine.ChangeState(new JumpState(player));
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.J)) {
            player.StateMachine.ChangeState(new AttackState(player));
            return;
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            player.StateMachine.ChangeState(new KickState(player));
            return;
        }

        if (Input.GetKeyDown(KeyCode.L) && player.IsNearPowerUp()) {
            player.StateMachine.ChangeState(new PickUpState(player));
            return;
        }
    }

    public void Exit() {}
}
