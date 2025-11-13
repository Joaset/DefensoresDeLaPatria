using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpJefeState : IJefeState
{
    private JefeController jefe;
    private bool hasLanded = false;
    private Vector2 posInicial;
    private Vector2 targetPos;
    private Vector2 dir;
    private float tiemp = 1f;
    private float timer;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        //jefe.animator.Play("Jump");
        targetPos = jefe.player.position;
        posInicial = jefe.transform.position;
        dir = (jefe.player.position - jefe.transform.position).normalized;
        
    }

    public void Update()
    {
        timer += Time.deltaTime;

        float t = timer / tiemp;
        Vector2 horizontal = Vector2.Lerp(posInicial, targetPos, t);
        float height = Mathf.Sin(t * Mathf.PI) * 2f; // altura máxima del salto
        jefe.posJefe.position = new Vector2(horizontal.x, horizontal.y + height);
        //jefe.rb.AddForce(new Vector2(dir.x * 5f, 8f), ForceMode2D.Impulse);

        if (jefe.rb.velocity.y <= 0 && !hasLanded && jefe.transform.position.y <= 0.1f)
        {
            hasLanded = true;
            ImpactoSuelo();
            Debug.Log("Jefe impactó el suelo y esta aturdido");
            jefe.ChangeState(new AturdidoJefeState());
        }
    }

    private void ImpactoSuelo()
    {
        // Daño en área
        Collider2D[] hits = Physics2D.OverlapCircleAll(jefe.transform.position, 2f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                //hit.GetComponent<PlayerHealth>()?.TakeDamage(20);
            }
        }
    }

    public void Exit() { }
}
