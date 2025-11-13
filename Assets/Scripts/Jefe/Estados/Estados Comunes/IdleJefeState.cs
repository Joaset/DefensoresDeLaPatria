using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleJefeState : IJefeState
{
    private JefeController jefe;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        jefe.animator.Play("Idle");
        jefe.rb.velocity = Vector2.zero;
    }

    public void Update()
    {
        float distancia = Vector2.Distance(jefe.transform.position, jefe.player.position);

        Debug.Log("Jefe en estado Idle");
        if (distancia > jefe.rangoAtaque)
        {
            jefe.ChangeState(new WalkJefeState());
            return;
        }
        if (distancia <= jefe.rangoAtaque)
            jefe.ChangeState(new GuardiaState());
    }

    public void Exit() { }
}
