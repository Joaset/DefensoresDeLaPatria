using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovState : IState
{
    private PlayerController player;

    public Vector2 input;

    public MovState(PlayerController player) {
        this.player = player;
    }

    public void Enter(){
        player.ani.SetFloat("Speed", player.moveSpeed);
    }

    public void Update() {
        if (!player.IsMovementEnabled()) return;
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        player.transform.position += (Vector3)(input * player.moveSpeed * Time.deltaTime);

        float inputX = Input.GetAxisRaw("Horizontal");
        int lookAt = inputX > 0 ? 1  : inputX < 0 ? -1 : (int)player.Visual.localScale.x;
        player.Visual.localScale = new Vector2(lookAt, 1);

        if (input == Vector2.zero)
            player.StateMachine.ChangeState(new IdleState(player));

        if(Input.GetKeyDown(KeyCode.Space)){
            player.StateMachine.ChangeState(new JumpState(player));
        }

        if (Input.GetKeyDown(KeyCode.J)) {//puños
            player.StateMachine.ChangeState(new AttackState(player));
            return;
        }

        if (Input.GetKeyDown(KeyCode.L) && player.IsNearPowerUp()) {//Levantar pu
            player.StateMachine.ChangeState(new PickUpState(player));
            return;
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            player.StateMachine.ChangeState(new KickState(player));
            return;
        }
    }

    public void Exit(){
        player.ani.SetFloat("Speed", -player.moveSpeed);
    }
}
