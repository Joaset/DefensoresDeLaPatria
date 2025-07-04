using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private PlayerController player;
    private float timeSinceLastAttack = 0f;
    private int currentAttack = 0;
    private float comboResetTime = 1f;
    private float attackDelay = 0.15f;
    private bool isAttacking;

    public AttackState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        isAttacking = false;
    }

    public void Update()
    {
        if (!player.IsMovementEnabled()) return;
        timeSinceLastAttack += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J) && timeSinceLastAttack > attackDelay && !player.isJumping)
        {
            currentAttack++;

            if (timeSinceLastAttack > comboResetTime || currentAttack > 2)
                currentAttack = 1;

            player.ani.SetTrigger("Attack" + currentAttack);
            AudioManager.Instance.PlayAudio(AudioManager.Instance.punch);
            timeSinceLastAttack = 0f;

            isAttacking = true;
        }

        if (isAttacking && timeSinceLastAttack > 0.4f)
        {
            isAttacking = false;
        }

        if (!isAttacking && timeSinceLastAttack > comboResetTime)
        {
            player.StateMachine.ChangeState(new IdleState(player));
        }
    }

    public void Exit()
    {
        currentAttack = 0;
        isAttacking = false;
    }
}
