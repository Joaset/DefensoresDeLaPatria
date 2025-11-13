using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque3Jefe1State : IJefeState
{
    private JefeController jefe;
    private float chaseSpeed = 4f;
    private float chaseTime = 3f;
    private float timer;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        jefe.animator.SetTrigger("AttackChase");
    }

    public void Update()
    {
        timer += Time.deltaTime;

        Vector2 dir = (jefe.player.position - jefe.transform.position).normalized;
        jefe.transform.Translate(dir * chaseSpeed * Time.deltaTime);

        if (timer >= chaseTime)
            jefe.ChangeState(new IdleJefeState());
    }

    public void Exit() { }
}
