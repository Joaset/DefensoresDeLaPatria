using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    private PlayerController player;
    private float jumpHeight = 2.5f;
    private float gravity = -12f;
    private float verticalVelocity = 0f;

    public JumpState(PlayerController player) {
        this.player = player;
    }

    public void Enter() {
        player.isJumping = true;
        player.canJump = false;
        verticalVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
        player.ani.SetBool("saltando", true);
    }

    public void Update() {
        if (!player.IsMovementEnabled()) return;
        Vector2 input = player.mov;

        Vector3 moveDir = new Vector3(input.x, 0f, input.y).normalized;
        player.transform.position += (new Vector3(moveDir.x, moveDir.y, 0f)) * player.moveSpeed * Time.deltaTime;

        verticalVelocity += gravity * Time.deltaTime;
        Vector3 pos = player.Visual.localPosition;
        pos.y += verticalVelocity * Time.deltaTime;
        player.Visual.localPosition = pos;//hace salto del sprite renderer
        
        if (Input.GetKeyDown(KeyCode.K) && player.isJumping) {
            player.ani.SetBool("AirAttack", true);
            AudioManager.Instance.PlayAudio(AudioManager.Instance.kick);
        }

        if (player.Visual.localPosition.y <= 0f) {
            pos.y = 0f;
            player.Visual.localPosition = pos;
            verticalVelocity = 0f;

            if (input != Vector2.zero){
                player.StateMachine.ChangeState(new MovState(player));
            }else{
                player.StateMachine.ChangeState(new IdleState(player));
            }
        }
    }

    public void Exit() {
        player.ani.SetBool("AirAttack", false);
        player.ani.SetBool("saltando", false);
        player.isJumping = false;
        player.canJump = true;
    }
}
