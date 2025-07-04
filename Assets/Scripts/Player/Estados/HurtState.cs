using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : IState
{
    private PlayerController player;
    private float timer;

    public HurtState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        timer = 0f;
        player.ani.SetTrigger("Hurt");
        AudioManager.Instance.PlayAudio(AudioManager.Instance.enemyHurt);
        player.SetMovementEnabled(false);
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            player.StateMachine.ChangeState(new MovState(player));
        }
    }

    public void Exit()
    {
        player.SetMovementEnabled(true);
    }
}
