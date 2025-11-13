using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpState : IState
{
    private PlayerController player;
    private float timer;
    private float pickupDuration = 0.5f;

    public PickUpState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        timer = 0f;
        player.ani.SetTrigger("Pickup");
        AudioManager.Instance.PlayAudio(AudioManager.Instance.life);
        player.SetMovementEnabled(false);
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= pickupDuration)
        {
            if (player.pp.playerInRange)
            {
                Debug.Log(player.health.currentHealth < 100);
                if (player.health.currentHealth < 100)
                {
                    Debug.Log(Input.GetKeyDown(KeyCode.L));
                    if (Input.GetKeyDown(KeyCode.L))
                    {
                        player.health.TakeLife();
                    }
                }
                

                if (player.pp != null)
                    player.pp.Collect();

                // Volver a Idle
                player.StateMachine.ChangeState(new IdleState(player));
            }
        }
    }

    public void Exit()
    {
        player.SetMovementEnabled(true);
    }
}
