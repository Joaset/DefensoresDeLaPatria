using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque1Jefe1State : IJefeState
{
    private JefeController jefe;
    private float speed = 6f;
    private float timer = 0f;
    private Vector2 dir;
    private LayerMask mask;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        Debug.Log("Jefe en estado Ataque1");
        //jefe.animator.SetTrigger("Ataque1");
        dir = (jefe.player.position.x < jefe.transform.position.x) ? Vector2.left : Vector2.right;
        Debug.Log("Dirección del ataque en x: " + dir.x);
    }

    public void Update()
    {
        timer += Time.deltaTime;
        jefe.transform.Translate(dir * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(jefe.transform.position, dir, 3f, mask);
        Debug.DrawRay(jefe.transform.position, dir * 3f, Color.red);
        Debug.Log(hit.collider);
        if (hit.collider != null)
        {
            Debug.Log("Colisiona con Limite" + hit.collider);
            jefe.ChangeState(new AturdidoJefeState());
            return;
        }
    }

    public void Exit() {}
}
