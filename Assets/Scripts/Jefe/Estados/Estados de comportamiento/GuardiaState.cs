using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaState : IJefeState
{
    private JefeController jefe;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        Debug.Log("Jefe en estado Guardia");
        jefe.animator.Play("Jefe1-Idle");
        jefe.rb.velocity = Vector2.zero;
    }

    public void Update()
    {
        float dist = Vector2.Distance(jefe.transform.position, jefe.player.position);
        Debug.Log("Distancia al jugador: " + dist);
        if (dist > jefe.rangoAtaque)
        {
            jefe.ChangeState(new WalkJefeState());
        }else if(dist <= jefe.rangoAtaque)
        {
            int numAl = Random.Range(1, 100);
            Debug.Log("Número aleatorio para ataque: " + numAl);
            if (numAl <= 100)
            {
                jefe.ChangeState(new Ataque1Jefe1State());
            }
            else if (numAl > 50 && numAl <= 100)
            {
                jefe.ChangeState(new JumpJefeState());
            }
            else if (numAl > 60 && numAl <= 85)
            {
                jefe.ChangeState(new Ataque3Jefe1State());
            }
            else
            {
                jefe.ChangeState(new Ataque4Jefe1State());
            }
            return;
        }
    }

    public void Exit(){}
}
