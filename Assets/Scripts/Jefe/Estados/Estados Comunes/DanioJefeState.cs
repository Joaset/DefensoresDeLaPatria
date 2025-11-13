using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioJefeState : IJefeState
{
    private JefeController jefe;
    private float timer = 0f;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        jefe.animator.Play("Hurt");
        jefe.vida.TakeDamage(10);
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.8f)
        {
            if (jefe.vida.IsDead())
                jefe.ChangeState(new DeadJefeState());
            else
                jefe.ChangeState(new IdleJefeState());
        }
    }

    public void Exit() { }
}
