using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadJefeState : IJefeState
{
    private JefeController jefe;
    private ZonaJefe zona;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        zona.ActivarParedes(false);
        jefe.animator.Play("Death");
        jefe.rb.velocity = Vector2.zero;
        Object.Destroy(jefe.gameObject, 3f);
    }

    public void Update() { }

    public void Exit() { }
}