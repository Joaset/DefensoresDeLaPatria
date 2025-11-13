using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque2Jefe1State : IJefeState
{
    private JefeController jefe;
    private float jumpForce = 10f;
    private bool impacted = false;
    private Vector2 targetPos;
    private Rigidbody2D rb;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        rb = jefe.GetComponent<Rigidbody2D>();
        //jefe.animator.SetTrigger("Attack2");
        targetPos = jefe.player.position;
        Debug.Log("Jefe en estado Ataque2 hacia la posición: " + targetPos);
    }

    public void Update()
    {
        if (!impacted)
        {
            jefe.ChangeState(new JumpJefeState());

            if (Vector2.Distance(jefe.transform.position, targetPos) < 0.1f)
            {
                impacted = true;
            }
        }
    }

    public void Exit() {}

}
