using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AturdidoJefeState : IJefeState
{
    private JefeController jefe;
    private float timer;
    private float aturdido = 2f;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        timer = 0f;
        //jefe.animator.Play("Aturdido");
        jefe.rb.velocity = Vector2.zero;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (jefe.TryGetComponent<Rigidbody2D>(out var rb))
            rb.velocity = Vector2.zero;
        if (timer >= aturdido)
        {
            float dist = Vector2.Distance(jefe.transform.position, jefe.player.position);
            if (dist <= jefe.rangoAtaque) jefe.ChangeState(new GuardiaState());
            else jefe.ChangeState(new WalkJefeState());
        }
    }

    public void Exit(){}
}
