using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkJefeState : IJefeState
{
    private JefeController jefe;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        Debug.Log("Jefe en estado Walk");
        jefe.animator.Play("Walk");
    }

    public void Update()
    {
        Vector2 dir = (jefe.player.position - jefe.transform.position).normalized;
        jefe.rb.velocity = dir * jefe.speed;

        float distancia = Vector2.Distance(jefe.transform.position, jefe.player.position);

        if (distancia < jefe.rangoAtaque)
            jefe.ChangeState(new GuardiaState());
    }

    public void Exit()
    {
        jefe.rb.velocity = Vector2.zero;
    }
}
