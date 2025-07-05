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
        player.ani.SetBool("Hurt", true);
        player.SetMovementEnabled(false);
        AudioManager.Instance.PlayAudio(AudioManager.Instance.enemyHurt);
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.75f)
        {
            player.StateMachine.ChangeState(new MovState(player));
            timer = 0;
            return;
        }
    }

    public void Exit()
    {
        player.ani.SetBool("Hurt", false);
        player.SetMovementEnabled(true);
    }
}
